using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
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
using Zhouli.CommonEntity;
using Zhouli.FileService.Filters;
using Zhouli.FileService.Models;

namespace Zhouli.FileService.Controllers
{
    /// <summary>
    /// 文件上传
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [Authorize()]
    public class UploadController : ControllerBase
    {
        private IOptionsSnapshot<CustomConfiguration> _configuration;
        /// <summary>
        /// UploadController
        /// </summary>
        /// <param name="configuration"></param>
        public UploadController(IOptionsSnapshot<CustomConfiguration> configuration)
        {
            this._configuration = configuration;

        }
        /// <summary>
        /// 测试接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("okokok");
        }
        /// <summary>
        /// 上传文件接口
        /// </summary>
        /// <remarks>
        /// 上传参数举例:
        ///
        ///     POST 
        ///      {
        ///        "StorageMethod": "qiniuyun",//存储方式
        ///        "FileSpaceType": "public"//上传文件空间类型
        ///     }
        ///
        /// </remarks>
        /// <param name="environment"></param>
        /// <param name="formCollection">文件</param>
        /// <param name="uploadModel">文件上传参数</param>
        /// <returns></returns>
        [HttpPost("")]
        [UploadLimit(20)]
        public async Task<string> Upload([FromServices]IHostingEnvironment environment, IFormCollection formCollection, [FromForm]FileUploadModel uploadModel)
        {
            var response = new ResponseModel();
            foreach (var formFile in formCollection.Files)
            {
                uploadModel.ContentType = formFile.ContentType.Replace("\\", "").Replace("/", "");
                //创建文件名称
                //string fileName = $"{DescHelper.DescEncrypt($"{JsonHelper.Json(uploadModel)}")}" +
                //    $"{Path.GetExtension(formFile.FileName)}";
                string fileName = $"{Guid.NewGuid().ToString()}" +
                   $"{Path.GetExtension(formFile.FileName)}";
                //七牛云存储
                if (uploadModel.StorageMethod.Equals("qiniuyun"))//七牛云存储
                {
                    var stream = formFile.OpenReadStream();
                    byte[] data = new byte[stream.Length];
                    await stream.ReadAsync(data, 0, data.Length);
                    Mac mac = new Mac(_configuration.Value.AccessKey, _configuration.Value.SecretKey);
                    //设置使用七牛云空间
                    string bucket = uploadModel.FileSpaceType.Equals("public") ? _configuration.Value.Bucket.@public.Split(',')[0] : _configuration.Value.Bucket.@private.Split(',')[0];
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
                            FileAddress = $"{_configuration.Value.Bucket.@public.Split(',')[1]}/{result.Text.Replace("\"", "")}"
                        };//文件地址
                    }
                }
                //服务器本地存储
                else if (uploadModel.StorageMethod.Equals("bendi"))
                {
                    var filePath = $@"{environment.ContentRootPath}\Upload\{uploadModel.ContentType}";
                    if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
                    using (var stream = new FileStream(Path.Combine(filePath, fileName), FileMode.CreateNew))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                    response.Messages = "文件上传成功";
                    response.StateCode = StatesCode.success;
                    response.JsonData = new
                    {
                        FileAddress = new StringBuilder()
                                            .Append(Request.Scheme)
                                            .Append("://")
                                            .Append(Request.Host)
                                            .Append($"/{uploadModel.ContentType}/")
                                            .ToString() + fileName
                    };//文件地址
                }
            }
            return response.Json();
        }
    }
}