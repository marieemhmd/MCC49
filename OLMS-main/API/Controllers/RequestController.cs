using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Context;
using API.Controllers.Base;
using API.Models;
using API.Repository.Data;
using API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class RequestController : BaseController<Request, RequestRepository, int>

    {
        public static IWebHostEnvironment _webHostEnvironment;
        public readonly MyContext myContext;
        private readonly RequestRepository repository;
        public RequestController(RequestRepository requestRepository, MyContext myContext, IWebHostEnvironment webHostEnvironment) : base(requestRepository)
        {
            this.repository = requestRepository;
            this.myContext = myContext;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("sendrequest/{NIK}")]
        public ActionResult SendRequest(string NIK, RequestVM requestVM)
        {
            var data = repository.Request(NIK, requestVM);
            if (data == 1)
            {
                return Ok(new { status = HttpStatusCode.OK, message = "Your request has been sent", data });
            }
            else if (data == 2)
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = "You cannot take leave for more than 5 days or your leave quota is not enough" });
            }
            else if (data == 3)
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = "Input total days to apply for leave must be 90 days" });
            }
            else if (data == 4)
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = "Input total days to apply for leave must be 3 days" });
            }
            else if (data == 5)
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = "Input total days to apply for leave must be 2 days" });
            }
            else if (data == 6)
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = "Input total days to apply for leave must be 1 days" });
            }
            else if (data == 7)
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = "Maternity leave only for Female" });
            }
            else
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = "Error" });
            }
        }

        [HttpPut("SubmitApproved")]
        public ActionResult SubmitApproved(StatusRequestVM statusRequest)
        {
            var data = repository.Approved(statusRequest);
            if (data == 1)
            {
                return Ok(new { status = "Your request Approved" });
            }
            else
            {
                return StatusCode(500, new { status = "Internal Server Error" });
            }
        }

        [HttpPut("SubmitRejected")]
        public ActionResult SubmitRejected(StatusRequestVM statusRequest)
        {
            var data = repository.Rejected(statusRequest);
            if (data == 1)
            {
                return Ok(new { status = "Your request Rejected" });
            }
            else
            {
                return StatusCode(500, new { status = "Internal Server Error" });
            }
        }

        [HttpGet("ActionManager")]
        public ActionResult<RequestVM> ActionManager()
        {
            var data = repository.ActionManager();
            if (data != null)
            {
                return Ok(new { status = HttpStatusCode.OK, data, message = "Data Found" });
            }
            else
            {
                return StatusCode(500, new { status = "Internal Server Error" });
            }
        }

        [HttpGet("ActionHR")]
        public ActionResult<RequestVM> ActionHR()
        {
            var data = repository.ActionHR();
            if (data != null)
            {
                return Ok(new { status = HttpStatusCode.OK, data, message = "Data Found" });
            }
            else
            {
                return StatusCode(500, new { status = "Internal Server Error" });
            }
        }

        [HttpGet("HistoryByNIK/{nik}")]
        public ActionResult<RequestVM> HistoryByNIK(string nik)
        {
            var data = repository.HistoryByNIK(nik);
            if (data != null)
            {
                return Ok(new { status = HttpStatusCode.OK, data, message = "Data Found" });
            }
            else
            {
                return StatusCode(500, new { status = "Internal Server Error" });
            }
        }

        //uploadDoc
        [HttpPost("UploadDoc")]
        public async Task<IActionResult> UploadDoc([FromForm] UploadDocVM file)
        {
            try
            {
                if (file.UploadDoc.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + file.UploadDoc.FileName))
                    {
                        await file.UploadDoc.CopyToAsync(fileStream);
                        fileStream.Flush();
                        return Ok(new { status = HttpStatusCode.OK, message = "Succsess" });
                    }
                }
                else
                {
                    return StatusCode(500, new { status = "Filed" });
                }
            }
            catch (Exception)
            {
                return StatusCode(500, new { status = "Internal Server Error" });
            }            
        }

        [HttpGet("GetDoc/{fileName}")]
        public async Task<IActionResult> GetDoc(string fileName)
        {
            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
            var filePath = path + fileName + ".pdf";
            if (System.IO.File.Exists(filePath))
            {
                byte[] b = System.IO.File.ReadAllBytes(filePath);
                return File(b, "text/pdf");
            }
            return null;
        }

    }
}