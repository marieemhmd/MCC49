using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Controllers.Base;
using API.Models;
using API.Repository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Authorize (Roles = "Admin, Employee, Manager, HR")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<Employee, EmployeeRepository, string>

    {
        private readonly EmployeeRepository repository;
        public EmployeeController(EmployeeRepository employeeRepository) : base(employeeRepository)
        {
            repository = employeeRepository;
        }

        [HttpPut("ResetRemainingQuota")]
        [EnableCors("AllowMethod")]
        public ActionResult ResetRemainingQuota()
        {
            var data = repository.ResetRemainingQuota();
            if (data > 0)
            {
                return Ok(new { status = HttpStatusCode.OK, data, message = "Sucssess" });
            }
            else
            {
                return StatusCode(500, new { status = "Internal Server Error" });
            }
        }
    }
}