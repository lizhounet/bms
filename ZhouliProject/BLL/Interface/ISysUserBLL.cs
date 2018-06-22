using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Zhouli.DbEntity.Views;
using Zhouli.DbEntity.Models;

namespace Zhouli.BLL.Interface
{
    public interface ISysUserBLL : IBaseBLL<SysUser>
    {
        #region 获取需要登录的用户所有信息
        /// <summary>
        /// 获取需要登录的用户所有信息
        /// </summary>
        /// <returns></returns>
        SysUser GetLoginSysUser(SysUser sysUsers);
        #endregion
        #region 获取用户列表
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="limit">页容量</param>
        /// <param name="searchstr">搜索内容</param>
        /// <returns></returns>
        PageModel GetUserList(string page, string limit, string searchstr);
        #endregion
    }
}
