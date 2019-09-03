using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.Common.ResultModel;
using Zhouli.DbEntity.Models;
using Zhouli.Dto.ModelDto;

namespace Zhouli.BLL.Interface
{
    /// <summary>
    /// 菜单表Service接口
    /// </summary>
    public interface ISysMenuBLL : IBaseBLL<SysMenu>
    {
        /// <summary>
        /// 根据用户获取功能菜单
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <returns></returns>
        HandleResult<List<SysMenuDto>> GetMenusBy(SysUser user);
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="MenuId"></param>
        /// <returns></returns>
        HandleResult<bool> DelMenu(string MenuId);
        /// <summary>
        /// 获取角色的权限菜单
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        HandleResult<List<SysMenuDto>> GetRoleMenuList(string RoleId);
    }
}
