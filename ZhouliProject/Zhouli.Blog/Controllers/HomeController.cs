using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Models;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["PageName"] = "Index";
            return View();
        }
        public IActionResult Friendly() {
            ViewData["PageName"] = "Friendly";
            return View("Index");
        }
        public IActionResult Message()
        {
            ViewData["PageName"] = "Message";
            return View("Index");
        }
        public IActionResult About()
        {
            ViewData["PageName"] = "About";
            return View("Index");
        }
    }
}
