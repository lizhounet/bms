using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.DbEntity.Models;

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
        MessageModel GetMenusBy(SysUser user);
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="MenuId"></param>
        /// <returns></returns>
        MessageModel DelMenu(Guid MenuId);
    }
}
