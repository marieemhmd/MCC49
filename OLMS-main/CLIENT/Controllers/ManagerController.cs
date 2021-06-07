using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using API.ViewModels;
using CLIENT.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CLIENT.Controllers
{
    public class ManagerController : Controller
    {
        private readonly HttpClient httpClient;
        public ManagerController()
        {
            URL Url = new URL();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(Url.GetDevelopment())
            };
        }

        // GET: Manager
        public ActionResult Index()
        {
            ViewBag.Role = HttpContext.Session.GetString("role");

            if (ViewBag.Role != "Manager")
            {
                return RedirectToAction("Error", "Home");
            }
            return View();
        }

        [HttpPut]
        public async Task<JsonResult> Approve(StatusRequestVM statusRequestVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(statusRequestVM), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("Request/SubmitApproved", content);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<StatusRequestVM>(apiResponse);
            return new JsonResult(result);
        }

        [HttpPut]
        public async Task<JsonResult> Reject(StatusRequestVM statusRequestVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(statusRequestVM), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("Request/SubmitRejected", content);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<StatusRequestVM>(apiResponse);
            return new JsonResult(result);
        }
    }
}