using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesCors.Controllers
{
    public class TestTestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
