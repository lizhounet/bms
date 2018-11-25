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
using Microsoft.Extensions.Options;
using Zhouli.BLL;
using Zhouli.BLL.Interface;
using Zhouli.Common;
using Zhouli.DbEntity.Models;
using ZhouliSystem.Data;
using ZhouliSystem.Filters;
using ZhouliSystem.Models;

namespace ZhouliSystem.Controllers
{
    public class UserController : Controller
    {
        private WholeInjection injection;
        public UserController(WholeInjection injection)
        {
            this.injection = injection;
        }
        [ResponseCache(CacheProfileName = "default")]
        public IActionResult Login() {
            
            return View();
        }
        public IActionResult UserInfo()
        {
            ViewBag.UserInfo = AutoMapper.Mapper.Map<SysUserDto>(injection.GetT<ISysUserBLL>().GetModels(t => t.UserId.Equals(injection.GetT<UserAccount>().GetUserInfo().UserId)).SingleOrDefault());
            return View();
        }
        public IActionResult UserChagePwd() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]//防伪标记 预防坏蛋攻击
        public string UserChagePwd(string useroldpwd, string usernewpwd)
        {
            var response = new ResponseModel();
            var userlogin = injection.GetT<UserAccount>().GetUserInfo();
            if (!userlogin.UserPwd.Equals(MD5Encrypt.Get32MD5One(useroldpwd)))
            {
                response.Messages = "原密码不正确,请重新输入";
                response.StateCode = StatesCode.failure;
                return JsonHelper.ObjectToJson(response);
            }
            var user = injection.GetT<ISysUserBLL>().GetModels(t => t.UserId.Equals(userlogin.UserId)).SingleOrDefault();
            if (user != null)
            {
                user.UserPwd = MD5Encrypt.Get32MD5One(usernewpwd);
                if (injection.GetT<ISysUserBLL>().Update(user))
                {
                    response.Messages = "密码修改成功";
                    response.StateCode = StatesCode.success;
                    //密码修改成功 重新登录
                    injection.GetT<UserAccount>().Login(user);
                }
                else {
                    response.Messages = "密码修改失败";
                    response.StateCode = StatesCode.failure;
                }
            }
            else
            {
                response.Messages = "账户不存在,请联系管理员!";
                response.StateCode = StatesCode.failure;
            }
            return JsonHelper.ObjectToJson(response);
        }
        /// <summary>
        /// 后台登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]//防伪标记 预防坏蛋攻击
        public IActionResult UserLogin(string username, string password)
        {

            var message = new ResponseModel();
            var sysUsers = injection.GetT<ISysUserBLL>().GetModels(t =>
                (t.UserName.Equals(username) ||
                t.UserEmail.Equals(username) ||
                t.UserPhone.Equals(username) && t.DeleteSign.Equals((int)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted))
            ).FirstOrDefault();
            if (sysUsers == null)
            {
                message.StateCode = StatesCode.failure;
                message.Messages = "该账户不存在";
            }
            else
            {
                if (sysUsers.UserStatus.Equals((int)ZhouLiEnum.Enum_UserStatus.Status_Discontinuation))
                {
                    message.StateCode = StatesCode.failure;
                    message.Messages = "账户已停用,请联系管理员解除(17783042962)";
                }
                else if (!MD5Encrypt.Get32MD5Two(password).Equals(sysUsers.UserPwd))
                {
                    message.StateCode = StatesCode.failure;
                    message.Messages = "密码错误";
                }
                else
                {
                    var user = injection.GetT<ISysUserBLL>().GetLoginSysUser(sysUsers).Data;
                    injection.GetT<UserAccount>().Login(user);
                    message.Messages = "登陆成功";
                    message.JsonData = new { baseUrl = "/Home/Index" };
                }

            }
            return Json(message);
        }
    }
}