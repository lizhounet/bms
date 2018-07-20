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
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <returns></returns>
        public string GetMenuList() {
            var menuList = (List<SysMenuDto>)(injection.GetT<ISysMenuBLL>().GetMenusBy(injection.GetT<UserAccount>().GetUserInfo()).Data);
            
            return JsonHelper.ObjectToJson(new ResponseModel
            {
                JsonData = menuList
            });
        }
    }
}