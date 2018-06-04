using Zhouli.DAL.Interface;
using Zhouli.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.DAL.Implements
{
    public class SysUrRelatedDAL : BaseDAL<SysUrRelated>, ISysUrRelatedDAL
    {
        private GRWEBSITEContext gRWEBSITEContext;
        public SysUrRelatedDAL(GRWEBSITEContext gRWEBSITEContext) : base(gRWEBSITEContext)
        {
            this.gRWEBSITEContext = gRWEBSITEContext;
        }
        
    }
}
