using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Linq;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace Zhouli.DAL.Implements
{
    public class SysUserDAL : BaseDAL<SysUser>, ISysUserDAL
    {
        public SysUserDAL(ZhouLiContext db, IConfiguration configuration) : base(db, configuration) { }

        #region 设置登录用户的用户组,角色信息
        /// <summary>
        /// 设置用户的登录用户用户组,角色信息
        /// </summary>
        /// <returns></returns>
        public SysUser SetLoginSysUser(SysUser user)
        {
            user.sysUserGroup = (from t1 in _db.Set<SysUserGroup>() where t1.UserGroupId.Equals(user.UserGroupId) select t1).FirstOrDefault();
            if (user.sysUserGroup != null)
            {
                user.sysUserGroup.sysRoles = (from sur in _db.SysUgrRelated
                                 join sr in _db.SysRole
                                 on sur.RoleId equals sr.RoleId
                                 where sur.UserGroupId.Equals(user.sysUserGroup.UserGroupId)
                                 select new SysRole
                                 {
                                     RoleId = sr.RoleId,
                                     RoleName = sr.RoleName,
                                     CreateUserId = sr.CreateUserId,
                                     DeleteSign = sr.DeleteSign,
                                     CreateTime = sr.CreateTime,
                                     DeleteTime = sr.DeleteTime,
                                     EditTime = sr.EditTime,
                                     Note = sr.Note
                                 }
                             ).ToList();
            }
            user.sysRoles = (from sur in _db.SysUrRelated
                             join sr in _db.SysRole
                             on sur.RoleId equals sr.RoleId
                             where sur.UserId.Equals(user.UserId)
                             select new SysRole
                             {
                                 RoleId = sr.RoleId,
                                 RoleName = sr.RoleName,
                                 CreateUserId = sr.CreateUserId,
                                 DeleteSign = sr.DeleteSign,
                                 CreateTime = sr.CreateTime,
                                 DeleteTime = sr.DeleteTime,
                                 EditTime = sr.EditTime,
                                 Note = sr.Note
                             }
                                 ).ToList();
            return user;
        }
        #endregion
    }
}
