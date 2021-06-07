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
    public class RoleController : Controller
    {
        private readonly HttpClient httpClient;
        public RoleController()
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

        //public async Task<IActionResult> EmpProfile()
        //{
        //    ViewBag.Role = HttpContext.Session.GetString("role");
        //    if (ViewBag.Role != "Employee")
        //    {
        //        return RedirectToAction("Error", "Home");
        //    }

        //    ViewBag.NIK = HttpContext.Session.GetString("nik");

        //    var header = HttpContext.Session.GetString("token");
        //    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

        //    var id = ViewBag.NIK;

        //    var response = await httpClient.GetAsync("Employee/" + id);
        //    string apiResponse = await response.Content.ReadAsStringAsync();
        //    var data = JsonConvert.DeserializeObject<ResponseVM<Employee>>(apiResponse);
        //    return new JsonResult(data);
        //}

        public async Task<JsonResult> Get()
        {
            var header = HttpContext.Session.GetString("Token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            var response = await httpClient.GetAsync("Role");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseVM<IEnumerable<Role>>>(apiResponse);
            return new JsonResult(data);
        }

        public async Task<JsonResult> GetById(string id)
        {
            var header = HttpContext.Session.GetString("Token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            var response = await httpClient.GetAsync("Role/" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseVM<Role>>(apiResponse);
            return new JsonResult(data);
        }

        [HttpPost]
        public async Task<JsonResult> Post(Role create)
        {
            var header = HttpContext.Session.GetString("Token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            var response = await httpClient.PostAsJsonAsync("Role", create);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseVM<Role>>(apiResponse);
            return new JsonResult(data);
        }

        [HttpPost]
        public async Task<JsonResult> Put(Role role)
        {
            var header = HttpContext.Session.GetString("Token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            StringContent content = new StringContent(JsonConvert.SerializeObject(role), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(typeof(Role).Name, content);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<Role>(apiResponse);
            return new JsonResult(data);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(string id)
        {
            var header = HttpContext.Session.GetString("Token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            using var response = await httpClient.DeleteAsync("Role/" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseVM<Role>>(apiResponse);
            return Json(data);
        }
    }
}