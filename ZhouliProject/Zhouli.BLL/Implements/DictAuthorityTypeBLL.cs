using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.BLL.Interface;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;

namespace Zhouli.BLL.Implements
{
   public class DictAuthorityTypeBLL : BaseBLL<DictAuthorityType>, IDictAuthorityTypeBLL
    {
        private readonly IDictAuthorityTypeDAL _dictAuthorityType;
        /// <summary>
        /// 用于实例化父级，dictAuthorityType
        /// <param name="dictAuthorityType"></param>
        public DictAuthorityTypeBLL(IDictAuthorityTypeDAL dictAuthorityType) : base(dictAuthorityType)
        {
            this._dictAuthorityType = dictAuthorityType;
        }
    }
}
