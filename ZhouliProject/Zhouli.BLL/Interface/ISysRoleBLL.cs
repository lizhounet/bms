using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.Dto.ModelDto;
using Zhouli.DbEntity.Models;
using Zhouli.Common.ResultModel;
using Zhouli.DbEntity.Views;

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
        HandleResult<PageModel> GetRoleList(string page, string limit, string searchstr);
        #endregion
        #region 删除角色(批量删除)
        /// <summary>
        /// 删除用户(批量删除)
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        HandleResult<bool> DelRole(IEnumerable<string> RoleId);
        #endregion
        #region 为角色添加功能菜单
        /// <summary>
        /// 为角色添加功能菜单
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="menuDtos"></param>
        /// <returns></returns>
        HandleResult<bool> AddRoleMenu(string roleId, List<SysMenuDto> menuDtos);
        #endregion
        #region 获取角色所分配的用户
        /// <summary>
        /// 获取角色所分配的用户
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        HandleResult<PageModel> GetRoleUserList(string roleId, string page, string limit, string searchstr);
        #endregion
        #region 为角色分配用户
        /// <summary>
        /// 为角色分配用户
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userIds"></param>
        /// <returns></returns>
        HandleResult<bool> AssignmentRoleUser(string roleId, List<string> userIds);
        #endregion
        #region 取消用户角色
        /// <summary>
        /// 取消用户角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userIds"></param>
        /// <returns></returns>
        HandleResult<bool> CancelUserAssignment(string roleId, List<string> userIds);
        #endregion
        #region 获取角色所分配的用户组
        /// <summary>
        /// 获取角色所分配的用户组
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        HandleResult<PageModel> GetRoleUserGroupList(string roleId, string page, string limit, string searchstr);
        #endregion
        #region 为角色分配用户组
        /// <summary>
        /// 为角色分配用户组
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userGroupIds"></param>
        /// <returns></returns>
        HandleResult<bool> AssignmentRoleUserGroup(string roleId, List<string> userGroupIds);
        #endregion
        #region 取消用户组角色
        /// <summary>
        /// 取消用户组角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userGroupIds"></param>
        /// <returns></returns>
        HandleResult<bool> CancelUserGroupAssignment(string roleId, List<string> userGroupIds);
        #endregion
    }
}
