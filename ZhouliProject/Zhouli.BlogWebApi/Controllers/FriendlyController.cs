using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zhouli.BLL.Interface;
using Zhouli.CommonEntity;
using Zhouli.Dto.ModelDto;

namespace Zhouli.BlogWebApi.Controllers
{
    /// <summary>
    /// 友情链接api
    /// </summary>
    [Route("api/blog/[controller]")]
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
            var messageModel = await Task.Run(() =>
            _blogFriendshipLinkBLL.GetAuditedFriendshipLinkList());
            return Ok(new ResponseModel
            {
                Data = Mapper.Map<List<BlogFriendshipLinkDto>>(messageModel.Data.Data)
            });
        }
        /// <summary>
        /// 提交友情链接
        /// </summary>
        /// <param name="SiteName">站点名称</param>
        /// <param name="SiteUrl">站点地址</param>
        /// <param name="SiteEmail">站长邮箱</param>
        /// <param name="SiteSummary">网站简介</param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<IActionResult> Friendly([FromForm]string SiteName, [FromForm]string SiteUrl, [FromForm]string SiteEmail, [FromForm]string SiteSummary)
        {

            var responseModel = new ResponseModel();
            var messageModel = await Task.Run(() =>
            _blogFriendshipLinkBLL.AddFriendshipLink(new BlogFriendshipLinkDto
            {
                FriendshipLinkName = SiteName,
                FriendshipLinkUrl = SiteUrl,
                FriendshipLinkEmail = SiteEmail,
                Note = SiteSummary
            }));
            if (messageModel.Result)
            {
                responseModel.RetCode = StatesCode.success;
                responseModel.RetMsg = "提交成功!管理员审核后生效";
            }
            else
            {
                responseModel.RetCode = StatesCode.failure;
                responseModel.RetMsg = messageModel.Message;
            }
            return Ok(responseModel);
        }
    }
}