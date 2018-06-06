﻿using System.Linq;
using DInjectionProvider;
using Microsoft.AspNetCore.Mvc;
using Zhouli.BLL.Interface;
using Zhouli.Common;

namespace ZhouliSystem.Controllers
{
    public class UserController : Controller
    {
        private IDInjectionProvider provider;
        public UserController(IDInjectionProvider _provider)
        {
            this.provider = _provider;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserLogin(string username, string password)
        {
            var message = new ResponseMessage();
            var sysUsers = provider.GetExamples<ISysUsersBLL>().GetLoginSysUsers(t => t.UserName.Equals(username));
            if (sysUsers == null)
            {
                message.StateCode = StatesCode.failure;
                message.Messages = "该用户不存在";
            }
            else
            {
                if (!MD5Encrypt.Get32MD5Two(password).Equals(sysUsers.sysUsers.UserPwd))
                {
                    message.StateCode = StatesCode.failure;
                    message.Messages = "密码错误";
                }
                else
                {
                    HttpContext.Session.SetSession("UserLogin", sysUsers);
                    message.StateCode = StatesCode.success;
                    message.Messages = "登陆成功";
                    message.JsonData = new { baseUrl = "/Home/Index" };
                }

            }
            return Json(message);
        }
    }
}