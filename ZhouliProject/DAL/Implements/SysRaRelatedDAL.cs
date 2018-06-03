using DAL.Interface;
using Model.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Implements
{
    public class SysRaRelatedDAL : BaseDAL<SysRaRelated>, ISysRaRelatedDAL
    {
        private GRWEBSITEContext gRWEBSITEContext;
        public SysRaRelatedDAL(GRWEBSITEContext gRWEBSITEContext) : base(gRWEBSITEContext)
        {
            this.gRWEBSITEContext = gRWEBSITEContext;
        }
       
    }
}
