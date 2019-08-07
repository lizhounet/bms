#region 版权声明
/**************************************************************** 
 * 作    者：周黎 
 * CLR 版本：4.0.30319.42000 
 * 创建时间：2018/6/8 21:41:11 
 * 当前版本：1.0.0.1 
 *  
 * 描述说明： 
 * 
 * 修改历史： 
 * 
***************************************************************** 
 * Copyright @ ZhouLi 2018 All rights reserved 
 *┌──────────────────────────────────┐
 *│　此技术信息周黎的机密信息，未经本人书面同意禁止向第三方披露．　│
 *│　版权所有：周黎 　　　　　　　　　　　　　　│
 *└──────────────────────────────────┘
*****************************************************************/
#endregion
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZhouliSystem.Models;
using Zhouli.DbEntity.Models;
using Zhouli.DI;
using ZhouliSystem.Filters;
using ZhouliSystem.Data;
using Zhouli.BLL.Interface;

namespace ZhouliSystem.Controllers
{
    [VerificationLogin]
    public class HomeController : Controller
    {
        private readonly WholeInjection _injection;
        public HomeController(WholeInjection injection)
        {
            this._injection = injection;
        }
        public IActionResult Index()
        {
            var User = _injection.GetT<UserAccount>().GetUserInfo();
            return View(User);
        }
        public IActionResult Welcome()
        {
            return View();
        }
       
    }
}
