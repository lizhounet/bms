using System;
using System.Collections.Generic;
using System.Linq;
using DInjectionProvider;
using Microsoft.AspNetCore.Mvc;
using Zhouli.Common;
using Zhouli.BLL;
using Zhouli.BLL.Interface;
using Zhouli.DbEntity.Models;
using ZhouliSystem.Data;
using ZhouliSystem.Models;
using ZhouliSystem.Filters;
using System.Collections;

namespace ZhouliSystem.Areas.SystemManager.Controllers
{
    [VerificationLogin]
    [Area("System")]
    public class RoleController : Controller
    {
        private readonly WholeInjection injection;
        public RoleController(WholeInjection injection)
        {
            this.injection = injection;
        }
        #region 视图部分
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 添加角色视图
        /// </summary>
        /// <returns></returns>
        public IActionResult RoleAdd() => View();
        /// <summary>
        /// 角色分配
        /// </summary>
        /// <returns></returns>
        public IActionResult RoleAssignment() => View();
        #endregion
        #region 获取分页角色数据
        /// <summary>
        /// 获取分页角色数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="searchstr"></param>
        /// <returns></returns>
        public string GetRoleList(string page, string limit, string searchstr)
        {
            var messageModel = injection.GetT<ISysRoleBLL>()
                 .GetRoleList(page, limit, searchstr);
            return JsonHelper.ObjectToJson(new
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
        public string AddorEditRole(SysRoleDto roleDto, List<SysMenuDto> objCheckMenus)
        {
            bool bResult = true;
            string sMessage = "保存成功";
            var roleBLL = injection.GetT<ISysRoleBLL>();
            var role = AutoMapper.Mapper.Map<SysRole>(roleDto);
            if (roleBLL.GetCount(t => t.RoleName.Equals(role.RoleName) && !t.RoleId.Equals(role.RoleId) && t.DeleteSign.Equals((int)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted)) > 0)
            {
                sMessage = "角色名称不能重复";
                bResult = !bResult;
            }
            else
            {
                //添加
                if (role.RoleId.Equals(Guid.Empty))
                {

                    role.DeleteSign = (Int32)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted;
                    role.CreateUserId = injection.GetT<UserAccount>().GetUserInfo().UserId;
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
            return JsonHelper.ObjectToJson(new ResponseModel
            {
                StateCode = bResult ? StatesCode.success : StatesCode.failure,
                Messages = sMessage
            });
        }
        #endregion
        #region 批量删除角色
        /// <summary>
        /// 批量删除角色
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public string DelRole(List<Guid> RoleId)
        {
            var resModel = new ResponseModel();
            //此处删除进行逻辑删除
            MessageModel model = injection.GetT<ISysRoleBLL>().DelRole(RoleId);
            resModel.StateCode = model.Result ? StatesCode.success : StatesCode.failure;
            resModel.Messages = model.Message;
            return JsonHelper.ObjectToJson(resModel);
        }
        #endregion
        #region 获取角色的功能菜单
        /// <summary>
        /// 获取角色的功能菜单
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public string GetRoleMenuList(Guid RoleId)
        {
            //用户可以操作的菜单
            var menuList = (List<SysMenuDto>)(injection.GetT<ISysMenuBLL>().GetMenusBy(injection.GetT<UserAccount>().GetUserInfo()).Data);
            //角色所拥有的菜单
            var roleMenuList = RoleId.Equals(Guid.Empty) ? new List<SysMenuDto>() : ((List<SysMenuDto>)injection.GetT<ISysMenuBLL>().GetRoleMenuList(RoleId).Data);
            return JsonHelper.ObjectToJson(new ResponseModel
            {
                JsonData = new
                {
                    MenuList = menuList,
                    RoleMenuList = roleMenuList
                }
            });
        }
        #endregion
    }
}