using API.Context;
using API.Handler;
using API.Models;
using API.ViewModels;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {
        public IConfiguration _configuration;
        readonly DynamicParameters _parameters = new DynamicParameters();
        public readonly MyContext myContext;
        public readonly ParameterRepository parameterRepository;
        public readonly NationalHolidayRepository nationalHolidayRepository;

        public AccountRepository(MyContext myContext, IConfiguration configuration, ParameterRepository parameterRepository, NationalHolidayRepository nationalHolidayRepository) : base(myContext)
        {
            _configuration = configuration;
            this.myContext = myContext;
            this.parameterRepository = parameterRepository;
            this.nationalHolidayRepository = nationalHolidayRepository;
        }

        public LoginVM Login(LoginVM loginVM)
        {
            var condition = myContext.Employees.Where(a => a.Email == loginVM.Email).FirstOrDefault();

            if (Hashing.ValidatePassword(loginVM.Password, condition.Account.AccountPassword))
            {
                var _userRepository = new GeneralDapperRepository<LoginVM>(_configuration);
                _parameters.Add("@Email", loginVM.Email);
                _parameters.Add("@Password", loginVM.Password);
                var result = _userRepository.Query("SP_Login", _parameters);
                return result;
            }
            else
            {
                return null;
            }
        }

        public int ChangePassword(string NIK, string Password)
        {
            Account account = myContext.Accounts.Where(acc => acc.NIK == NIK).FirstOrDefault();
            account.AccountPassword = Hashing.HashPassword(Password); //hashing
            myContext.Entry(account).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            return result;
        }

        public int Register(CreateEmployeeVM createEmployeeVM)
        {
            Parameter parameter = parameterRepository.GetByName("leave allowance");

            var holiday = nationalHolidayRepository.GetData();

            var _userRepository = new GeneralDapperRepository<CreateEmployeeVM>(_configuration);

            _parameters.Add("@nik", createEmployeeVM.NIK);
            _parameters.Add("@fullName", createEmployeeVM.FullName);
            _parameters.Add("@phoneNumber", createEmployeeVM.PhoneNumber);
            _parameters.Add("@email", createEmployeeVM.Email);
            _parameters.Add("@birthDate", createEmployeeVM.BirthDate);
            _parameters.Add("@gender", createEmployeeVM.Gender);
            _parameters.Add("@maritalStatus", createEmployeeVM.MaritalStatus);
            _parameters.Add("@address", createEmployeeVM.Address);
            _parameters.Add("@remainingQuota", parameter.Value - holiday.Count());
            _parameters.Add("@PositionID", createEmployeeVM.PositionId);
            _parameters.Add("@nikManager", createEmployeeVM.NIK_Manager);
            _parameters.Add("@password", Hashing.HashPassword("password"));
            _parameters.Add("@joinDate", DateTime.Now);

            var result = _userRepository.Execute("SP_Register", _parameters);

            return result;
        }
    }
}
