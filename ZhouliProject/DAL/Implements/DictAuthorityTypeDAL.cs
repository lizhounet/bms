using Zhouli.DAL.Interface;
using Zhouli.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.DAL.Implements
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
