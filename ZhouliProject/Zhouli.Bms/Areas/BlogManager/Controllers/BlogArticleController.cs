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
using ZhouliSystem.Data;
using ZhouliSystem.Filters;
using ZhouliSystem.Models;

namespace Zhouli.Bms.Areas.BlogManager.Controllers
{
    [VerificationLogin]
    [Area("Blog")]
    public class BlogArticleController : Controller
    {
        private readonly IOptionsSnapshot<CustomConfiguration> _optionsSnapshot;
        private readonly IBlogLableBLL _blogLableBLL;
        private readonly IBlogArticleBLL _blogArticleBLL;
        private readonly UserAccount _userAccount;
        public BlogArticleController(IOptionsSnapshot<CustomConfiguration> optionsSnapshot,
            IBlogLableBLL blogLableBLL,
            IBlogArticleBLL blogArticleBLL,
            UserAccount userAccount)
        {
            _optionsSnapshot = optionsSnapshot;
            _blogLableBLL = blogLableBLL;
            _blogArticleBLL = blogArticleBLL;
            _userAccount = userAccount;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BlogArticleAdd()
        {
            ViewBag.FileServiceAdress = _optionsSnapshot.Value.FileServiceAdress;
            ViewBag.ListBlogLable = _blogLableBLL.GetModels(t => true);
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
            MessageModel model = _blogArticleBLL.AddOrUpdateArticlelist(blogArticleDto, _userAccount.GetUserInfo().UserId);
            resModel.RetCode = model.Result ? StatesCode.success : StatesCode.failure;
            resModel.RetMsg = model.Message;
            resModel.Data = model.Data;
            return Ok(resModel);
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
            var messageModel = _blogArticleBLL
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