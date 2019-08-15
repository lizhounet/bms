using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Zhouli.DAL.Implements
{
    public class SysAmRelatedDAL : BaseDAL<SysAmRelated>, ISysAmRelatedDAL
    {
        public SysAmRelatedDAL(ZhouLiContext db, IDbConnection dbConnection) : base(db, dbConnection)
        {
        }

    }
}
