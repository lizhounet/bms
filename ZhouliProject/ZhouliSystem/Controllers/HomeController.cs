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
        private ISysUsersBLL usersBLL;
        private ISysUserGroupBLL userGroupBLL;
        public HomeController(ISysUsersBLL usersBLL, ISysUserGroupBLL userGroupBLL)
        {
            this.usersBLL = usersBLL;
            this.userGroupBLL = userGroupBLL;
        }
        public IActionResult Index()
        {
            string sss = usersBLL.show();
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
