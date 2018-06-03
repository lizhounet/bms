using DAL.Interface;
using Model.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Implements
{
    public class DictAuthorityTypeDAL : BaseDAL<DictAuthorityType>, IDictAuthorityTypeDAL
    {
        private GRWEBSITEContext gRWEBSITEContext;
        public DictAuthorityTypeDAL(GRWEBSITEContext gRWEBSITEContext) : base(gRWEBSITEContext)
        {
            this.gRWEBSITEContext = gRWEBSITEContext;
        }
        
    }
}
