using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZhouliSystem.Models;
using Zhouli.BLL.Interface;
using Zhouli.Entity.Models;
using DInjectionProvider;

namespace ZhouliSystem.Controllers
{
    public class HomeController : Controller
    {
        private IDInjectionProvider provider;
        public HomeController(IDInjectionProvider _provider)
        {
            this.provider = _provider;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult welcome()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
