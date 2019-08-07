using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _cache;
        public IndexViewComponent(IHttpClientFactory clientFactory, IMemoryCache cache)
        {
            _clientFactory = clientFactory;
            _cache = cache;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //首页本周热门排行

            if (!_cache.TryGetValue($"Mryj_{DateTime.Now.ToString("yyyyMMdd")}", out MryjModel mryjModel))
            {
                var client = _clientFactory.CreateClient();
                var request = new HttpRequestMessage(HttpMethod.Post,
                "https://api.hibai.cn/api/index/index");
                string Body = "TransCode=030111&OpenId=123456789&Body=";
                request.Content = new StringContent(Body, Encoding.UTF8, "application/x-www-form-urlencoded");
                var response = await client.SendAsync(request);
                mryjModel = await response.Content.ReadAsAsync<MryjModel>();
                _cache.Set($"Mryj_{DateTime.Now.ToString("yyyyMMdd")}", mryjModel, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(24)));
            }
            
            return await Task.Run(()=> View());
        }
    }
}
