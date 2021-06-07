using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using API.Models;
using API.ViewModels;
using CLIENT.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CLIENT.Controllers
{
    public class RequestController : Controller
    {
        private readonly HttpClient httpClient;
        public RequestController()
        {
            URL Url = new URL();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(Url.GetDevelopment())
            };
        }

        public IActionResult Index()
        {
            ViewBag.Role = HttpContext.Session.GetString("role");
            if (ViewBag.Role == "Admin")
            {
                return RedirectToAction("Error", "Home");
            }

            return View("Index");
        }

        [Route("History")]
        public IActionResult History()
        {
            ViewBag.Role = HttpContext.Session.GetString("role");
            if (ViewBag.Role == "Admin")
            {
                return RedirectToAction("Error", "Home");
            }
            return View();
        }

        [Route("RequestList")]
        public IActionResult RequestList()
        {
            ViewBag.Role = HttpContext.Session.GetString("role");
            if (ViewBag.Role == "Admin")
            {
                return View();
            }
            return RedirectToAction("Error", "Home");
        }

        public async Task<JsonResult> Get()
        {           
            var header = HttpContext.Session.GetString("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            var response = await httpClient.GetAsync("Request");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseVM<IEnumerable<Request>>>(apiResponse);
            return new JsonResult(data);
        }

        public async Task<JsonResult> GetById(string id)
        {
            var header = HttpContext.Session.GetString("Token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            var response = await httpClient.GetAsync("Request/" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseVM<Request>>(apiResponse);
            return new JsonResult(data);
        }

        [HttpPost]
        [Route("Request/SendRequest")]
        public async Task<IActionResult> SendRequest(RequestVM requestVM)
        {
            var id = HttpContext.Session.GetString("nik");

            var definition = new { Message = "", Status = "", Token = "" };
            var response = await httpClient.PostAsJsonAsync("Request/SendRequest/" + id, requestVM);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeAnonymousType(apiResponse, definition);
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("Request/ActionManager")]
        public async Task<JsonResult> ActionManager()
        {           
            var response = await httpClient.GetAsync("Request/ActionManager");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseVM<IEnumerable<RequestVM>>>(apiResponse);
            return new JsonResult(data);
        }

        [HttpGet]
        [Route("Request/ActionHR")]
        public async Task<JsonResult> ActionHR()
        {
            var response = await httpClient.GetAsync("Request/ActionHR");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseVM<IEnumerable<RequestVM>>>(apiResponse);
            return new JsonResult(data);
        }

        [Route("RequestHistory")]
        public IActionResult RequestHistory()
        {
            return View();
        }

        [HttpGet]
        [Route("Request/HistoryByNIK")]
        public async Task<IActionResult> HistoryByNIK()
        {
            ViewBag.NIK = HttpContext.Session.GetString("nik");

            var header = HttpContext.Session.GetString("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            var nik = ViewBag.NIK;

            //var definition = new { Message = "", Status = "", Token = "" };
            //var response = await httpClient.GetAsync("Request/HistoryByNIK/" + nik);
            //string apiResponse = await response.Content.ReadAsStringAsync();
            //var result = JsonConvert.DeserializeAnonymousType(apiResponse, definition);
            //return new JsonResult(result);

            var response = await httpClient.GetAsync("Request/HistoryByNIK/" + nik);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseVM<IEnumerable<RequestVM>>>(apiResponse);
            return Json(data);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(string id)
        {
            var header = HttpContext.Session.GetString("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            using var response = await httpClient.DeleteAsync("Request/" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseVM<Request>>(apiResponse);
            return Json(data);
        }

        //uploadFile
        [HttpPost]
        public async Task<JsonResult> UploadFile(UploadDocVM request)
        {
            var header = HttpContext.Session.GetString("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            var response = await httpClient.PostAsJsonAsync("Request/UploadDoc", request);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseVM<UploadDocVM>>(apiResponse);
            return new JsonResult(data);
        }
    }
}