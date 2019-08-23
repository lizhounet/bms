using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Zhouli.BLL;
using Zhouli.BLL.Interface;
using Zhouli.Common.ResultModel;
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
        private readonly IBlogRelatedBLL _blogRelatedBLL;
        public BlogArticleController(IOptionsSnapshot<CustomConfiguration> optionsSnapshot,
            IBlogLableBLL blogLableBLL,
            IBlogArticleBLL blogArticleBLL,
            UserAccount userAccount,
            IBlogRelatedBLL blogRelatedBLL)
        {
            _optionsSnapshot = optionsSnapshot;
            _blogLableBLL = blogLableBLL;
            _blogArticleBLL = blogArticleBLL;
            _userAccount = userAccount;
            _blogRelatedBLL = blogRelatedBLL;
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
            var handleResult = _blogArticleBLL.AddOrUpdateArticlelist(blogArticleDto, _userAccount.GetUserInfo().UserId);
            resModel.RetCode = handleResult.Result ? StatesCode.success : StatesCode.failure;
            resModel.RetMsg = handleResult.Msg;
            resModel.Data = handleResult.Data;
            return Ok(resModel);
        }
        #endregion
        #region 获取文章列表
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="searchstr"></param>
        /// <returns></returns>
        public IActionResult GetBlogArticlelist(string page, string limit, string searchstr, int ladbleId)
        {
            var messageModel = _blogArticleBLL
                .GetBlogArticlelist(page, limit, searchstr, ladbleId);
            return Ok(new
            {
                code = 0,
                msg = "获取成功",
                count = messageModel.Data.RowCount,
                data = messageModel.Data.Data
            });
        }
        #endregion
        #region 获取文章内容
        /// <summary>
        /// 获取文章内容
        /// </summary>
        /// <param name="ArticleId"></param>
        /// <returns></returns>
        public IActionResult GetBlogArticleBody(int ArticleId)
        {
            return Ok(new ResponseModel
            {
                Data = _blogArticleBLL.GetModels(t => t.ArticleId == ArticleId).First().ArticleBody
            });
        }
        #endregion
        #region 删除文章
        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="articleId">文章id</param>
        /// <returns></returns>
        public IActionResult DeleteBlogArticle(List<int> articleId)
        {
            var responseModel = new ResponseModel();
            if (_blogArticleBLL.Delete(t => articleId.Contains(t.ArticleId)) && _blogRelatedBLL.Delete(t => articleId.Contains(t.RelatedArticleId)))
            {
                responseModel.RetMsg = "删除成功";
            }
            else
            {
                responseModel.RetMsg = "删除失败";
                responseModel.RetCode = StatesCode.failure;
            }
            return Ok(responseModel);
        }
        #endregion
        #region 置顶/取消置顶 文章
        /// <summary>
        /// 置顶/取消置顶 文章
        /// </summary>
        /// <param name="articleId">文章id</param>
        /// <param name="articleTop">是否置顶</param>
        /// <returns></returns>
        public IActionResult IsBlogArticleTop(int articleId, bool articleTop)
        {
            var responseModel = new ResponseModel();
            var blogArticle = _blogArticleBLL.GetModels(t => t.ArticleId == articleId).First();
            //获取所有文章最大排序值
            var intMaxArticleSort = _blogArticleBLL.GetMaxArticleSortValue().Data;
            blogArticle.ArticleSortValue = articleTop ? intMaxArticleSort + 1 : 0;
            blogArticle.EditTime = DateTime.Now;
            if (_blogArticleBLL.Update(blogArticle))
            {
                responseModel.RetMsg = articleTop ? "置顶成功" : "取消置顶成功";
            }
            else
            {
                responseModel.RetCode = StatesCode.failure;
                responseModel.RetMsg = articleTop ? "置顶失败" : "取消置顶失败";
            }
            return Ok(responseModel);
        }
        #endregion 
    }
}