using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Repository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API.Controllers.Base
{
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly ChartRepository _chartRepository;
        private readonly IConfiguration _configuration;
        public ChartController(ChartRepository chartRepository, IConfiguration configuration)
        {
            _chartRepository = chartRepository;
            _configuration = configuration;
        }

        [HttpGet("Position")]
        [EnableCors("AllowOrigin")]
        public IActionResult Position()
        {
            var result = _chartRepository.Position();
            if(result != null)
            {
                return Ok(new { status = HttpStatusCode.OK, result, message = "Data Found" });
            }
            else
            {
                return NotFound(new { status = HttpStatusCode.NotFound, message = "Not Found", result = "" });
            }
        }

        [HttpGet("Department")]
        [EnableCors("AllowOrigin")]
        public IActionResult Department()
        {
            var result = _chartRepository.Department();
            if (result != null)
            {
                return Ok(new { status = HttpStatusCode.OK, result, message = "Data Found" });
            }
            else
            {
                return NotFound(new { status = HttpStatusCode.NotFound, message = "Not Found", result = "" });
            }
        }

        [HttpGet("RemainingQuota")]
        [EnableCors("AllowOrigin")]
        public IActionResult RemainingQuota()
        {
            var result = _chartRepository.RemainingQuota();
            if (result != null)
            {
                return Ok(new { status = HttpStatusCode.OK, result, message = "Data Found" });
            }
            else
            {
                return NotFound(new { status = HttpStatusCode.NotFound, message = "Not Found", result = "" });
            }
        }

        [HttpGet("ReasonRequest")]
        [EnableCors("AllowOrigin")]
        public IActionResult ReasonRequest()
        {
            var result = _chartRepository.ReasonRequest();
            if (result != null)
            {
                return Ok(new { status = HttpStatusCode.OK, result, message = "Data Found" });
            }
            else
            {
                return NotFound(new { status = HttpStatusCode.NotFound, message = "Not Found", result = "" });
            }
        }

        [HttpGet("TotalReasonByNIK/{NIK}")]
        [EnableCors("AllowOrigin")]
        public IActionResult TotalReasonByNIK(string NIK)
        {
            var result = _chartRepository.TotalReasonByNIK(NIK);
            if (result != null)
            {
                return Ok(new { status = HttpStatusCode.OK, result, message = "Data Found" });
            }
            else
            {
                return NotFound(new { status = HttpStatusCode.NotFound, message = "Data Not Found", result ="" });
            }
        }

        [HttpGet("RequestByDate")]
        [EnableCors("AllowOrigin")]
        public IActionResult RequestByDate()
        {
            var result = _chartRepository.RequestByDate();
            if (result != null)
            {
                return Ok(new { status = HttpStatusCode.OK, result, message = "Data Found" });
            }
            else
            {
                return NotFound(new { status = HttpStatusCode.NotFound, message = "Not Found", result = "" });
            }
        }

    }
}