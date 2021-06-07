using API.ViewModels;
using CLIENT.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CLIENT.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient httpClient;
        public AuthController()
        {
            URL Url = new URL();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(Url.GetDevelopment())
            };
        }

        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var response = await httpClient.PostAsJsonAsync("Account/Login", loginVM);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<UserLoginVM>(apiResponse);
            HttpContext.Session.SetString("token", data.Token);
            HttpContext.Session.SetString("name", data.Result.FullName);
            HttpContext.Session.SetString("email", data.Result.Email);
            HttpContext.Session.SetString("role", data.Result.RoleName);
            HttpContext.Session.SetString("nik", data.Result.NIK);

            return Json(data);
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM forgot)
        {
            var response = await httpClient.PostAsJsonAsync("Account/ForgotPassword", forgot);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<UserLoginVM>(apiResponse);

            return new JsonResult(result);
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true, Duration = -1)]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            foreach (var cookie in Request.Cookies.Keys)
            {
                if (cookie == ".AspNetCore.Session")
                    Response.Cookies.Delete(cookie);
            }
            return RedirectToAction("Login");
        }
    }
}