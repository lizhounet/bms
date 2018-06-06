using Zhouli.DAL.Interface;
using Zhouli.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Linq;

namespace Zhouli.DAL.Implements
{
    public class SysUsersDAL : BaseDAL<SysUsers>, ISysUsersDAL
    {
        private GRWEBSITEContext gRWEBSITEContext;
        public SysUsersDAL(GRWEBSITEContext gRWEBSITEContext) : base(gRWEBSITEContext)
        {
            this.gRWEBSITEContext = gRWEBSITEContext;
        }
        #region
        /// <summary>
        /// 获取需要登录的用户所有信息
        /// </summary>
        /// <returns></returns>
        public SysUsersLogin GetLoginSysUsers(Expression<Func<SysUsers, bool>> WhereLambda)
        {
            var users = (from user in gRWEBSITEContext.SysUsers
                         join uu in gRWEBSITEContext.SysUuRelated
                         on user.UserId equals uu.UserId into result
                         from r in result.DefaultIfEmpty()
                         select new
                         {
                             user,
                             sysUserGroups = (from userGroup in gRWEBSITEContext.SysUserGroup
                                              where userGroup.UserGroupId.Equals(r.UserGroupId)
                                              select userGroup).ToList()

                         }).ToList().FirstOrDefault();

            return new SysUsersLogin
            {
                //sysUsers = users.user,
                //sysUserGroups = users.sysUserGroups
            };
        }
        #endregion
    }
}
