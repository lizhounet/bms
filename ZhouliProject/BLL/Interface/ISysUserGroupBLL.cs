using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.DbEntity.Models;

namespace Zhouli.BLL.Interface
{
    public interface ISysUserGroupBLL : IBaseBLL<SysUserGroup>
    {
        #region 获取用户组列表
        /// <summary>
        /// 获取用户组列表
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="limit">页容量</param>
        /// <param name="searchstr">搜索内容</param>
        /// <returns></returns>
        MessageModel GetUserGroupList(string page, string limit, string searchstr);
        #endregion
    }
}
