using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZhouliSystem.Areas.SystemManager.Controllers
{
    [Area("SystemManager")]
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}