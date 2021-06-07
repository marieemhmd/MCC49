using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.Base;
using API.Models;
using CLIENT.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CLIENT.Controllers
{
    public class AdminController : Controller
    {
        [Route("EmployeeList")]
        public IActionResult Index()
        {
            ViewBag.Role = HttpContext.Session.GetString("role");
            if (ViewBag.Role == "Admin")
            {
                return View();
            }           
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [Route("Dashboard")]
        public IActionResult Dashboard()
        {
            ViewBag.Role = HttpContext.Session.GetString("role");
            if (ViewBag.Role == "Admin")
            {
                return View();
            }
            else if (ViewBag.Role == "Employee" || ViewBag.Role == "Manager" || ViewBag.Role == "HR")
            {
                return Redirect("/SummaryDashboard");
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}