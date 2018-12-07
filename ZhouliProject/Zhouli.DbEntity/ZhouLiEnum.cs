#region 版权声明
/**************************************************************** 
 * 作    者：周黎 
 * CLR 版本：4.0.30319.42000 
 * 创建时间：2018/6/13 20:39:45 
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
using System.ComponentModel;

namespace Zhouli.MsSql.DbEntity.Models
{
    /// <summary>
    /// 此类包含了项目所有枚举
    /// </summary>
    public static class ZhouLiEnum
    {

        #region 用户状态
        /// <summary>
        /// 用户状态
        /// </summary>
        public enum Enum_UserStatus
        {

            /// <summary>
            /// 正常
            /// </summary>
            [Description("正常")]
            Status_normal = 1,
            /// <summary>
            /// 停用
            /// </summary>
            [Description("停用")]
            Status_Discontinuation = 2
        }
        #endregion
        #region 权限类型
        /// <summary>
        /// 权限类型
        /// </summary>
        public enum Enum_AuthorityType
        {
            /// <summary>
            /// 菜单类型
            /// </summary>
            [Description("菜单类型")]
            Type_Menu = 1
        }
        #endregion
        #region 删除标识
        /// <summary>
        /// 删除标识
        /// </summary>
        public enum Enum_DeleteSign
        {
            /// <summary>
            /// 未删除
            /// </summary>
            [Description("未删除")]
            Sing_Deleted = 1,
            /// <summary>
            /// 已删除
            /// </summary>
            [Description("已删除")]
            Sign_Undeleted = 2
        }
        #endregion
        #region 删除标识
        /// <summary>
        /// 性别
        /// </summary>
        public enum Enum_Sex
        {
            /// <summary>
            /// 男孩
            /// </summary>
            [Description("男孩")]
            Boy = 1,
            /// <summary>
            /// 女孩
            /// </summary>
            [Description("女孩")]
            Girl = 2
        }
        #endregion

    }
}
