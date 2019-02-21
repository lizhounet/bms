using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ZhouliSystem.Components
{
    /// <summary>
    /// 友情链接页面
    /// </summary>
    [ViewComponent(Name = "Friendly")]
    public class FriendlyViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;
        public FriendlyViewComponent(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.Run(()=> View());
        }
    }
}
