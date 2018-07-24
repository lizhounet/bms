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
        public IActionResult SelectMenuIcon() {
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
            //添加
            if (menuDto.MenuId == Guid.Empty)
            {
                bResult = injection.GetT<ISysMenuBLL>().Add(AutoMapper.Mapper.Map<SysMenu>(menuDto));
            }
            else
            {
                bResult = injection.GetT<ISysMenuBLL>().Update(AutoMapper.Mapper.Map<SysMenu>(menuDto));
            }
            return JsonHelper.ObjectToJson(new ResponseModel
            {
                StateCode = bResult ? StatesCode.success : StatesCode.failure,
                Messages = bResult ? "添加成功" : "添加失败"
            });
        }
    }
}