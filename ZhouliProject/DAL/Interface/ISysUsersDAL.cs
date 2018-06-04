using Zhouli.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace Zhouli.DAL.Interface
{
    public interface ISysUsersDAL : IBaseDAL<SysUsers>
    {
        #region
        /// <summary>
        /// 获取需要登录的用户所有信息
        /// </summary>
        /// <returns></returns>
        SysUsers GetLoginSysUsers(Expression<Func<SysUsers, bool>> WhereLambda);
        #endregion
    }
}
