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
    public class DictAuthorityTypeBLL : BaseBLL<DictAuthorityType>, IDictAuthorityTypeBLL
    {
        private IDictAuthorityTypeDAL dictAuthorityType;
        /// <summary>
        /// 用于实例化父级，dictAuthorityType
        /// </summary>
        /// <param name="dictAuthorityType"></param>
        public DictAuthorityTypeBLL(IDictAuthorityTypeDAL dictAuthorityType) : base(dictAuthorityType)
        {
            this.dictAuthorityType = dictAuthorityType;
        }
    }
}
