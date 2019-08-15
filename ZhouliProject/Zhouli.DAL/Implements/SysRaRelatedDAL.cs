using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Zhouli.DAL.Implements
{
    public class SysRaRelatedDAL : BaseDAL<SysRaRelated>, ISysRaRelatedDAL
    {
        public SysRaRelatedDAL(ZhouLiContext db, IDbConnection dbConnection) : base(db, dbConnection)
        {
        
        }

    }
}
