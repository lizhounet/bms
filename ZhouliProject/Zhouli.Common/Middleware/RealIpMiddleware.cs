using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Zhouli.Common.Middleware
{
    public class RealIpMiddleware
    {
        private readonly RequestDelegate _next;

        public RealIpMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            var headers = context.Request.Headers;
            if (headers.ContainsKey("X-Forwarded-For"))
            {
                context.Connection.RemoteIpAddress = IPAddress.Parse(headers["X-Forwarded-For"].ToString().Split(',', StringSplitOptions.RemoveEmptyEntries)[0]);
            }
            return _next(context);
        }
    }
    public static class RealIpMiddlewareExtensions
    {
        /// <summary>
        /// 搭配了nginx获取真实IP
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseRealIp(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RealIpMiddleware>();
        }
    }
}
