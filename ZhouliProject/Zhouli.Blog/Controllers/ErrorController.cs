using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("[controller]")]
    public class ErrorController : Controller
    {
        [Route("404.html")]
        public IActionResult _404()
        {
            return View();
        }
        [Route("ie.html")]
        public IActionResult _ie()
        {
            return View();
        }
    }
}