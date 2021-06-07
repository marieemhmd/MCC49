using API.Context;
using API.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<MyContext, Employee, string>
    {
        public IConfiguration _configuration;
        public readonly MyContext myContext;        
        public EmployeeRepository(MyContext myContext, IConfiguration configuration) : base(myContext)
        {
            this.myContext = myContext;
            _configuration = configuration;
        }

        public int ResetRemainingQuota()
        {
            var data = new GeneralDapperRepository<Employee>(_configuration);
            var result = data.Execute("SP_ResetremainingQuota", null);
            return result;
        }
    }
}
