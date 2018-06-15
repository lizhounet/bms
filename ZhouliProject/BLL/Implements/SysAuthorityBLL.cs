using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Zhouli.BLL.Interface;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;

namespace Zhouli.BLL.Implements
{
    public class SysAuthorityBLL : BaseBLL<SysAuthority>, ISysAuthorityBLL
    {
        private ISysAuthorityDAL sysAuthorityDAL;
        /// <summary>
        /// 用于实例化父级，sysAuthorityDAL
        /// </summary>
        /// <param name="sysAuthorityDAL"></param>
        public SysAuthorityBLL(ISysAuthorityDAL sysAuthorityDAL) : base(sysAuthorityDAL)
        {
            this.sysAuthorityDAL = sysAuthorityDAL;
        }
        /// <summary>
        /// 获取用户权限集合
        /// </summary>
        /// <param name="user"></param>
        /// <param name="authorityType"></param>
        /// <returns></returns>
        public List<SysAuthority> GetSysAuthorities(SysUser user, AuthorityType authorityType)
        {
            Boolean isAdmin = user.UserName.Equals("zhouli") ? true : false;
            List<SysRole> roles = new List<SysRole>(user.sysRoles);
            foreach (var item in user.sysUserGroups)
            {
                roles.AddRange(item.sysRoles);
            }
            return sysAuthorityDAL.GetSysAuthorities(isAdmin, roles.Distinct().ToList(), authorityType);
        }
    }
}
