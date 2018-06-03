using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using BLL.Interface;
using DAL.Interface;
using Model.Entity.Models;

namespace BLL.Implements
{
    public class SysRaRelatedBLL : BaseBLL<SysRaRelated>, ISysRaRelatedBLL
    {
        private ISysRaRelatedDAL sysRaRelated;
        /// <summary>
        /// 用于实例化父级，sysRaRelated
        /// </summary>
        /// <param name="sysRaRelated"></param>
        public SysRaRelatedBLL(ISysRaRelatedDAL sysRaRelated) : base(sysRaRelated)
        {
            this.sysRaRelated = sysRaRelated;
        }
    }
}
