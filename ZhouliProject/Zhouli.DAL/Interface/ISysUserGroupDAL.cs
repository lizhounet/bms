using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.DbEntity.Models;
using Zhouli.DbEntity.Views;

namespace Zhouli.DAL.Interface
{
    public interface ISysUserGroupDAL:IBaseDAL<SysUserGroup>
    {
        #region 获取用户组列表
        /// <summary>
        /// 获取用户组列表
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="limit">页容量</param>
        /// <param name="searchstr">搜索内容</param>
        /// <returns>分页对象</returns>
        PageModel GetUserGroupList(string page, string limit, string searchstr);
        #endregion
    } 
}
