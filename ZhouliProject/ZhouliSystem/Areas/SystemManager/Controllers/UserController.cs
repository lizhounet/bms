using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DInjectionProvider;
using Microsoft.AspNetCore.Mvc;
using Zhouli.BLL.Interface;
using Zhouli.Common;

namespace ZhouliSystem.Areas.SystemManager.Controllers
{
    [Area("System")]
    public class UserController : Controller
    {
        private readonly WholeInjection injection;
        public UserController(WholeInjection injection)
        {
            this.injection = injection;
        }
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="limit">页容量</param>
        /// <param name="searchstr">搜索内容</param>
        /// <returns></returns>
        public string GetUserList(string page, string limit, string searchstr)
        {
            var pageModel = injection.GetExamples<ISysUserBLL>()
                .GetUserList(page, limit, searchstr);
            return JsonHelper.ObjectToJson(new
            {
                code = 0,
                msg = "获取成功",
                count = pageModel.RowCount,
                data = pageModel.Data
            });
        }
    }
}