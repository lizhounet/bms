using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zhouli.BLL.Interface;
using Zhouli.Common.ResultModel;
using Zhouli.Dto.ModelDto;

namespace Zhouli.BlogWebApi.Controllers
{
    /// <summary>
    /// 友情链接api
    /// </summary>
    [Route("api/blog/friendly")]
    [ApiController]
    [Authorize]
    public class FriendlyController : Controller
    {
        private readonly IBlogFriendshipLinkBLL _blogFriendshipLinkBLL;
        public FriendlyController(IBlogFriendshipLinkBLL blogFriendshipLinkBLL)
        {
            _blogFriendshipLinkBLL = blogFriendshipLinkBLL;
        }
        /// <summary>
        /// 获取友情链接列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<IActionResult> Friendly()
        {
            var handleResult = await Task.Run(() =>
            _blogFriendshipLinkBLL.GetAuditedFriendshipLinkList());
            return Ok(new ResponseModel
            {
                Data = Mapper.Map<List<BlogFriendshipLinkDto>>(handleResult.Data.Data)
            });
        }
        /// <summary>
        /// 提交友情链接
        /// </summary>
        /// <param name="siteName">站点名称</param>
        /// <param name="siteUrl">站点地址</param>
        /// <param name="siteEmail">站长邮箱</param>
        /// <param name="siteSummary">网站简介</param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<IActionResult> Friendly([FromForm]string siteName, [FromForm]string siteUrl, [FromForm]string siteEmail, [FromForm]string siteSummary)
        {

            var responseModel = new ResponseModel();
            var handleResult = await Task.Run(() =>
            _blogFriendshipLinkBLL.AddFriendshipLink(new BlogFriendshipLinkDto
            {
                FriendshipLinkName = siteName,
                FriendshipLinkUrl = siteUrl,
                FriendshipLinkEmail = siteEmail,
                Note = siteSummary
            }));
            if (handleResult.Result)
            {
                responseModel.RetCode = StatesCode.success;
                responseModel.RetMsg = "提交成功!管理员审核后生效";
            }
            else
            {
                responseModel.RetCode = StatesCode.failure;
                responseModel.RetMsg = handleResult.Msg;
            }
            return Ok(responseModel);
        }
    }
}