using IdentityModel.Client;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Zhouli.Blog.Services
{
    public class IdentityBlogService
    {
        public HttpClient _client { get; }
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _cache;
        public IdentityBlogService(HttpClient client, IConfiguration configuration, IMemoryCache cache)
        {
            _client = client;
            _configuration = configuration;
            _cache = cache;
        }
        /// <summary>
        /// 到Identity认证服务器获取Token
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetToken()
        {
            if (!_cache.TryGetValue($"IdentityBlog_Token", out string strAccessToken))
            {
                var response = await _client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = $"{_configuration["IdentityBlog:Address"]}/connect/token",
                    ClientId = _configuration["IdentityBlog:ClientId"],
                    ClientSecret = _configuration["IdentityBlog:ClientSecret"],
                    Scope = _configuration["IdentityBlog:Scope"]
                });
                strAccessToken = response.AccessToken;
                _cache.Set($"IdentityBlog_Token", strAccessToken, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(3500)));

            }
            return strAccessToken;
        }
    }
}
