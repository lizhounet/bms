using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Zhouli.BLL.Interface;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;

namespace Zhouli.BLL.Implements
{
    public class SysUrRelatedBLL : BaseBLL<SysUrRelated>, ISysUrRelatedBLL
    {
        private ISysUrRelatedDAL sysUrRelated;
        /// <summary>
        /// 用于实例化父级，sysUrRelated
        /// </summary>
        /// <param name="sysUrRelated"></param>
        public SysUrRelatedBLL(ISysUrRelatedDAL sysUrRelated) : base(sysUrRelated)
        {
            this.sysUrRelated = sysUrRelated;
        }
    }
}
