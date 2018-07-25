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
    public class MenuController : Controller
    {
        private readonly WholeInjection injection;
        public MenuController(WholeInjection injection)
        {
            this.injection = injection;
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
        public string GetMenuList()
        {
            var menuList = (List<SysMenuDto>)(injection.GetT<ISysMenuBLL>().GetMenusBy(injection.GetT<UserAccount>().GetUserInfo()).Data);

            return JsonHelper.ObjectToJson(new ResponseModel
            {
                JsonData = menuList
            });
        }
        /// <summary>
        /// 添加/修改 一个菜单
        /// </summary>
        /// <param name="menuDto"></param>
        /// <returns></returns>
        public string AddOrEditMenu(SysMenuDto menuDto)
        {
            bool bResult = false;
            int menuCount = injection.GetT<ISysMenuBLL>().GetCount(t => t.MenuId.Equals(menuDto.MenuId));
            //添加
            if (menuCount == 0)
            {
                var AuthorityId = Guid.NewGuid();
                using (var tran = injection.GetT<ZhouLiContext>().Database.BeginTransaction())
                {
                    int i = 0;
                    //添加权限
                    bResult = injection.GetT<ISysAuthorityBLL>().Add(new SysAuthority
                    {
                        AuthorityType = (int)ZhouLiEnum.Enum_AuthorityType.Type_Menu,
                        AuthorityId = AuthorityId
                    });
                    if (bResult) i++;
                    bResult = injection.GetT<ISysAmRelatedBLL>().Add(new SysAmRelated
                    {
                        AuthorityId = AuthorityId,
                        MenuId = menuDto.MenuId
                    });
                    if (bResult) i++;
                    bResult = injection.GetT<ISysMenuBLL>().Add(AutoMapper.Mapper.Map<SysMenu>(menuDto));
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
                var menu = injection.GetT<ISysMenuBLL>().GetModels(t => t.MenuId.Equals(menuDto.MenuId)).SingleOrDefault();
                menu.MenuName = menuDto.MenuName;
                menu.MenuIcon = menuDto.MenuIcon;
                menu.MenuSort = menuDto.MenuSort;
                menu.Note = menuDto.Note;
                menu.ParentMenuId = menuDto.ParentMenuId;
                bResult = injection.GetT<ISysMenuBLL>().Update(menu);
            }
            return JsonHelper.ObjectToJson(new ResponseModel
            {
                StateCode = bResult ? StatesCode.success : StatesCode.failure,
                Messages = bResult ? "添加成功" : "添加失败"
            });
        }
        /// <summary>
        /// 删除菜单(同时删除权限表对应的菜单权限)
        /// </summary>
        /// <param name="MenuId"></param>
        /// <returns></returns>
        public string DelMenu(Guid MenuId)
        {
            var messageModel = injection.GetT<ISysMenuBLL>().DelMenu(MenuId);
            return JsonHelper.ObjectToJson(new ResponseModel
            {
                Messages = messageModel.Message,
                StateCode = messageModel.Result ? StatesCode.success : StatesCode.failure
            });
        }
    }
}