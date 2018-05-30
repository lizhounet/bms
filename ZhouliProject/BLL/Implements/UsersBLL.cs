using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interface;
using DAL.Interface;
using Model.Entity.Models;

namespace BLL.Implements
{
    public class UsersBLL : BaseBLL<SysUsers>, IUsersBLL
    {
        /// <summary>
        /// 用于实例化父级，Dal变量
        /// </summary>
        /// <param name="dal"></param>
        public UsersBLL(IBaseDAL<SysUsers> dal) : base(dal)
        {
        }
    }
}
