using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace Zhouli.DAL.Interface
{
    /// <summary>
    /// 权限管理接口
    /// </summary>
    public interface ISysAuthorityDAL : IBaseDAL<SysAuthority>
    {
        /// <summary>
        /// 获取角色对应的权限
        /// </summary>
        /// <param name="isAdmin">是否超级管理员</param>
        /// <param name="roles">角色集合</param>
        /// <param name="authorityType">权限类型</param>
        /// <returns></returns>
        List<SysAuthority> GetSysAuthorities(Boolean isAdmin,List<SysRole> roles,ZhouLiEnum.Enum_AuthorityType authorityType);
    }
}
