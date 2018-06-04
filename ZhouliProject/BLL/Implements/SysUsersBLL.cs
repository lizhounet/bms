using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Zhouli.BLL.Interface;
using Zhouli.DAL.Interface;
using Zhouli.Entity.Models;

namespace Zhouli.BLL.Implements
{
    public class SysUsersBLL : BaseBLL<SysUsers>, ISysUsersBLL
    {
        private ISysUsersDAL usersDAL;
        /// <summary>
        /// 用于实例化父级，usersDAL变量
        /// </summary>
        /// <param name="usersDAL"></param>
        public SysUsersBLL(ISysUsersDAL usersDAL) : base(usersDAL)
        {
            this.usersDAL = usersDAL;
        }
        #region
        /// <summary>
        /// 获取需要登录的用户所有信息
        /// </summary>
        /// <returns></returns>
        public SysUsers GetLoginSysUsers(Expression<Func<SysUsers, bool>> WhereLambda)
        {
            return usersDAL.GetLoginSysUsers(WhereLambda);
        }
        #endregion
    }
}
