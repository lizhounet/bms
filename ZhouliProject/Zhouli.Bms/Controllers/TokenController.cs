using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Zhouli.Common.ResultModel;
using Zhouli.DI;

namespace Zhouli.Bms.Controllers
{
    public class TokenController : Controller
    {

        private readonly IMemoryCache _cache;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        public TokenController(IMemoryCache cache, IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _cache = cache;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }/// <summary>
         /// 获取调用文件服务需要的oken
         /// </summary>
         /// <returns></returns>
        [HttpPost]
        public IActionResult GetFileServiceToken()
        {
            //初始化Redis
            //RedisHelper.Initialization(new CSRedis.CSRedisClient(configuration.RedisAdress));
            if (!_cache.TryGetValue($"IdentityFileService_Token", out string token))
            {
                token = GetFileServerToken();
                if (token.Equals("Bearer "))
                {
                    return Ok(new ResponseModel
                    {
                        RetCode = StatesCode.failure,
                        RetMsg = "获取文件服务Token失败"
                    });
                }
                _cache.Set($"IdentityFileService_Token", token, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(3600)));
            }
            return Ok(new ResponseModel
            {
                Data = token
            });
        }
        private string GetFileServerToken()
        {
            var client = _httpClientFactory.CreateClient();
            var response = client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = _configuration["IdentityFileService:Address"] + "/connect/token",
                ClientId = _configuration["IdentityFileService:ClientId"],
                ClientSecret = _configuration["IdentityFileService:ClientSecret"],
                Scope = _configuration["IdentityFileService:Scope"]
            });
            return $"Bearer {response.Result.AccessToken}";
        }
    }
}