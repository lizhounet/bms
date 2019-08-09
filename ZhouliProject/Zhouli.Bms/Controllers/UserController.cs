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
using Zhouli.DI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Zhouli.BLL;
using Zhouli.BLL.Interface;
using Zhouli.Common;
using Zhouli.Dto.ModelDto;
using Zhouli.DbEntity.Models;
using ZhouliSystem.Data;
using ZhouliSystem.Filters;
using ZhouliSystem.Models;
using Microsoft.Extensions.Caching.Memory;
using IdentityModel.Client;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Zhouli.CommonEntity;
using Microsoft.Extensions.Configuration;

namespace ZhouliSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly ISysUserBLL _sysUserBLL;
        private readonly IMemoryCache _cache;
        private readonly IOptionsSnapshot<CustomConfiguration> _optionsSnapshot;
        private readonly UserAccount _userAccount;
        public UserController(ISysUserBLL sysUserBLL, IMemoryCache cache, IOptionsSnapshot<CustomConfiguration> optionsSnapshot, UserAccount userAccount)
        {
            _sysUserBLL = sysUserBLL;
            _cache = cache;
            _optionsSnapshot = optionsSnapshot;
            _userAccount = userAccount;
        }
        [ResponseCache(CacheProfileName = "default")]
        public IActionResult Login()
        {

            return View();
        }
        public IActionResult UserInfo()
        {
            ViewBag.UserInfo = AutoMapper.Mapper.Map<SysUserDto>(_sysUserBLL.GetModels(t => t.UserId.Equals(_userAccount.GetUserInfo().UserId)).SingleOrDefault());
            ViewBag.FileServiceAdress = _optionsSnapshot.Value.FileServiceAdress;
            return View();
        }
        public IActionResult UserChagePwd() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]//防伪标记 预防坏蛋攻击
        public IActionResult UserChagePwd(string useroldpwd, string usernewpwd)
        {
            var response = new ResponseModel();
            var userlogin = _userAccount.GetUserInfo();
            if (!userlogin.UserPwd.Equals(MD5Encrypt.Get32MD5One(useroldpwd)))
            {
                response.RetMsg = "原密码不正确,请重新输入";
                response.RetCode = StatesCode.failure;
                return Ok(response);
            }
            var user = _sysUserBLL.GetModels(t => t.UserId.Equals(userlogin.UserId)).SingleOrDefault();
            if (user != null)
            {
                user.UserPwd = MD5Encrypt.Get32MD5One(usernewpwd);
                if (_sysUserBLL.Update(user))
                {
                    response.RetMsg = "密码修改成功";
                    response.RetCode = StatesCode.success;
                    //密码修改成功 重新登录
                    _userAccount.Login(user);
                }
                else
                {
                    response.RetMsg = "密码修改失败";
                    response.RetCode = StatesCode.failure;
                }
            }
            else
            {
                response.RetMsg = "账户不存在,请联系管理员!";
                response.RetCode = StatesCode.failure;
            }

            return Ok(response);
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
            var sysUsers = _sysUserBLL.GetModels(t =>
                (t.UserName.Equals(username) ||
                t.UserEmail.Equals(username) ||
                t.UserPhone.Equals(username) && t.DeleteSign.Equals((int)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted))
            ).FirstOrDefault();
            if (sysUsers == null)
            {
                message.RetCode = StatesCode.failure;
                message.RetMsg = "该账户不存在";
            }
            else
            {
                if (sysUsers.UserStatus.Equals((int)ZhouLiEnum.Enum_UserStatus.Status_Discontinuation))
                {
                    message.RetCode = StatesCode.failure;
                    message.RetMsg = "账户已停用,请联系管理员解除(17783042962)";
                }
                else if (!MD5Encrypt.Get32MD5Two(password).Equals(sysUsers.UserPwd))
                {
                    message.RetCode = StatesCode.failure;
                    message.RetMsg = "密码错误";
                }
                else
                {
                    var user = _sysUserBLL.GetLoginSysUser(sysUsers).Data;
                    _userAccount.Login(user);
                    message.RetMsg = "登陆成功";
                    message.Data = new { BaseUrl = "/Home/Index" };
                }

            }
            return Ok(message);
        }

    }
}