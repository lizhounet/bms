using Zhouli.DAL.Interface;
using Zhouli.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Linq;

namespace Zhouli.DAL.Implements
{
    public class SysUsersDAL : BaseDAL<SysUsers>, ISysUsersDAL
    {
        private GRWEBSITEContext gRWEBSITEContext;
        public SysUsersDAL(GRWEBSITEContext gRWEBSITEContext) : base(gRWEBSITEContext)
        {
            this.gRWEBSITEContext = gRWEBSITEContext;
        }
        #region
        /// <summary>
        /// 获取需要登录的用户所有信息
        /// </summary>
        /// <returns></returns>
        public SysUsers GetLoginSysUsers(Expression<Func<SysUsers, bool>> WhereLambda)
        {
            SysUsers users = gRWEBSITEContext.SysUsers.Where(WhereLambda).FirstOrDefault();
            return users;

        }
        #endregion
    }
}
