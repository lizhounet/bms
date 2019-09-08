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
    [Route("api/blog/tags")]
    [ApiController]
    [Authorize]
    public class TagsController : Controller
    {
        private readonly IBlogLableBLL _blogLableBLL;
        public TagsController(IBlogLableBLL blogLableBLL)
        {
            _blogLableBLL = blogLableBLL;
        }
        /// <summary>
        /// 获取标签列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        [TypeFilter(typeof(ArticleBrowsingFilterAttribute))]
        public IActionResult GetTags()
        {
            return Ok(new ResponseModel { Data = _blogLableBLL.GetModels(t => true).Select(t => new { t.LableId, t.LableName }) });
        }
    }
}