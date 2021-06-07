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
    public class DepartmentController : Controller
    {
        private readonly HttpClient httpClient;
        public DepartmentController()
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
            if (ViewBag.Role != "Admin")
            {
                return RedirectToAction("Error", "Home");
            }
            return View();
        }

        public async Task<JsonResult> Get()
        {
            var header = HttpContext.Session.GetString("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            var response = await httpClient.GetAsync("Department");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseVM<IEnumerable<Department>>>(apiResponse);
            return new JsonResult(data);
        }

        public async Task<JsonResult> GetById(string id)
        {
            var header = HttpContext.Session.GetString("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            var response = await httpClient.GetAsync("Department/" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseVM<Department>>(apiResponse);
            return new JsonResult(data);
        }

        [HttpPost]
        public async Task<JsonResult> Post(Department department)
        {
            var header = HttpContext.Session.GetString("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            var response = await httpClient.PostAsJsonAsync("Department", department);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseVM<Department>>(apiResponse);
            return new JsonResult(data);
        }

        [HttpPost]
        public async Task<JsonResult> Put(Department department)
        {
            var header = HttpContext.Session.GetString("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            StringContent content = new StringContent(JsonConvert.SerializeObject(department), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(typeof(Department).Name, content);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<Department>(apiResponse);
            return new JsonResult(data);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(string id)
        {
            var header = HttpContext.Session.GetString("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            using var response = await httpClient.DeleteAsync("Department/" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseVM<Department>>(apiResponse);
            return Json(data);
        }
    }
}