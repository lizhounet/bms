﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Zhouli.BLL.Interface;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;

namespace Zhouli.BLL.Implements
{
    public class DictUserStatusBLL : BaseBLL<DictUserStatus>, IDictUserStatusBLL
    {
        private IDictUserStatusDAL dictUserStatus;
        /// <summary>
        /// 用于实例化父级，dictUserStatus
        /// </summary>
        /// <param name="dictUserStatus"></param>
        public DictUserStatusBLL(IDictUserStatusDAL dictUserStatus) : base(dictUserStatus)
        {
            this.dictUserStatus = dictUserStatus;
        }
    }
}
