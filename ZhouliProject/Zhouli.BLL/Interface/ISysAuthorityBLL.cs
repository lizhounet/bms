using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.Common.ResultModel;
using Zhouli.DbEntity.Models;
using Zhouli.Enum;

namespace Zhouli.BLL.Interface
{
    /// <summary>
    /// 权限表Service
    /// </summary>
    public interface ISysAuthorityBLL : IBaseBLL<SysAuthority>
    {
        /// <summary>
        /// 获取用户的权限集合
        /// </summary>
        /// <param name="user">当前登陆用户</param>
        /// <param name="authorityType">权限类型</param>
        /// <returns></returns>
        HandleResult<List<SysAuthority>> GetSysAuthorities(SysUser user, AuthorityType authorityType);
        /// <summary>
        /// 获取角色的权限集合
        /// </summary>
        /// <param name="RoleId">角色Id</param>
        /// <param name="authorityType">权限类型</param>
        /// <returns></returns>
        HandleResult<List<SysAuthority>> GetRoleAuthoritieList(string RoleId, AuthorityType authorityType);
    }
}
