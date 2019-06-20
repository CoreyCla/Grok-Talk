using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GrokTalk.Models;

namespace GrokTalk.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult History()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Info()
        {
            ViewData["Message"] = "Some info worth noting (probably).";

            return View();
        }     

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
