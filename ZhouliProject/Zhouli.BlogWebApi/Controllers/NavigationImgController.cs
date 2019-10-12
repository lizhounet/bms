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
using Zhouli.DbEntity.Models;
using Zhouli.DI;
using Zhouli.Dto.ModelDto;
using static Zhouli.DbEntity.Models.ZhouLiEnum;

namespace Zhouli.BlogWebApi.Controllers
{
    /// <summary>
    /// 轮播图api
    /// </summary>
    [Route("api/blog/navigationimg")]
    [ApiController]
    [Authorize]
    public class NavigationImgController : Controller
    {
        private readonly IBlogNavigationImgBLL _blogNavigationImgBLL;
        public NavigationImgController(IBlogNavigationImgBLL blogNavigationImgBLL)
        {
            _blogNavigationImgBLL = blogNavigationImgBLL;
        }
        /// <summary>
        /// 获取所有轮播图
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public IActionResult GetNavigationImgList()
        {
            return Ok(new ResponseModel { Data = _blogNavigationImgBLL.GetModels(t => t.DeleteSign == (int)Enum_DeleteSign.Sing_Deleted).Select(t => new { t.NavigationImgDescribe, t.NavigationImgUrl }) });
        }
    }
}