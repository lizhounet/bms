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
namespace Zhouli.DbEntity.Models
{
    #region 用户状态
    /// <summary>
    /// 用户状态
    /// </summary>
    public enum UserStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        normal = 1,
        /// <summary>
        /// 停用
        /// </summary>
        Discontinuation = 0
    }
    #endregion
    #region 权限类型
    /// <summary>
    /// 权限类型
    /// </summary>
    public enum AuthorityType
    {
        /// <summary>
        /// 菜单类型
        /// </summary>
        Menu = 1
    }
    #endregion
}
