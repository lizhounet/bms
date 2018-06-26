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
    public class UserGroupController : Controller
    {
        private readonly WholeInjection injection;
        public UserGroupController(WholeInjection injection)
        {
            this.injection = injection;
        }
        public IActionResult Index()
        {
            return View();
        }
        public string GetUserGroupList(string page, string limit, string searchstr)
        {
            var messageModel = injection.GetExamples<ISysUserGroupBLL>()
                 .GetUserGroupList(page, limit, searchstr);
            return JsonHelper.ObjectToJson(new
            {
                code = 0,
                msg = "获取成功",
                count = messageModel.Data.RowCount,
                data = messageModel.Data.Data
            });
        }
    }
}