using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zhouli.BLL;
using Zhouli.BLL.Interface;
using Zhouli.BlogWebApi.Filters.ArticleBrowsing;
using Zhouli.Common.ResultModel;
using Zhouli.DI;
using Zhouli.Dto.ModelDto;

namespace Zhouli.BlogWebApi.Controllers
{
    /// <summary>
    /// 博客文章api
    /// </summary>
    [Route("api/blog/article")]
    [ApiController]
    [Authorize]
    public class ArticleController : Controller
    {
        private readonly IBlogArticleBLL _blogArticleBLL;
        private readonly IBlogArticleLikeBLL _blogArticleLikeBLL;
        public ArticleController(IBlogArticleBLL blogArticleBLL, IBlogArticleLikeBLL blogArticleLikeBLL)
        {
            _blogArticleBLL = blogArticleBLL;
            _blogArticleLikeBLL = blogArticleLikeBLL;
        }
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="page">当前第几页</param>
        /// <param name="limit">页容量</param>
        /// <param name="searchstr">关键字(文章标题,文章内容)</param>
        /// <param name="lableId">标签id</param>
        /// <returns></returns>
        [HttpGet("")]
        public IActionResult GetArticles(string page, string limit, string searchstr, int lableId)
        {
            return Ok(new ResponseModel { Data = _blogArticleBLL.GetBlogArticlelist(page, limit, searchstr, lableId).Data });
        }
        /// <summary>
        /// 获取文章详情
        /// </summary>
        /// <param name="articleId">文章id</param>
        /// <returns></returns>
        [HttpGet("details")]
        [TypeFilter(typeof(ArticleBrowsingFilterAttribute))]
        public IActionResult Details(int articleId)
        {

            return Ok(new ResponseModel
            {
                Data = _blogArticleBLL.GetArticleDetails(articleId).Data
            });
        }
        /// <summary>
        /// 热门推荐文章
        /// </summary>
        /// <param name="bWeek">是否本周热门(为true时获取本周热门文章)</param>
        /// <returns></returns>
        [HttpGet("popular")]
        public IActionResult Popular(bool bWeek)
        {

            return Ok(new ResponseModel
            {
                Data = _blogArticleBLL.GetPopularArticle(bWeek).Data
            });
        }
        /// <summary>
        /// 文章点赞
        /// </summary>
        /// <returns></returns>
        [HttpPost("like")]
        public IActionResult Like([FromForm]bool isLike, [FromForm] int articleId)
        {
            var response = new ResponseModel();
            var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            var arrIpAddress = ipAddress.Split(':');
            string ip = "::1".Equals(ipAddress) ? "127.0.0.1" : arrIpAddress[arrIpAddress.Length - 1];
            if (!isLike)
            {
                if (_blogArticleLikeBLL.GetCount(t => t.Ip.Equals(ip) && t.ArticleId == articleId) == 0)
                {
                    //点赞
                    _blogArticleLikeBLL.Add(new DbEntity.Models.BlogArticleLike
                    {
                        ArticleId = articleId,
                        Ip = ip,
                        CreateTime = DateTime.Now
                    });
                    response.RetMsg = "点赞成功";
                }
            }
            else
            {
                //取消点赞
                _blogArticleLikeBLL.Delete(t => t.Ip.Equals(ipAddress) && t.ArticleId == articleId);
                response.RetMsg = "取消点赞成功";
            }
            return Ok(response);
        }
    }
}