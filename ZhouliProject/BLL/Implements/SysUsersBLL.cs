using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Zhouli.BLL.Interface;
using Zhouli.DAL.Interface;
using Zhouli.Entity.Models;

namespace Zhouli.BLL.Implements
{
    public class SysUserBLL : BaseBLL<SysUser>, ISysUserBLL
    {
        private ISysUserDAL usersDAL;
        /// <summary>
        /// 用于实例化父级，usersDAL变量
        /// </summary>
        /// <param name="usersDAL"></param>
        public SysUserBLL(ISysUserDAL usersDAL) : base(usersDAL)
        {
            this.usersDAL = usersDAL;
        }
        #region
        /// <summary>
        /// 获取需要登录的用户所有信息
        /// </summary>
        /// <returns></returns>
        public SysUser GetLoginSysUser(Expression<Func<SysUser, bool>> WhereLambda)
        {
            return usersDAL.GetLoginSysUser(WhereLambda);
        }
        #endregion
    }
}
