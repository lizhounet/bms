using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zhouli.FileService.Models
{

    public class FileUploadModel
    {
        /// <summary>
        /// 存储方式:qiniuyun(七牛云存储),bendi(服务器本地存储);
        /// </summary>
        public string StorageMethod { set; get; }
        /// <summary>
        /// 上传文件空间类型(StorageMethod为bendi时可不传):private(私有),public(公开);
        /// </summary>
        public string FileSpaceType { set; get; } 
        /// <summary>
        /// guid
        /// </summary>
        private Guid FileKey { set; get; } = Guid.NewGuid();
        /// <summary>
        /// 文件类型
        /// </summary>
        public string ContentType { set; get; }

    }
}
