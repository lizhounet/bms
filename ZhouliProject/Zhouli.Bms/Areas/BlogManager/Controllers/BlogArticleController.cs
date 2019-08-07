using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Zhouli.BLL.Interface;
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
        //public string AddorUpdateBlogArticle(BlogArticleDto bl)
        //{
        //    var resModel = new ResponseModel();
        //    MessageModel model = _injection.GetT<IBlogArticleBLL>().AddorEditBlogArticle(bl, _injection.GetT<UserAccount>().GetUserInfo().UserId);
        //    resModel.StateCode = model.Result ? StatesCode.success : StatesCode.failure;
        //    resModel.Messages = model.Message;
        //    resModel.JsonData = model.Data;
        //    return resModel.Json();
        //}
        #endregion
    }
}