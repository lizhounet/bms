﻿using System;
using System.Collections.Generic;
using System.Linq;
using Zhouli.DI;
using Microsoft.AspNetCore.Mvc;
using Zhouli.Common;
using Zhouli.BLL;
using Zhouli.BLL.Interface;
using Zhouli.DbEntity.Models;
using ZhouliSystem.Data;
using ZhouliSystem.Models;
using ZhouliSystem.Filters;
using Zhouli.Dto.ModelDto;
using Zhouli.CommonEntity;

namespace ZhouliSystem.Areas.SystemManager.Controllers
{
    [VerificationLogin]
    [Area("System")]
    public class RoleController : Controller
    {
        private readonly WholeInjection _injection;
        public RoleController(WholeInjection injection)
        {
            _injection = injection;
        }
        #region 视图部分
        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index() => View();
        /// <summary>
        /// 添加角色视图
        /// </summary>
        /// <returns></returns>
        public IActionResult RoleAdd() => View();
        /// <summary>
        /// 角色分配给用户
        /// </summary>
        /// <returns></returns>
        public IActionResult RoleAssignmentUser() => View();
        /// <summary>
        /// 角色分配给用户组
        /// </summary>
        /// <returns></returns>
        public IActionResult RoleAssignmentUserGroup() => View();
        /// <summary>
        /// 选择用户
        /// </summary>
        /// <returns></returns>
        public IActionResult SelectUser() => View();
        /// <summary>
        /// 选择用户组
        /// </summary>
        /// <returns></returns>
        public IActionResult SelectUserGroup() => View();
        #endregion
        #region 获取分页角色数据
        /// <summary>
        /// 获取分页角色数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="searchstr"></param>
        /// <returns></returns>
        public IActionResult GetRoleList(string page, string limit, string searchstr)
        {
            var messageModel = _injection.GetT<ISysRoleBLL>()
                 .GetRoleList(page, limit, searchstr);
            return Ok(new
            {
                code = 0,
                msg = "获取成功",
                count = messageModel.Data.RowCount,
                data = messageModel.Data.Data
            });
        }
        #endregion
        #region 添加/修改角色
        /// <summary>
        /// 添加/修改角色
        /// </summary>
        /// <param name="userGroupDto"></param>
        /// <param name="objCheckMenus">角色的菜单权限</param>
        /// <returns></returns>
        public IActionResult AddorEditRole(SysRoleDto roleDto, List<SysMenuDto> objCheckMenus)
        {
            bool bResult = true;
            string sMessage = "保存成功";
            var roleBLL = _injection.GetT<ISysRoleBLL>();
            var role = AutoMapper.Mapper.Map<SysRole>(roleDto);
            if (roleBLL.GetCount(t => t.RoleName.Equals(role.RoleName) && !t.RoleId.Equals(role.RoleId) && t.DeleteSign.Equals((int)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted)) > 0)
            {
                sMessage = "角色名称不能重复";
                bResult = !bResult;
            }
            else
            {
                //添加
                if (string.IsNullOrEmpty(role.RoleId))
                {

                    role.DeleteSign = (Int32)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted;
                    role.CreateUserId = _injection.GetT<UserAccount>().GetUserInfo().UserId;
                    role.CreateTime = DateTime.Now;
                    bResult = roleBLL.Add(role);
                    bResult = roleBLL.AddRoleMenu(role.RoleId, objCheckMenus).Result;
                }
                else//修改
                {
                    var userRole_Edit = roleBLL.GetModels(t => t.RoleId.Equals(role.RoleId)).SingleOrDefault();
                    userRole_Edit.RoleName = role.RoleName;
                    userRole_Edit.EditTime = DateTime.Now;
                    userRole_Edit.Note = role.Note;
                    bResult = roleBLL.Update(userRole_Edit);
                    bResult = roleBLL.AddRoleMenu(userRole_Edit.RoleId, objCheckMenus).Result;
                }
            }
            return Ok(new ResponseModel
            {
                RetCode = bResult ? StatesCode.success : StatesCode.failure,
                RetMsg = sMessage
            });
        }
        #endregion
        #region 批量删除角色
        /// <summary>
        /// 批量删除角色
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public IActionResult DelRole(List<string> RoleId)
        {
            var resModel = new ResponseModel();
            //此处删除进行逻辑删除
            MessageModel model = _injection.GetT<ISysRoleBLL>().DelRole(RoleId);
            resModel.RetCode = model.Result ? StatesCode.success : StatesCode.failure;
            resModel.RetMsg = model.Message;
            return Ok(resModel);
        }
        #endregion
        #region 获取角色的功能菜单
        /// <summary>
        /// 获取角色的功能菜单
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public IActionResult GetRoleMenuList(string RoleId)
        {
            //用户可以操作的菜单
            var menuList = (List<SysMenuDto>)(_injection.GetT<ISysMenuBLL>().GetMenusBy(_injection.GetT<UserAccount>().GetUserInfo()).Data);
            //角色所拥有的菜单
            var roleMenuList = string.IsNullOrEmpty(RoleId) ? new List<SysMenuDto>() : ((List<SysMenuDto>)_injection.GetT<ISysMenuBLL>().GetRoleMenuList(RoleId).Data);
            return Ok(new ResponseModel
            {
                Data = new
                {
                    MenuList = menuList,
                    RoleMenuList = roleMenuList
                }
            });
        }
        #endregion
        #region 获取角色所分配的用户
        public IActionResult GetRoleUserList(string RoleId, string page, string limit, string searchstr)
        {
            var messageModel = _injection.GetT<ISysRoleBLL>().GetRoleUserList(RoleId, page, limit, searchstr);
            return Ok(new
            {
                code = 0,
                msg = "获取成功",
                count = messageModel.Data.RowCount,
                data = messageModel.Data.Data
            });
        }
        #endregion
        #region 为角色分配用户
        /// <summary>
        /// 为角色分配用户
        /// </summary>
        /// <param name="RoleId"></param>
        /// <param name="UserIds"></param>
        /// <returns></returns>
        public IActionResult AssignmentRoleUser(string RoleId, List<string> UserIds)
        {
            var messageModel = _injection.GetT<ISysRoleBLL>().AssignmentRoleUser(RoleId, UserIds);
            return Ok(new ResponseModel
            {
                RetMsg = messageModel.Message,
                RetCode = messageModel.Result ? StatesCode.success : StatesCode.failure
            });
        }
        #endregion
        #region 取消用户角色
        /// <summary>
        /// 取消用户角色
        /// </summary>
        /// <param name="RoleId"></param>
        /// <param name="UserIds"></param>
        public IActionResult CancelUserAssignment(string RoleId, List<string> UserIds)
        {
            var messageModel = _injection.GetT<ISysRoleBLL>().CancelUserAssignment(RoleId, UserIds);
            return Ok(new ResponseModel
            {
                RetMsg = messageModel.Message,
                RetCode = messageModel.Result ? StatesCode.success : StatesCode.failure
            });
        }
        #endregion
        #region 获取角色所分配的用户组
        /// <summary>
        /// 获取角色所分配的用户组
        /// </summary>
        /// <param name="RoleId"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="searchstr"></param>
        /// <returns></returns>
        public IActionResult GetRoleUserGroupList(string RoleId, string page, string limit, string searchstr)
        {
            var messageModel = _injection.GetT<ISysRoleBLL>().GetRoleUserGroupList(RoleId, page, limit, searchstr);
            return Ok(new
            {
                code = 0,
                msg = "获取成功",
                count = messageModel.Data.RowCount,
                data = messageModel.Data.Data
            });
        }
        #endregion
        #region 为角色分配用户组
        /// <summary>
        /// 为角色分配用户
        /// </summary>
        /// <param name="RoleId"></param>
        /// <param name="UserGroupIds"></param>
        /// <returns></returns>
        public IActionResult AssignmentRoleUserGroup(string RoleId, List<string> UserGroupIds)
        {
            var messageModel = _injection.GetT<ISysRoleBLL>().AssignmentRoleUserGroup(RoleId, UserGroupIds);
            return Ok(new ResponseModel
            {
                RetMsg = messageModel.Message,
                RetCode = messageModel.Result ? StatesCode.success : StatesCode.failure
            });
        }
        #endregion
        #region 取消用户组角色
        /// <summary>
        /// 取消用户角色
        /// </summary>
        /// <param name="RoleId"></param>
        /// <param name="UserGroupIds"></param>
        public IActionResult CancelUserGroupAssignment(string RoleId, List<string> UserGroupIds)
        {
            var messageModel = _injection.GetT<ISysRoleBLL>().CancelUserGroupAssignment(RoleId, UserGroupIds);
            return Ok(new ResponseModel
            {
                RetMsg = messageModel.Message,
                RetCode = messageModel.Result ? StatesCode.success : StatesCode.failure
            });
        }
        #endregion
    }
}