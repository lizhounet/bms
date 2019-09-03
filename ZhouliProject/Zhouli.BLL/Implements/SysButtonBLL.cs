using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.BLL.Interface;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;

namespace Zhouli.BLL.Implements
{
   public class SysButtonBLL : BaseBLL<SysButton>, ISysButtonBLL
    {
        private readonly ISysButtonDAL _sysButton;
        /// <summary>
        /// 用于实例化父级，sysButton
        /// <param name="sysButton"></param>
        public SysButtonBLL(ISysButtonDAL sysButton) : base(sysButton)
        {
            this._sysButton = sysButton;
        }
    }
}
