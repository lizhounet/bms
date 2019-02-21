using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ZhouliSystem.Components
{
    /// <summary>
    /// 首页内容
    /// </summary>
    [ViewComponent(Name = "Index")]
    public class IndexViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;
        public IndexViewComponent(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.Run(()=> View());
        }
    }
}
