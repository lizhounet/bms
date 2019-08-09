using Zhouli.DI;
using Zhouli.DbEntity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using ZhouliSystem.Models;
using Zhouli.Common;

namespace ZhouliSystem.Data
{
    /// <summary>
    /// 关于用户信息的操作
    /// </summary>
    public class UserAccount
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IOptionsSnapshot<CustomConfiguration> _optionsSnapshot;
        public UserAccount(IHttpContextAccessor contextAccessor, IOptionsSnapshot<CustomConfiguration> optionsSnapshot)
        {
            _contextAccessor = contextAccessor;
            _optionsSnapshot = optionsSnapshot;
        }
        /// <summary>
        /// COOKIE名常量
        /// </summary>
        private const string USER_COOKIE_NAME = "UserLogin";
        /// <summary>
        /// 得到用户登录数据
        /// </summary>
        /// <returns></returns>
        public SysUser GetUserInfo()
        {
            var user = _contextAccessor.HttpContext.Session.GetSession<SysUser>(USER_COOKIE_NAME);
            return user ?? null;
        }
        /// <summary>
        /// 登录操作
        /// </summary>
        /// <returns></returns>
        public bool Login(SysUser user)
        {
            user.isAdministrctor = JudgeUserAdmin(user);
            _contextAccessor.HttpContext.Session.SetSession(USER_COOKIE_NAME, user);
            return true;
        }
        /// <summary>
        /// 判断用户是否超级管理员
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool JudgeUserAdmin(SysUser user)
        {
            var adminAccount = _optionsSnapshot.Value.adminAccount;
            return user.UserName.Equals(adminAccount);
        }
    }
}
