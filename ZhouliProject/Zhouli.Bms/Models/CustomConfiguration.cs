﻿#region 版权声明
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

namespace ZhouliSystem.Models
{
    /// <summary>
    /// 自定义配置类
    /// </summary>
    public class CustomConfiguration
    {
        /// <summary>
        /// 超级管理账户
        /// </summary>
        public string adminAccount { set; get; }
        /// <summary>
        /// 文件上传服务器地址
        /// </summary>
        public string FileServiceAdress { set; get; }
        /// <summary>
        /// Identity认证服务站点
        /// </summary>
        public string IdentityServerAdress { set; get; }
        /// <summary>
        /// Redis连接字符串
        /// </summary>
        public string RedisAdress { set; get; }
    }
}
