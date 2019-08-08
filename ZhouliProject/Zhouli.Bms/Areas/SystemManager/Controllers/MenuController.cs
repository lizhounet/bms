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
using Zhouli.CommonEntity;

namespace ZhouliSystem.Areas.SystemManager.Controllers
{
    [VerificationLogin]
    [Area("System")]
    public class MenuController : Controller
    {
        private readonly WholeInjection _injection;
        public MenuController(WholeInjection injection)
        {
            _injection = injection;
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
            var menuList = (List<SysMenuDto>)(_injection.GetT<ISysMenuBLL>().GetMenusBy(_injection.GetT<UserAccount>().GetUserInfo()).Data);

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
            int menuCount = _injection.GetT<ISysMenuBLL>().GetCount(t => t.MenuId.Equals(menuDto.MenuId));
            var user = _injection.GetT<UserAccount>().GetUserInfo();
            //添加
            if (menuCount == 0)
            {
                var AuthorityId = Guid.NewGuid();
                using (var tran = _injection.GetT<ZhouLiContext>().Database.BeginTransaction())
                {
                    int i = 0;
                    //添加权限
                    bResult = _injection.GetT<ISysAuthorityBLL>().Add(new SysAuthority
                    {
                        AuthorityType = (int)ZhouLiEnum.Enum_AuthorityType.Type_Menu,
                        AuthorityId = AuthorityId.ToString(),
                        CreateUserId = user.UserId,
                        CreateTime = DateTime.Now

                    });
                    if (bResult) i++;
                    bResult = _injection.GetT<ISysAmRelatedBLL>().Add(new SysAmRelated
                    {
                        AuthorityId = AuthorityId.ToString(),
                        MenuId = menuDto.MenuId.ToString(),

                    });
                    if (bResult) i++;
                    var menu = AutoMapper.Mapper.Map<SysMenu>(menuDto);
                    menu.CreateTime = DateTime.Now;
                    menu.CreateUserId = user.UserId;
                    bResult = _injection.GetT<ISysMenuBLL>().Add(menu);
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
                var menu = _injection.GetT<ISysMenuBLL>().GetModels(t => t.MenuId.Equals(menuDto.MenuId)).SingleOrDefault();
                menu.MenuName = menuDto.MenuName;
                menu.MenuIcon = menuDto.MenuIcon;
                menu.MenuSort = menuDto.MenuSort;
                menu.Note = menuDto.Note;
                menu.MenuUrl = menuDto.MenuUrl;
                menu.ParentMenuId = menuDto.ParentMenuId.ToString();
                menu.EditTime = DateTime.Now;
                bResult = _injection.GetT<ISysMenuBLL>().Update(menu);
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
            var messageModel = _injection.GetT<ISysMenuBLL>().DelMenu(MenuId);
            return Ok(new ResponseModel
            {
                RetMsg = messageModel.Message,
                RetCode = messageModel.Result ? StatesCode.success : StatesCode.failure
            });
        }

    }
}