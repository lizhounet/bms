using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zhouli.Common.Expansion;
using Zhouli.FileService.Models;

namespace Zhouli.FileService.Filters
{
    /// <summary>
    /// 文件上传之前的验证过滤器,UploadFileSize：上传文件限制大小
    /// </summary>
    public class UploadLimitFilter : Attribute, IAsyncResourceFilter
    {
        private readonly int UploadFileSize;
        /// <summary>
        /// UploadLimitFilter构造函数
        /// </summary>
        /// <param name="UploadFileSize"></param>
        public UploadLimitFilter(int UploadFileSize)
        {
            this.UploadFileSize = UploadFileSize;
        }
        /// <summary>
        /// 文件上传之前的验证过滤
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            //var formValueProviderFactory = context.ValueProviderFactories
            //      .OfType<FormValueProviderFactory>()
            //      .FirstOrDefault();
            //if (formValueProviderFactory != null)
            //{
            //    context.ValueProviderFactories.Remove(formValueProviderFactory);
            //}
            //var jqueryFormValueProviderFactory = context.ValueProviderFactories
            //    .OfType<JQueryFormValueProviderFactory>()
            //    .FirstOrDefault();
            //if (jqueryFormValueProviderFactory != null)
            //{
            //    context.ValueProviderFactories.Remove(jqueryFormValueProviderFactory);
            //}
            var files = await context.HttpContext.Request.ReadFormAsync();
            if (files.Files.Count <= 0 || files == null)
            {
                context.Result = new JsonResult(new ResponseModel
                {
                    StateCode = StatesCode.failure,
                    Messages = "请选择需要上传的文件!"
                });
                return;
            };
            var size = files.Files.Sum(t => t.Length.FileSize());
            //超过指定大小不允许上传
            if (files.Files.Sum(t => t.Length.FileSize()) > UploadFileSize)
            {
                context.Result = new JsonResult(new ResponseModel
                {
                    StateCode = StatesCode.failure,
                    Messages = "您的文件超过20M,不允许上传!"
                });
                return;
            }
            await next();
        }
    }
}
