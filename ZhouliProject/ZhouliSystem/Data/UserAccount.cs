using DInjectionProvider;
using Zhouli.DbEntity.Models;
using Microsoft.AspNetCore.Http;

namespace ZhouliSystem.Data
{
    public class UserAccount
    {
        private WholeInjection injection;
        public UserAccount(WholeInjection injection)
        {
            this.injection = injection;
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
            var user = injection.GetHttpContext.HttpContext.Session.GetSession<SysUser>(USER_COOKIE_NAME);
            return user == null ? null : user;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public bool Login(SysUser user)
        {
            injection.GetHttpContext.HttpContext.Session.SetSession("UserLogin", user);
            return true;
        }
    }
}
