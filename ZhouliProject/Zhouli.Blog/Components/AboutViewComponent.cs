using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ZhouliSystem.Components
{
    /// <summary>
    /// 关于本站页面
    /// </summary>
    [ViewComponent(Name = "About")]
    public class AboutViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;
        public AboutViewComponent(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.Run(() => View());
        }
    }
}
