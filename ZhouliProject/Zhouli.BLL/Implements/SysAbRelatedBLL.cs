using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.BLL.Interface;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;

namespace Zhouli.BLL.Implements
{
   public class SysAbRelatedBLL : BaseBLL<SysAbRelated>, ISysAbRelatedBLL
    {
        private readonly ISysAbRelatedDAL _sysAbRelated;
        /// <summary>
        /// 用于实例化父级，sysAbRelated
        /// <param name="sysAbRelated"></param>
        public SysAbRelatedBLL(ISysAbRelatedDAL sysAbRelated) : base(sysAbRelated)
        {
            this._sysAbRelated = sysAbRelated;
        }
    }
}
