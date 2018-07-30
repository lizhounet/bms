using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.DbEntity.Models;

namespace Zhouli.BLL.Interface
{
    public interface ISysRoleBLL : IBaseBLL<SysRole>
    {
        #region 获取角色列表
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="limit">页容量</param>
        /// <param name="searchstr">搜索内容</param>
        /// <returns></returns>
        MessageModel GetRoleList(string page, string limit, string searchstr);
        #endregion
        #region 删除角色(批量删除)
        /// <summary>
        /// 删除用户(批量删除)
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        MessageModel DelRole(IEnumerable<Guid> RoleId);
        #endregion
        #region 为角色添加功能菜单
        /// <summary>
        /// 为角色添加功能菜单
        /// </summary>
        /// <param name="RoleId"></param>
        /// <param name="menuDtos"></param>
        /// <returns></returns>
        MessageModel AddRoleMenu(Guid RoleId,List<SysMenuDto> menuDtos);
        #endregion
    }
}
