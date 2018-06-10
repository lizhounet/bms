using Zhouli.DAL.Interface;
using Zhouli.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Linq;

namespace Zhouli.DAL.Implements
{
    public class SysUserDAL : BaseDAL<SysUser>, ISysUserDAL
    {
        private ZhouLiContext db;
        public SysUserDAL(ZhouLiContext db) : base(db)
        {
            this.db = db;
        }
        #region 获取需要登录的用户所有信息
        /// <summary>
        /// 获取需要登录的用户所有信息
        /// </summary>
        /// <returns></returns>
        public SysUserLogin GetLoginSysUser(Expression<Func<SysUser, bool>> WhereLambda)
        {
            var users = (from user in db.Set<SysUser>().Where(WhereLambda)
                         join uu in db.Set<SysUuRelated>() on user.UserId equals uu.UserId
                         select new
                         {
                             sysUsers = user,
                             sysUserGroups = (from userGroup in db.Set<SysUserGroup>()
                                              where userGroup.UserGroupId == uu.UserGroupId
                                              select userGroup).ToList()
                         }).FirstOrDefault();
            return users is null ? null : new SysUserLogin
            {
                sysUsers = users.sysUsers,
                sysUserGroups = users.sysUserGroups
            };
        }
        #endregion
    }
}
