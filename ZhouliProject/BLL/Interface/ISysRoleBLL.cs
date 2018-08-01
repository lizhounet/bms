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
        MessageModel AddRoleMenu(Guid RoleId, List<SysMenuDto> menuDtos);
        #endregion
        #region 获取角色所分配的用户
        /// <summary>
        /// 获取角色所分配的用户
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        MessageModel GetRoleUserList(Guid RoleId, string page, string limit, string searchstr);
        #endregion
        #region 为角色分配用户
        /// <summary>
        /// 为角色分配用户
        /// </summary>
        /// <param name="RoleId"></param>
        /// <param name="UserIds"></param>
        /// <returns></returns>
        MessageModel AssignmentRoleUser(Guid RoleId, List<Guid> UserIds);
        #endregion
        #region 取消用户角色
        /// <summary>
        /// 取消用户角色
        /// </summary>
        /// <param name="RoleId"></param>
        /// <param name="UserIds"></param>
        /// <returns></returns>
        MessageModel CancelUserAssignment(Guid RoleId, List<Guid> UserIds);
        #endregion
        #region 获取角色所分配的用户组
        /// <summary>
        /// 获取角色所分配的用户组
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        MessageModel GetRoleUserGroupList(Guid RoleId, string page, string limit, string searchstr);
        #endregion
        #region 为角色分配用户组
        /// <summary>
        /// 为角色分配用户组
        /// </summary>
        /// <param name="RoleId"></param>
        /// <param name="UserGroupIds"></param>
        /// <returns></returns>
        MessageModel AssignmentRoleUserGroup(Guid RoleId, List<Guid> UserGroupIds);
        #endregion
        #region 取消用户组角色
        /// <summary>
        /// 取消用户组角色
        /// </summary>
        /// <param name="RoleId"></param>
        /// <param name="UserIds"></param>
        /// <returns></returns>
        MessageModel CancelUserGroupAssignment(Guid RoleId, List<Guid> UserGroupIds);
        #endregion
    }
}
