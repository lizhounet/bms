using Zhouli.DAL.Interface;
using Zhouli.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.DAL.Implements
{
    public class SysAmRelatedDAL : BaseDAL<SysAmRelated>, ISysAmRelatedDAL
    {
        private GRWEBSITEContext gRWEBSITEContext;
        public SysAmRelatedDAL(GRWEBSITEContext gRWEBSITEContext) : base(gRWEBSITEContext)
        {
            this.gRWEBSITEContext = gRWEBSITEContext;
        }
       
    }
}
