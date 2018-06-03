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
