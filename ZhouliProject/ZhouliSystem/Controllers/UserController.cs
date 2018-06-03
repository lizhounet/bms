using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Interface;
using Zhouli.Common;

namespace ZhouliSystem.Controllers
{
    public class UserController : Controller
    {
        private ISysUsersBLL sysUsersBLL;
        public UserController(ISysUsersBLL sysUsersBLL)
        {
            this.sysUsersBLL = sysUsersBLL;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserLogin(string username, string password)
        {
            var message = new ResponseMessage();
            var sysUsers = sysUsersBLL.GetModels(t => t.UserName.Equals(username)).FirstOrDefault();
            if (sysUsers == null)
            {
                message.StateCode = StatesCode.success;
                message.Messages = "该用户不存在";
            }
            else
            {
                if (!MD5Encrypt.Get32MD5Two(password).Equals(sysUsers.UserPwd))
                {
                    message.StateCode = StatesCode.success;
                    message.Messages = "密码错误";
                }
                else
                {

                }

            }
            return Json(message);
        }
    }
}