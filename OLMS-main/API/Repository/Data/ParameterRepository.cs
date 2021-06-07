using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class ParameterRepository : GeneralRepository<MyContext, Parameter, int>
    {
        public readonly MyContext _myContext;
        public ParameterRepository(MyContext myContext) : base(myContext)
        {
            _myContext = myContext;
        }

        public Parameter GetByName(string name)
        {
            var result = _myContext.Parameters.Where(p => p.Name == name).FirstOrDefault();
            return result;
        }
    }
}
