using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace Zhouli.DAL.Implements
{
    public class SysMenuDAL : BaseDAL<SysMenu>, ISysMenuDAL
    {
        public SysMenuDAL(ZhouLiContext db, IConfiguration configuration) : base(db, configuration)
        {
        }
    }
}
