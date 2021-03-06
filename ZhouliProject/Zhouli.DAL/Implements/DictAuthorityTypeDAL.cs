﻿using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace Zhouli.DAL.Implements
{
    public class DictAuthorityTypeDAL : BaseDAL<DictAuthorityType>, IDictAuthorityTypeDAL
    {
        public DictAuthorityTypeDAL(ZhouLiContext db, IDbConnection dbConnection) : base(db, dbConnection)
        {
        }
    }
}
