using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhouli.Common.Middleware
{
    /// <summary>
    /// 请求记录中间件
    /// </summary>
    public class LogReqResponseMiddleware
    {
        private readonly RequestDelegate _next;
        private SortedDictionary<string, object> _data;
        private Stopwatch _stopwatch;
        public LogReqResponseMiddleware(RequestDelegate next)
        {
            _next = next;
            _stopwatch = new Stopwatch();
        }
        public async Task Invoke(HttpContext context)
        {
            var strAccept = context.Request.Headers["Accept"].ToString().ToLower();
            if (strAccept.Contains("image") || strAccept.Contains("html") || strAccept.Contains("css"))
            {
                await _next(context);
                return;
            }
            var strRequestUrl = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}{context.Request.QueryString}";
            if (strRequestUrl.Contains(".js") || strRequestUrl.Contains(".html") || strRequestUrl.Contains(".css"))
            {
                await _next(context);
                return;
            }
            context.Request.EnableBuffering();
            _stopwatch.Restart();
            _data = new SortedDictionary<string, object>();
            var requestReader = new StreamReader(context.Request.Body);
            var requestContent = requestReader.ReadToEnd();
            //记录请求信息
            _data.Add("request.url", strRequestUrl);
            _data.Add("request.headers", context.Request.Headers.ToDictionary(x => x.Key, v => string.Join(";", v.Value.ToList())));
            _data.Add("request.method", context.Request.Method);
            _data.Add("request.executeStartTime", DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            _data.Add("request.body", requestContent);
            context.Request.Body.Position = 0;
            var originalBodyStream = context.Response.Body;
            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;
                await _next(context);
                var response = context.Response;
                response.Body.Seek(0, SeekOrigin.Begin);
                //转化为字符串
                string text = await new StreamReader(response.Body).ReadToEndAsync();
                //从新设置偏移量0
                response.Body.Seek(0, SeekOrigin.Begin);
                await responseBody.CopyToAsync(originalBodyStream);
                //记录返回值
                _stopwatch.Stop();
                _data.Add("elaspedTime", _stopwatch.ElapsedMilliseconds + "ms");
                _data.Add("response.body", text);
                _data.Add("response.executeEndTime", DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                Log4netHelper.Info(typeof(LogReqResponseMiddleware), JsonConvert.SerializeObject(_data));
            }
        }
    }
    /// <summary>
    /// 请求记录中间件(依赖于log4net)
    /// </summary>
    public static class LogReqResponseMiddlewareExtensions
    {
        /// <summary>
        /// 请求记录中间件(依赖于log4net)
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseLogReqResponseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogReqResponseMiddleware>();
        }
    }

}
