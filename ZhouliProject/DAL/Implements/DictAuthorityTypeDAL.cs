using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.DAL.Implements
{
    public class DictAuthorityTypeDAL : BaseDAL<DictAuthorityType>, IDictAuthorityTypeDAL
    {
        private ZhouLiContext db;
        public DictAuthorityTypeDAL(ZhouLiContext db) : base(db)
        {
            this.db = db;
        }
        
    }
}
