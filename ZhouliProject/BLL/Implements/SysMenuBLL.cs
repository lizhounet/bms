using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Zhouli.BLL.Interface;
using Zhouli.DAL.Interface;
using Zhouli.Entity.Models;

namespace Zhouli.BLL.Implements
{
    public class SysMenuBLL : BaseBLL<SysMenu>, ISysMenuBLL
    {
        private ISysMenuDAL sysMenuDAL;
        /// <summary>
        /// 用于实例化父级，sysMenuDAL
        /// </summary>
        /// <param name="sysMenuDAL"></param>
        public SysMenuBLL(ISysMenuDAL sysMenuDAL) : base(sysMenuDAL)
        {
            this.sysMenuDAL = sysMenuDAL;
        }
    }
}
