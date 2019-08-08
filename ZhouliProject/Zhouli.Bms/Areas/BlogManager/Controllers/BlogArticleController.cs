using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Zhouli.BLL;
using Zhouli.BLL.Interface;
using Zhouli.CommonEntity;
using Zhouli.DbEntity.Models;
using Zhouli.DI;
using ZhouliSystem.Filters;
using ZhouliSystem.Models;

namespace Zhouli.Bms.Areas.BlogManager.Controllers
{
    [VerificationLogin]
    [Area("Blog")]
    public class BlogArticleController : Controller
    {
        private readonly WholeInjection _injection;
        public BlogArticleController(WholeInjection injection)
        {
            _injection = injection;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BlogArticleAdd()
        {
            ViewBag.FileServiceAdress = _injection.GetT<IOptionsSnapshot<CustomConfiguration>>().Value.FileServiceAdress;
            ViewBag.ListBlogLable = _injection.GetT<IBlogLableBLL>().GetModels(t => true);
            return View();
        }
        #region 添加博客文章
        /// <summary>
        /// 添加博客标签链接
        /// </summary>
        /// <param name="bl"></param>
        /// <returns></returns>
        public IActionResult AddorUpdateBlogArticle(BlogArticleDto blogArticleDto)
        {
            var resModel = new ResponseModel();
            MessageModel model = _injection.GetT<IBlogArticleBLL>().AddOrUpdateArticlelist(blogArticleDto);
            resModel.RetCode = model.Result ? StatesCode.success : StatesCode.failure;
            resModel.RetMsg = model.Message;
            resModel.Data = model.Data;
            return Ok(model);
        }
        #endregion
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="searchstr"></param>
        /// <returns></returns>
        public IActionResult GetBlogArticlelist(string page, string limit, string searchstr)
        {
            var messageModel = _injection.GetT<IBlogArticleBLL>()
                .GetBlogArticlelist(page, limit, searchstr);
            return Ok(new
            {
                code = 0,
                msg = "获取成功",
                count = messageModel.Data.RowCount,
                data = messageModel.Data.Data
            });
        }
    }
}