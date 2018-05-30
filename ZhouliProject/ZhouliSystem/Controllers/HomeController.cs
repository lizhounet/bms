using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZhouliSystem.Models;
using BLL.Interface;
using Model.Entity.Models;

namespace ZhouliSystem.Controllers
{
    public class HomeController : Controller
    {
        private IUsersBLL usersBLL;
        public HomeController(IUsersBLL usersBLL) {
            this.usersBLL = usersBLL;
        }
        public IActionResult Index()
        {
            bool bb = usersBLL.Add(new SysUsers
            {
                UserName="admin"
            });
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
