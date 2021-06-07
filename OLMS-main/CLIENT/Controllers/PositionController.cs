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
    public class PositionController : Controller
    {
        private readonly HttpClient httpClient;
        public PositionController()
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

            var response = await httpClient.GetAsync("Position");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseVM<IEnumerable<Position>>>(apiResponse);
            return new JsonResult(data);
        }

        public async Task<JsonResult> GetById(string id)
        {
            var header = HttpContext.Session.GetString("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            var response = await httpClient.GetAsync("Position/" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseVM<Position>>(apiResponse);
            return new JsonResult(data);
        }

        [HttpPost]
        public async Task<JsonResult> Post(Position position)
        {
            var header = HttpContext.Session.GetString("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            var response = await httpClient.PostAsJsonAsync("Position", position);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseVM<Position>>(apiResponse);
            return new JsonResult(data);
        }

        [HttpPost]
        public async Task<JsonResult> Put(Position position)
        {
            var header = HttpContext.Session.GetString("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            StringContent content = new StringContent(JsonConvert.SerializeObject(position), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(typeof(Position).Name, content);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<Position>(apiResponse);
            return new JsonResult(data);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(string id)
        {
            var header = HttpContext.Session.GetString("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);

            using var response = await httpClient.DeleteAsync("Position/" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseVM<Position>>(apiResponse);
            return Json(data);
        }
    }
}