using API.ViewModels;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class ChartRepository : GeneralDapperRepository<ChartVM>
    {
        public IConfiguration _configuration;
        readonly DynamicParameters _parameters = new DynamicParameters();
        public ChartRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        public IEnumerable<ChartVM> Position()
        {
            var _userRepo = new GeneralDapperRepository<ChartVM>(_configuration);
            var result = _userRepo.Get("SP_retrieveQoutaPosition", null);
            return result;
        }

        public IEnumerable<ChartVM> Department()
        {
            var _userRepo = new GeneralDapperRepository<ChartVM>(_configuration);
            var result = _userRepo.Get("SP_retrieveQuotaDept", null);
            return result;
        }

        public IEnumerable<ChartVM> RemainingQuota()
        {
            var _userRepo = new GeneralDapperRepository<ChartVM>(_configuration);
            var result = _userRepo.Get("SP_retrieveRemainingQuota", null);
            return result;
        }

        public IEnumerable<ChartVM> ReasonRequest()
        {
            var _userRepo = new GeneralDapperRepository<ChartVM>(_configuration);
            var result = _userRepo.Get("SP_retrieveReasonRequest", null);
            return result;
        }

        public IEnumerable<ChartVM> TotalReasonByNIK(string NIK)
        {
            var userRepo = new GeneralDapperRepository<ChartVM>(_configuration);
            var temp = NIK;
            _parameters.Add("@NIK", temp);
            var result = userRepo.Get("SP_chartEmployee", _parameters);
            return result;
        }

        public IEnumerable<ChartVM> RequestByDate()
        {
            var _userRepo = new GeneralDapperRepository<ChartVM>(_configuration);
            var result = _userRepo.Get("SP_requestByDate", null);
            return result;
        }

    }
}
