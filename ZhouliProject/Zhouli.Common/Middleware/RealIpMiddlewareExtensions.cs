using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.Common.Middleware
{
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
