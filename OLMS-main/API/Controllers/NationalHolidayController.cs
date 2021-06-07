using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Repository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Base
{
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class NationalHolidayController : BaseController<NationalHoliday, NationalHolidayRepository, int>
    {
        public NationalHolidayController(NationalHolidayRepository nationalHolidayRepository) : base(nationalHolidayRepository)
        {

        }
    }
}