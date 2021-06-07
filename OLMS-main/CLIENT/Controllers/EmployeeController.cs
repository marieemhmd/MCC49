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
    public class EmployeeController : Controller
    {
        private readonly HttpClient httpClient;
        public EmployeeController()
        {
            URL Url = new URL();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(Url.GetDevelopment())
            };
        }
        [Route("Profile")]
        public ViewResult Profile()
        {
            return View();
        }

        public async Task<IActionResult> EmpProfile()
        {
            ViewBag.Role = HttpContext.Session.GetString("role");
            //if (ViewBag.Role != "Employee")
            //{
            //    return RedirectToAction("Error", "Home");
            //}

            ViewBag.NIK = HttpContext.Session.GetString("nik");

            var header = HttpContext.Session.GetString("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            var id = ViewBag.NIK;

            var response = await httpClient.GetAsync("Employee/" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseVM<Employee>>(apiResponse);
            return new JsonResult(data);
        }

        public async Task<JsonResult> Get()
        {
            var header = HttpContext.Session.GetString("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            var response = await httpClient.GetAsync("Employee");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseVM<IEnumerable<Employee>>>(apiResponse);
            return new JsonResult(data);
        }

        public async Task<JsonResult> GetById(string id)
        {
            var header = HttpContext.Session.GetString("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            var response = await httpClient.GetAsync("Employee/" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseVM<Employee>>(apiResponse);
            return new JsonResult(data);
        }

        [HttpPost]
        public async Task<JsonResult> Post(CreateEmployeeVM create)
        {
            var header = HttpContext.Session.GetString("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            var response = await httpClient.PostAsJsonAsync("Account/Register", create);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseVM<CreateEmployeeVM>>(apiResponse);
            return new JsonResult(data);
        }

        [HttpPost]
        public async Task<JsonResult> Put(Employee employee)
        {
            var header = HttpContext.Session.GetString("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(typeof(Employee).Name, content);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<Employee>(apiResponse);
            return new JsonResult(data);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(string id)
        {
            var header = HttpContext.Session.GetString("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            using var response = await httpClient.DeleteAsync("Employee/" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseVM<Employee>>(apiResponse);
            return Json(data);
        }

        [Route("ChangePassword")]
        public ViewResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM change)
        {

            string id = HttpContext.Session.GetString("nik");
            var definition = new { Message = "", Status = "", Token = "" };
            var response = await httpClient.PutAsJsonAsync("Account/ChangePassword/" + id, change);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeAnonymousType(apiResponse, definition);
            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> ResetQuota(Employee employee)
        {
            var header = HttpContext.Session.GetString("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("Employee/ResetRemainingQuota/", content);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<Employee>(apiResponse);
            return new JsonResult(data);
        }

        [Route("SummaryDashboard")]
        public IActionResult Dashboard()
        {
            string id = HttpContext.Session.GetString("nik");
            ViewBag.Role = HttpContext.Session.GetString("role");
            if (ViewBag.Role == "Employee" || ViewBag.Role == "Manager" || ViewBag.Role == "HR")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}