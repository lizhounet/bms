using Blog.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Zhouli.Blog.Services;
using Zhouli.Common;
using Zhouli.CommonEntity;
using Zhouli.Dto.ModelDto;

namespace ZhouliSystem.Components
{
    /// <summary>
    /// 友情链接页面
    /// </summary>
    [ViewComponent(Name = "Friendly")]
    public class FriendlyViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IdentityBlogService _identityBlogService;
        private readonly IConfiguration _configuration;
        public FriendlyViewComponent(IHttpClientFactory clientFactory, IdentityBlogService identityBlogService, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _identityBlogService = identityBlogService;
            _configuration = configuration;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //List<BlogFriendshipLinkDto> blogFriendships = null;
            ////友情链接
            var token = await _identityBlogService.GetToken();
            ViewBag.BlogToken = token;
            ViewBag.BlogApiAddress = _configuration["BlogApiAddress"];
            //var client = _clientFactory.CreateClient();
            //client.SetBearerToken(token);
            //var response = await client.GetAsync($"{_configuration["BlogApiAddress"]}/api/Blog/GetFriendly");
            //if (response.IsSuccessStatusCode)
            //{
            //    var content = await response.Content.ReadAsStringAsync();
            //    var responseModel = JsonHelper.JsonToObject<dynamic>(content);
            //    if (responseModel.StateCode == StatesCode.success)
            //    {
            //        blogFriendships = JsonHelper.JsonToObject<List<BlogFriendshipLinkDto>>(responseModel.JsonData.ToString());
            //    }
            //}
            return View();
        }
    }
}
