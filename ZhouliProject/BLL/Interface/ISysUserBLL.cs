using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Zhouli.Entity.Models;

namespace Zhouli.BLL.Interface
{
    public interface ISysUserBLL : IBaseBLL<SysUser>
    {
        #region
        /// <summary>
        /// 获取需要登录的用户所有信息
        /// </summary>
        /// <returns></returns>
        SysUser GetLoginSysUser(Expression<Func<SysUser, bool>> WhereLambda);
        #endregion
    }
}
