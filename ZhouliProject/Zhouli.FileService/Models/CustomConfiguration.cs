#region 版权声明
/**************************************************************** 
 * 作    者：周黎 
 * CLR 版本：4.0.30319.42000 
 * 创建时间：2018/7/7 14:53:41 
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zhouli.FileService.Models
{
    /// <summary>
    /// 自定义配置类
    /// </summary>
    public class CustomConfiguration
    {
        /// <summary>
        /// 七牛云开发者账户
        /// </summary>
        public string AccessKey { get; set; }
        /// <summary>
        /// 七牛云开发者账户密钥
        /// </summary>
        public string SecretKey { get; set; }
        /// <summary>
        /// 七牛云存储空间
        /// </summary>
        public Bucket Bucket { get; set; }
        /// <summary>
        /// 认证服务站点
        /// </summary>
        public string IdentityServerAdress { get; set; }
    }
    public class Bucket
    {
        /// <summary>
        /// 
        /// </summary>
        public string @public { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string @private { get; set; }
    }

}
