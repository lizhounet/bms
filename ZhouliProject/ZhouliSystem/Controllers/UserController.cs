#region 版权声明
/**************************************************************** 
 * 作    者：周黎 
 * CLR 版本：4.0.30319.42000 
 * 创建时间：2018/6/8 21:41:11 
 * 当前版本：1.0.0.1 
 *  
 * 描述说明： 
 * 
 * 修改历史： 
 * 
***************************************************************** 
 * Copyright @ ZhouLi 2018 All rights reserved 
 *┌──────────────────────────────────┐
 *│　此技术信息周黎的机密信息，未经本人书面同意禁止向第三方披露．　│
 *│　版权所有：周黎 　　　　　　　　　　　　　　│
 *└──────────────────────────────────┘
*****************************************************************/
#endregion
using System.Linq;
using DInjectionProvider;
using Microsoft.AspNetCore.Mvc;
using Zhouli.BLL.Interface;
using Zhouli.Common;

namespace ZhouliSystem.Controllers
{
    public class UserController : Controller
    {
        private WholeInjection injection;
        public UserController(WholeInjection injection)
        {
            this.injection = injection;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserLogin(string username, string password)
        {
            var message = new ResponseMessage();
            var sysUsers = injection.GetExamples<ISysUserBLL>().GetLoginSysUser(t => t.UserName.Equals(username));
            if (sysUsers == null)
            {
                message.StateCode = StatesCode.failure;
                message.Messages = "该用户不存在";
            }
            else
            {
                if (!MD5Encrypt.Get32MD5Two(password).Equals(sysUsers.UserPwd))
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