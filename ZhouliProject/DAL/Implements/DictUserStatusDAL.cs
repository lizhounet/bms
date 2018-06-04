using Zhouli.DAL.Interface;
using Zhouli.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.DAL.Implements
{
    public class DictUserStatusDAL : BaseDAL<DictUserStatus>, IDictUserStatusDAL
    {
        private GRWEBSITEContext gRWEBSITEContext;
        public DictUserStatusDAL(GRWEBSITEContext gRWEBSITEContext) : base(gRWEBSITEContext)
        {
            this.gRWEBSITEContext = gRWEBSITEContext;
        }
        
    }
}
