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
    public class BlogLableController : Controller
    {
        private readonly WholeInjection injection;
        public BlogLableController(WholeInjection injection)
        {
            this.injection = injection;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BlogLableAdd()
        {
            return View();
        }
        #region 获取博客标签分页数据
        /// <summary>
        /// 获取博客标签分页数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="searchstr"></param>
        /// <returns></returns>
        public string GetBlogLableList(string page, string limit, string searchstr)
        {
            var messageModel = injection.GetT<IBlogLableBLL>()
                 .GetBlogLableList(page, limit, searchstr);
            return new
            {
                code = 0,
                msg = "获取成功",
                count = messageModel.Data.RowCount,
                data = messageModel.Data.Data
            }.Json();
        }
        #endregion
        #region 添加博客标签链接
        /// <summary>
        /// 添加博客标签链接
        /// </summary>
        /// <param name="bl"></param>
        /// <returns></returns>
        public string AddorUpdateBlogLable(BlogLable bl)
        {
            var resModel = new ResponseModel();
            MessageModel model = injection.GetT<IBlogLableBLL>().AddorEditBlogLable(bl, injection.GetT<UserAccount>().GetUserInfo().UserId);
            resModel.StateCode = model.Result ? StatesCode.success : StatesCode.failure;
            resModel.Messages = model.Message;
            resModel.JsonData = model.Data;
            return resModel.Json();
        }
        #endregion

        #region 删除博客标签链接
        /// <summary>
        /// 删除博客标签链接
        /// </summary>
        /// <param name="blogLableId"></param>
        /// <returns></returns>
        public string DeleteBlogLable(List<string> blogLableId)
        {
            var resModel = new ResponseModel();
            //此处删除进行逻辑删除
            MessageModel model = injection.GetT<IBlogLableBLL>().DelBlogLable(blogLableId);
            resModel.StateCode = model.Result ? StatesCode.success : StatesCode.failure;
            resModel.Messages = model.Message;
            return resModel.Json();
        }
        #endregion
    }
}