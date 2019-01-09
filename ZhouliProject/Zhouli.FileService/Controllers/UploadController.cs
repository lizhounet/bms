using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Qiniu.Common;
using Qiniu.Http;
using Qiniu.IO;
using Qiniu.IO.Model;
using Qiniu.Util;
using Zhouli.Common;
using Zhouli.FileService.Filters;
using Zhouli.FileService.Models;

namespace Zhouli.FileService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private IOptionsSnapshot<CustomConfiguration> configuration;
        public UploadController(IOptionsSnapshot<CustomConfiguration> configuration)
        {
            this.configuration = configuration;

        }
        public IActionResult Upload()
        {
            return Content("ok");
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [UploadLimitFilter(1)]
        public async Task<string> Upload([FromServices]IHostingEnvironment environment, List<IFormFile> filese)
        {
            var response = new ResponseModel();
            var files = Request.Form.Files;
            Mac mac = new Mac(configuration.Value.AccessKey, configuration.Value.SecretKey);
            foreach (var formFile in files)
            {
                //获取文件类型
                var contentType = formFile.ContentType;
                string bucket = configuration.Value.Bucket;
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
                var stream = formFile.OpenReadStream();
                byte[] data = new byte[stream.Length];
                await stream.ReadAsync(data, 0, data.Length);
                // 上传策略，参见 
                // https://developer.qiniu.com/kodo/manual/put-policy
                PutPolicy putPolicy = new PutPolicy();
                // 如果需要设置为"覆盖"上传(如果云端已有同名文件则覆盖)，请使用 SCOPE = "BUCKET:KEY"
                putPolicy.Scope = bucket + ":" + fileName;
                // 上传策略有效期(对应于生成的凭证的有效期)          
                putPolicy.SetExpires(3600);
                putPolicy.ReturnBody = "$(key)";
                // 上传到云端多少天后自动删除该文件，如果不设置（即保持默认默认）则不删除
                //putPolicy.DeleteAfterDays = 1;
                // 生成上传凭证，参见
                // https://developer.qiniu.com/kodo/manual/upload-token      
                string jstr = putPolicy.ToJsonString();
                string token = Auth.CreateUploadToken(mac, jstr);
                Config.AutoZone(mac.AccessKey, bucket, false);
                FormUploader fu = new FormUploader();
                HttpResult result = await fu.UploadDataAsync(data, fileName, token);
                if (result.Code == 200)
                {
                    response.Messages = "文件上传成功";
                    response.StateCode = StatesCode.success;
                    response.JsonData = new
                    {
                        FileAddress = new StringBuilder()
                                    .Append(Request.Scheme)
                                    .Append("://")
                                    .Append(Request.Host)
                                    .Append("/file/")
                                    .ToString() + result.Text.Replace("\"", "")
                    };//文件地址
                }
            }
            return response.Json();
        }
    }
}