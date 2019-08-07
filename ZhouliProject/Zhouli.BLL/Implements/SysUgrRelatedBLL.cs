using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.BLL.Interface;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;

namespace Zhouli.BLL.Implements
{
   public class SysUgrRelatedBLL : BaseBLL<SysUgrRelated>, ISysUgrRelatedBLL
    {
        private readonly ISysUgrRelatedDAL sysUgrRelated;
        /// <summary>
        /// 用于实例化父级，sysUgrRelated
        /// <param name="sysUgrRelated"></param>
        public SysUgrRelatedBLL(ISysUgrRelatedDAL sysUgrRelated) : base(sysUgrRelated)
        {
            this.sysUgrRelated = sysUgrRelated;
        }
    }
}
