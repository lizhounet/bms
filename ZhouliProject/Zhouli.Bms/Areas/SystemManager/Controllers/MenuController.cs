using System;
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
using System.Collections;
using Zhouli.Dto.ModelDto;
using Zhouli.Common.ResultModel;
using Zhouli.Enum;

namespace ZhouliSystem.Areas.SystemManager.Controllers
{
    [VerificationLogin]
    [Area("System")]
    public class MenuController : Controller
    {
        private readonly ISysMenuBLL _sysMenuBLL;
        private readonly UserAccount _userAccount;
        private readonly ZhouLiContext _zhouLiContext;
        private readonly ISysAuthorityBLL _sysAuthorityBLL;
        private readonly ISysAmRelatedBLL _sysAmRelatedBLL;
        public MenuController(ISysMenuBLL sysMenuBLL,
            UserAccount userAccount,
            ZhouLiContext zhouLiContext,
            ISysAuthorityBLL sysAuthorityBLL,
            ISysAmRelatedBLL sysAmRelatedBLL)
        {
            _sysMenuBLL = sysMenuBLL;
            _userAccount = userAccount;
            _zhouLiContext = zhouLiContext;
            _sysAuthorityBLL = sysAuthorityBLL;
            _sysAmRelatedBLL = sysAmRelatedBLL;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SelectMenuIcon()
        {
            return View();
        }
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetMenuList()
        {
            var menuList = (List<SysMenuDto>)(_sysMenuBLL.GetMenusBy(_userAccount.GetUserInfo()).Data);

            return Ok(new ResponseModel
            {
                Data = menuList
            });
        }
        /// <summary>
        /// 添加/修改 一个菜单
        /// </summary>
        /// <param name="menuDto"></param>
        /// <returns></returns>
        public IActionResult AddOrEditMenu(SysMenuDto menuDto)
        {
            bool bResult = false;
            int menuCount = _sysMenuBLL.GetCount(t => t.MenuId.Equals(menuDto.MenuId));
            var user = _userAccount.GetUserInfo();
            //添加
            if (menuCount == 0)
            {
                var AuthorityId = Guid.NewGuid();
                using (var tran = _zhouLiContext.Database.BeginTransaction())
                {
                    int i = 0;
                    //添加权限
                    bResult = _sysAuthorityBLL.Add(new SysAuthority
                    {
                        AuthorityType = (int)AuthorityType.Type_Menu,
                        AuthorityId = AuthorityId.ToString(),
                        CreateUserId = user.UserId,
                        CreateTime = DateTime.Now

                    });
                    if (bResult) i++;
                    bResult = _sysAmRelatedBLL.Add(new SysAmRelated
                    {
                        AuthorityId = AuthorityId.ToString(),
                        MenuId = menuDto.MenuId.ToString(),

                    });
                    if (bResult) i++;
                    var menu = AutoMapper.Mapper.Map<SysMenu>(menuDto);
                    menu.CreateTime = DateTime.Now;
                    menu.CreateUserId = user.UserId;
                    bResult = _sysMenuBLL.Add(menu);
                    if (bResult) i++;
                    if (i == 3)
                        tran.Commit();
                    else
                    {
                        tran.Rollback();
                        bResult = false;
                    }

                }
            }
            else
            {
                var menu = _sysMenuBLL.GetModels(t => t.MenuId.Equals(menuDto.MenuId)).SingleOrDefault();
                menu.MenuName = menuDto.MenuName;
                menu.MenuIcon = menuDto.MenuIcon;
                menu.MenuSort = menuDto.MenuSort;
                menu.Note = menuDto.Note;
                menu.MenuUrl = menuDto.MenuUrl;
                menu.ParentMenuId = menuDto.ParentMenuId.ToString();
                menu.EditTime = DateTime.Now;
                bResult = _sysMenuBLL.Update(menu);
            }
            return Ok(new ResponseModel
            {
                RetCode = bResult ? StatesCode.success : StatesCode.failure,
                RetMsg = bResult ? "操作成功" : "操作失败"
            });
        }
        /// <summary>
        /// 删除菜单(同时删除权限表对应的菜单权限)
        /// </summary>
        /// <param name="MenuId"></param>
        /// <returns></returns>
        public IActionResult DelMenu(string MenuId)
        {
            var handleResult = _sysMenuBLL.DelMenu(MenuId);
            return Ok(new ResponseModel
            {
                RetMsg = handleResult.Msg,
                RetCode = handleResult.Result ? StatesCode.success : StatesCode.failure
            });
        }

    }
}