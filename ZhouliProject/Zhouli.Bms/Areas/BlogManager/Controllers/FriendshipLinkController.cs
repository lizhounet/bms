using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zhouli.BLL;
using Zhouli.BLL.Interface;
using Zhouli.Common;
using Zhouli.DbEntity.Models;
using Zhouli.DI;
using ZhouliSystem.Data;
using ZhouliSystem.Filters;
using ZhouliSystem.Models;

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
        public IActionResult FriendshipLinkAdd()
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
        #region 添加友情链接
        /// <summary>
        /// 添加友情链接
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        public string AddorUpdateFriendshipLink(BlogFriendshipLink blog)
        {
            var resModel = new ResponseModel();
            MessageModel model = injection.GetT<IBlogFriendshipLinkBLL>().AddorEditFriendshipLink(blog, injection.GetT<UserAccount>().GetUserInfo().UserId);
            resModel.StateCode = model.Result ? StatesCode.success : StatesCode.failure;
            resModel.Messages = model.Message;
            resModel.JsonData = model.Data;
            return resModel.Json();
        }
        #endregion

        #region 删除友情链接
        /// <summary>
        /// 删除友情链接
        /// </summary>
        /// <param name="FriendshipLinkId"></param>
        /// <returns></returns>
        public string DeleteFriendshipLink(List<string> FriendshipLinkId)
        {
            var resModel = new ResponseModel();
            //此处删除进行逻辑删除
            MessageModel model = injection.GetT<IBlogFriendshipLinkBLL>().DelFriendshipLink(FriendshipLinkId);
            resModel.StateCode = model.Result ? StatesCode.success : StatesCode.failure;
            resModel.Messages = model.Message;
            return resModel.Json();
        }
        #endregion
    }
}