using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.DbEntity.Models;

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
        /// <param name="authorityType"></param>
        /// <returns></returns>
        List<SysAuthority> GetSysAuthorities(SysUser user, ZhouLiEnum.Enum_AuthorityType authorityType);
    }
}
