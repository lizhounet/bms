﻿using System;
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
        private readonly IBlogArticleBrowsingBLL _blogArticleBrowsingBLL;
        public ArticleController(IBlogArticleBLL blogArticleBLL, IBlogArticleBrowsingBLL blogArticleBrowsingBLL)
        {
            _blogArticleBLL = blogArticleBLL;
            _blogArticleBrowsingBLL = blogArticleBrowsingBLL;
        }
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="page">当前第几页</param>
        /// <param name="limit">页容量</param>
        /// <param name="searchstr">关键字(文章标题,文章内容)</param>
        /// <returns></returns>
        [HttpGet("")]
        public IActionResult GetArticles(string page, string limit, string searchstr)
        {
            return Ok(new ResponseModel { Data = _blogArticleBLL.GetBlogArticlelist(page, limit, searchstr).Data });
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
        /// 热门推荐文章(前五篇)
        /// </summary>
        /// <returns></returns>
        [HttpGet("popular")]
        public IActionResult Popular()
        {
            
            return Ok(new ResponseModel
            {
                Data = _blogArticleBLL.GetPopularArticle().Data
            });
        }
    }
}