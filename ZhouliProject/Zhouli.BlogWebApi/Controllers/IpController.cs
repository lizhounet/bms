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
    /// 获取客户端IP地址
    /// </summary>
    [Route("api/ip")]
    [ApiController]
    public class IpController : Controller
    {
        public IpController()
        {
        }
        /// <summary>
        /// 获取客户端IP地址
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public IActionResult GetClientIp()
        {
            return Ok(Request.HttpContext.Connection.RemoteIpAddress.ToString());
        }
    }
}