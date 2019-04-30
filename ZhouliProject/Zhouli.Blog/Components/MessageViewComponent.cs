using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ZhouliSystem.Components
{
    /// <summary>
    /// 网站留言页面
    /// </summary>
    [ViewComponent(Name = "Message")]
    public class MessageViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;
        public MessageViewComponent(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.Run(() => View());
        }
    }
}
