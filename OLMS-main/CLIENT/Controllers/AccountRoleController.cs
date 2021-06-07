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
    public class AccountRoleController : Controller
    {
        private readonly HttpClient httpClient;
        public AccountRoleController()
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

        public async Task<IActionResult> EmpProfile()
        {
            ViewBag.Role = HttpContext.Session.GetString("role");
            if (ViewBag.Role != "Employee")
            {
                return RedirectToAction("Error", "Home");
            }

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

            var response = await httpClient.GetAsync("AccountRole");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseVM<IEnumerable<AccountRole>>>(apiResponse);
            return new JsonResult(data);
        }

        public async Task<JsonResult> GetById(string id)
        {
            var header = HttpContext.Session.GetString("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            var response = await httpClient.GetAsync("AccountRole/" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseVM<AccountRole>>(apiResponse);
            return new JsonResult(data);
        }

        [HttpPost]
        public async Task<JsonResult> Post(AccountRole accountRole)
        {
            var header = HttpContext.Session.GetString("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            var response = await httpClient.PostAsJsonAsync("AccountRole", accountRole);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseVM<AccountRole>>(apiResponse);
            return new JsonResult(data);
        }

        [HttpPost]
        public async Task<JsonResult> Put(AccountRole accountRole)
        {
            var header = HttpContext.Session.GetString("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            StringContent content = new StringContent(JsonConvert.SerializeObject(accountRole), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(typeof(AccountRole).Name, content);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<AccountRole>(apiResponse);
            return new JsonResult(data);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(string id)
        {
            var header = HttpContext.Session.GetString("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            using var response = await httpClient.DeleteAsync("AccountRole/" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseVM<AccountRole>>(apiResponse);
            return Json(data);
        }
    }
}