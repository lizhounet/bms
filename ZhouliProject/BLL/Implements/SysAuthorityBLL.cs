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
        public MessageModel GetSysAuthorities(SysUser user, ZhouLiEnum.Enum_AuthorityType authorityType)
        {
            List<SysRole> roles = new List<SysRole>(user.sysRoles);
            if (user.sysUserGroup != null)
                roles.AddRange(user.sysUserGroup.sysRoles);
            return new MessageModel
            {
                Data = sysAuthorityDAL.GetSysAuthorities(user.isAdministrctor, roles.Distinct().ToList(), authorityType)
            };
        }
    }
}
