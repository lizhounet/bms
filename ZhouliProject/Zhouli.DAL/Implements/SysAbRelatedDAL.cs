using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;

namespace Zhouli.DAL.Implements
{
   public class SysAbRelatedDAL : BaseDAL<SysAbRelated>, ISysAbRelatedDAL
    {
        public SysAbRelatedDAL(ZhouLiContext db, IDbConnection dbConnection) : base(db, dbConnection)
        {
        }
    }
}
