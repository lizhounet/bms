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
        public SysUser GetLoginSysUser(Expression<Func<SysUser, bool>> WhereLambda)
        {
            var user = db.SysUser.Where(WhereLambda).SingleOrDefault();
            var v = (from sug in db.SysUserGroup
                                  join sur in db.SysUuRelated
                                  on sug.UserGroupId equals sur.UserGroupId
                                  where sur.UserId.Equals(user.UserId)
                                  select sug
                                  ).ToList();
            if (user.sysUserGroups != null)
            {
                foreach (var item in user.sysUserGroups)
                {
                    item.sysRoles = (from sur in db.SysUgrRelated
                                     join sr in db.SysRole
                                     on sur.RoleId equals sr.RoleId
                                     where sur.UserGroupId.Equals(item.UserGroupId)
                                     select sr
                                 ).ToList();

                }
            }
            user.sysRoles = (from sur in db.SysUrRelated
                             join sr in db.SysRole
                             on sur.RoleId equals sr.RoleId
                             where sur.UserId.Equals(user.UserId)
                             select sr
                                 ).ToList();
            return user;
        }
        #endregion
    }
}
