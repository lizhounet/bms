using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
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
        public SysUser GetLoginSysUser(SysUser user)
        {
            user.sysUserGroups = (from sug in db.SysUserGroup
                                  join sur in db.SysUuRelated
                                  on sug.UserGroupId equals sur.UserGroupId
                                  where sur.UserId.Equals(user.UserId)
                                  select new SysUserGroup
                                  {
                                      UserGroupId = sug.UserGroupId,
                                      UserGroupName = sug.UserGroupName,
                                      ParentUserGroupId = sug.ParentUserGroupId,
                                      CreateUserId = sug.CreateUserId,
                                      DeleteSign = sug.DeleteSign,
                                      CreateTime = sug.CreateTime,
                                      DeleteTime = sug.DeleteTime,
                                      EditTime = sug.EditTime,
                                      Note = sug.Note

                                  }).ToList();
            if (user.sysUserGroups != null)
            {
                foreach (var item in user.sysUserGroups)
                {
                    item.sysRoles = (from sur in db.SysUgrRelated
                                     join sr in db.SysRole
                                     on sur.RoleId equals sr.RoleId
                                     where sur.UserGroupId.Equals(item.UserGroupId)
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
            }
            user.sysRoles = (from sur in db.SysUrRelated
                             join sr in db.SysRole
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
