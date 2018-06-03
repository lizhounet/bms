using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interface;
using DAL.Interface;
using Model.Entity.Models;

namespace BLL.Implements
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

        public string show()
        {
            return usersDAL.show();
        }
    }
}
