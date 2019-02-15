using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zhouli.BLL.Interface;
using Zhouli.Common;
using Zhouli.DI;
using ZhouliSystem.Filters;

namespace Zhouli.Bms.Areas.BlogManager.Controllers
{
    [VerificationLogin]
    [Area("Blog")]
    public class FriendshipLinkController : Controller
    {
        private readonly WholeInjection injection;
        public FriendshipLinkController(WholeInjection injection)
        {
            this.injection = injection;
        }

        public IActionResult Index()
        {
            return View();
        }
        #region 获取友情链接分页数据
        /// <summary>
        /// 获取友情链接分页数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="searchstr"></param>
        /// <returns></returns>
        public string GetFriendshipLinkList(string page, string limit, string searchstr)
        {
            var messageModel = injection.GetT<IBlogFriendshipLinkBLL>()
                 .GetFriendshipLinkList(page, limit, searchstr);
            return new
            {
                code = 0,
                msg = "获取成功",
                count = messageModel.Data.RowCount,
                data = messageModel.Data.Data
            }.Json();
        }
        #endregion
    }
}