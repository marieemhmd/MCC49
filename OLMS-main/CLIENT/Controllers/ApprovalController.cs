using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using API.Models;
using API.ViewModels;
using CLIENT.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CLIENT.Controllers
{
    public class ApprovalController : Controller
    {
        private readonly HttpClient httpClient;
        public ApprovalController()
        {
            URL Url = new URL();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(Url.GetDevelopment())
            };
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Request/ApprovalRequest")]
        public async Task<IActionResult> ApprovalRequest(StatusRequestVM statusRequestVM)
        {
            var response = await httpClient.PostAsJsonAsync("Request/SubmitApproved", statusRequestVM);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<StatusRequestVM>(apiResponse);
            return Json(data);
        }

        public IActionResult RequestTable()
        {
            return View();
        }

        [HttpPost]
        [Route("Request/RequestTable")]
        public async Task<IActionResult> TableRequest(Request request)
        {
            var response = await httpClient.PostAsJsonAsync("Request/Get", request);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<RequestVM>(apiResponse);
            return Json(data);
        }
    }
}