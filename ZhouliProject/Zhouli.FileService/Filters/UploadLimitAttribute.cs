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
using Zhouli.CommonEntity;
using Zhouli.FileService.Models;

namespace Zhouli.FileService.Filters
{
    /// <summary>
    /// 文件上传之前的验证
    /// </summary>
    public class UploadLimitAttribute : Attribute, IAsyncResourceFilter
    {
        private readonly int UploadFileSize;
        /// <summary>
        /// UploadLimitFilter构造函数
        /// </summary>
        /// <param name="UploadFileSize">文件大小(单位:M)</param>
        public UploadLimitAttribute(int UploadFileSize)
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
            var formCollection = await context.HttpContext.Request.ReadFormAsync();
            if (formCollection.Files.Count <= 0 || formCollection == null)
            {
                context.Result = new JsonResult(new ResponseModel
                {
                    StateCode = StatesCode.failure,
                    Messages = "请选择需要上传的文件!"
                });
                return;
            };
            ;
            if (!formCollection.ContainsKey("StorageMethod"))
            {
                context.Result = new JsonResult(new ResponseModel
                {
                    StateCode = StatesCode.failure,
                    Messages = "缺少参数:StorageMethod"
                });
                return;
            }
            if (!new List<string> { "qiniuyun", "bendi" }.Contains(formCollection["StorageMethod"]))
            {
                context.Result = new JsonResult(new ResponseModel
                {
                    StateCode = StatesCode.failure,
                    Messages = "没有此类型的StorageMethod"
                });
                return;
            }
            if (!formCollection.ContainsKey("FileSpaceType"))
            {
                context.Result = new JsonResult(new ResponseModel
                {
                    StateCode = StatesCode.failure,
                    Messages = "缺少参数:FileSpaceType"
                });
                return;
            }
            if (!new List<string> { "public", "private" }.Contains(formCollection["FileSpaceType"]))
            {
                context.Result = new JsonResult(new ResponseModel
                {
                    StateCode = StatesCode.failure,
                    Messages = "没有此类型的FileSpaceType"
                });
                return;
            }
            var size = formCollection.Files.Sum(t => t.Length.FileSize());
            //超过指定大小不允许上传
            if (formCollection.Files.Sum(t => t.Length.FileSize()) > UploadFileSize)
            {
                context.Result = new JsonResult(new ResponseModel
                {
                    StateCode = StatesCode.failure,
                    Messages = $"您的文件超过{UploadFileSize}M,不允许上传!"
                });
                return;
            }
            await next();
        }
    }
}
