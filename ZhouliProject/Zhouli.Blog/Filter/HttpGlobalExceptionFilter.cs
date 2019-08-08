#region 版权声明
/**************************************************************** 
 * 作    者：周黎 
 * CLR 版本：4.0.30319.42000 
 * 创建时间：2019/02/21 16:40:11 
 * 当前版本：1.0.0.1 
 *  
 * 描述说明： 
 * 
 * 修改历史： 
 * 
***************************************************************** 
 * Copyright @ ZhouLi 2018 All rights reserved 
 *┌──────────────────────────────────┐
 *│　此技术信息周黎的机密信息，未经本人书面同意禁止向第三方披露．　│
 *│　版权所有：周黎 　　　　　　　　　　　　　　│
 *└──────────────────────────────────┘
*****************************************************************/
#endregion
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Blog.Filter
{
    /// <summary>
    /// 全局异常处理过滤器
    /// </summary>
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IModelMetadataProvider _modelMetadataProvider;
        public HttpGlobalExceptionFilter(
            IHostingEnvironment hostingEnvironment,
            IModelMetadataProvider modelMetadataProvider)
        {
            _hostingEnvironment = hostingEnvironment;
            _modelMetadataProvider = modelMetadataProvider;
        }
        public void OnException(ExceptionContext context)
        {
            if (_hostingEnvironment.IsDevelopment())
            {
                //开发环境
                return;
            }
            //记录错误日志
            //Log4netHelper.Error(typeof(HttpGlobalExceptionFilter), context.Exception);
            //// context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //context.Result = new JsonResult(new ResponseModel
            //{
            //    RetCode = StatesCode.failure,
            //    RetMsg = "服务器出现故障啦,请联系管理员查看错误日志!"
            //});
            //代表错误已经被处理了
            context.ExceptionHandled = true;
        }
    }
}
