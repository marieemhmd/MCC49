using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class NationalHolidayRepository : GeneralRepository<MyContext, NationalHoliday, int>
    {
        public readonly MyContext myContext;
        public NationalHolidayRepository(MyContext myContext): base(myContext)
        {
            this.myContext = myContext;
        }

        public List<NationalHoliday> GetData()
        {
            var result = myContext.NationalHolidays.ToList();
            return result;
        }
    }
}
