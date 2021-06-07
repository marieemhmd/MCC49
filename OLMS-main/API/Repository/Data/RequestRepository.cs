using API.Context;
using API.Handler;
using API.Models;
using API.ViewModels;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class RequestRepository : GeneralRepository<MyContext, Request, int>
    {
        public IConfiguration _configuration;
        readonly DynamicParameters _parameters = new DynamicParameters();
        private readonly MyContext myContext;        
        public RequestRepository(MyContext myContext, IConfiguration configuration) : base(myContext)
        {
            this.myContext = myContext;
            _configuration = configuration;
        }

        public int Request(string NIK, RequestVM requestVM)
        {
            Employee employee = myContext.Employees.Where(emp => emp.NIK == NIK).FirstOrDefault();
            var totalDays = (requestVM.EndDate.AddDays(1) - requestVM.StartDate).TotalDays;
            if (totalDays > 0)
            {
                var request = new Request()
                {
                    NIK_Employee = NIK,
                    StartDate = requestVM.StartDate,
                    EndDate = requestVM.EndDate,
                    ReasonRequest = requestVM.ReasonRequest,
                    Notes = requestVM.Notes,
                    RequestStatus = RequestStatus.OnProcess,
                    RequestDate = DateTime.Now
                    //UploadDoc = requestVM.UploadDoc.FileName                    
                };

                var requestData = new GeneralDapperRepository<RequestVM>(_configuration);
                var temp1 = NIK;
                _parameters.Add("@NIK", temp1);
                var resultQuota = requestData.Query("SP_remainingQuota", _parameters);

                if (requestVM.ReasonRequest == "Normal leave")
                {
                    if (totalDays > resultQuota.RemainingQuota || totalDays > 5)
                    {
                        return 2;
                    }
                }
                else if (requestVM.ReasonRequest == "Maternity leave" )
                {
                    if (employee.Gender == "Male")
                    {
                        return 7;
                    }
                    else if (totalDays != 90)
                    {
                        return 3;
                    }
                }
                else if (requestVM.ReasonRequest == "Married")
                {
                    if (totalDays != 3)
                    {
                        return 4;
                    }
                }
                else if (requestVM.ReasonRequest == "Marry or Circumcise or Baptize Children" ||
                    requestVM.ReasonRequest == "Wife gave birth or had a miscarriage" ||
                    requestVM.ReasonRequest == "Husband or Wife Parents or In laws Children or Son In law have passed away")
                {
                    if (totalDays != 2)
                    {
                        return 5;
                    }
                }
                else if (requestVM.ReasonRequest == "Family member in one house died")
                {
                    if (totalDays != 1)
                    {
                        return 6;
                    }
                }
                //End Condition For ReasionRequest

                myContext.Add(request);
                var datarequest = myContext.SaveChanges();

                var request1 = new GeneralDapperRepository<RequestVM>(_configuration);
                var temp = NIK;
                _parameters.Add("@NIK", temp);
                var result2 = request1.Query("SP_EmailManager", _parameters);

                var emailManager = result2.EmailManager;                

                SendEmail.SendRequest(emailManager, employee.Manager.FullName, employee.FullName, employee.Position.PositionName, requestVM);

                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Approved(StatusRequestVM request)
        {
            var data = myContext.Requests.Where(r => r.Id == request.Id).FirstOrDefault();
            if (data == null)
            {
                return 0;
            }
            else if (data.RequestStatus == RequestStatus.RejectByManager || data.RequestStatus == RequestStatus.RejectByHRD)
            {
                return 0;
            }

            if (data.RequestStatus == RequestStatus.OnProcess)
            {
                data.RequestStatus = RequestStatus.ApprovedByManager;
                data.ApprovedManager = "Approved";
                myContext.Update(data);

                var request2 = new GeneralDapperRepository<RequestVM>(_configuration);
                _parameters.Add("@RoleId", 4); //role HR
                var result2 = request2.Query("SP_sendEmailHR", _parameters);

                var emailHR = result2.Email;
                SendEmail.Approvemanager(emailHR, data);
            }

            else if (data.RequestStatus == RequestStatus.ApprovedByManager)
            {
                var totoalDays = (data.EndDate.AddDays(1) - data.StartDate).TotalDays;
                var dataQuota = myContext.Requests.Where(e => e.Id == request.Id).FirstOrDefault();
                dataQuota.Employee.RemainingQuota -= Convert.ToInt32(totoalDays); //kondisi cuti hamil
                myContext.Update(dataQuota);
                myContext.SaveChanges();

                data.RequestStatus = RequestStatus.ApprovedByHRD;
                data.ApprovedHRD = "Approved";
                myContext.Update(data);

                var request3 = new GeneralDapperRepository<RequestVM>(_configuration);
                var param = request.Id;
                _parameters.Add("@Id", param);
                var result3 = request3.Query("SP_EmailEmployee", _parameters);

                var emailEmployee = result3.Email;
                SendEmail.ApproveHR(emailEmployee, data);
            }
            myContext.SaveChanges();
            return 1;
        }

        public int Rejected(StatusRequestVM request)
        {
            var data = myContext.Requests.Where(r => r.Id == request.Id).FirstOrDefault();
            if (data == null)
            {
                return 0;
            }

            else if (data.RequestStatus == RequestStatus.OnProcess)
            {
                data.RequestStatus = RequestStatus.RejectByManager;
                data.ApprovedManager = "Rejected";
                myContext.Update(data);

                var request1 = new GeneralDapperRepository<RequestVM>(_configuration);
                var temp = request.Id;
                _parameters.Add("@Id", temp);
                var result2 = request1.Query("SP_EmailEmployee", _parameters);

                var emailEmployee = result2.Email;
                SendEmail.Rejected(emailEmployee, request.RejectedNotes, data);
            }

            else if (data.RequestStatus == RequestStatus.ApprovedByManager)
            {
                data.RequestStatus = RequestStatus.RejectByHRD;
                data.ApprovedManager = "Rejected";
                myContext.Update(data);

                var request1 = new GeneralDapperRepository<RequestVM>(_configuration);
                var temp = request.Id;
                _parameters.Add("@Id", temp);
                var result2 = request1.Query("SP_EmailEmployee", _parameters);

                var emailEmployee = result2.Email;
                SendEmail.Rejected(emailEmployee, request.RejectedNotes, data);
            }
            else
            {
                return 0;
            }
            myContext.SaveChanges();
            return 1;
        }

        public IEnumerable<RequestVM> ActionManager()
        {
            var request = new GeneralDapperRepository<RequestVM>(_configuration);
            _parameters.Add("@Status", 0);
            var result = request.Get("SP_statusRequest", _parameters);
            return result;
        }

        public IEnumerable<RequestVM> ActionHR()
        {
            var request = new GeneralDapperRepository<RequestVM>(_configuration);
            _parameters.Add("@Status", 3);
            var result = request.Get("SP_statusRequest", _parameters);
            return result;
        }

        public IEnumerable<RequestVM> HistoryByNIK(string nik)
        {
            var history = new GeneralDapperRepository<RequestVM>(_configuration);
            _parameters.Add("@NIK", nik);
            var result = history.Get("SP_historyRequest", _parameters);
            return result;
        }
    }
}