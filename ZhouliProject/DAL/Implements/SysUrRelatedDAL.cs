﻿using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.DAL.Implements
{
    public class SysUrRelatedDAL : BaseDAL<SysUrRelated>, ISysUrRelatedDAL
    {
        private DapperContext dapper;
        private ZhouLiContext db;
        public SysUrRelatedDAL(DapperContext dapper, ZhouLiContext db) : base(db)
        { 
            this.dapper = dapper;
            this.db = db;
        }

    }
}
