using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Qiniu.Http;
using Qiniu.IO;
using Qiniu.Util;
using Zhouli.FileService.Models;

namespace Zhouli.FileService.Controllers
{
    /// <summary>
    /// 文件下载
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class FileController : ControllerBase
    {
        private IOptionsSnapshot<CustomConfiguration> configuration;
        /// <summary>
        /// FileController
        /// </summary>
        /// <param name="configuration"></param>
        public FileController(IOptionsSnapshot<CustomConfiguration> configuration)
        {
            this.configuration = configuration;
        }
        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Get() {
            return "哈哈";
        }
        /// <summary>
        /// 文件访问,返回文件响应流
        /// </summary>
        /// <param name="fileKey"></param>
        /// <returns></returns>
        [HttpGet("{fileKey}")]
        public async Task<FileResult> Download(string fileKey) {
            Mac mac = new Mac(configuration.Value.AccessKey, configuration.Value.SecretKey);
            string rawUrl = "http://qiniucdn.zhouli.info/"+ fileKey;
            // 设置下载链接有效期3600秒
            int expireInSeconds = 3600;
            string accUrl = DownloadManager.CreateSignedUrl(mac, rawUrl, expireInSeconds);
            // 接下来可以使用accUrl来下载文件
            HttpResult result = await DownloadManager.DownloadAsync(accUrl, null);
            return File(result.Data, "application/octet-stream", Path.GetFileName(rawUrl));
        }
    }
}