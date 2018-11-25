using Zhouli.BLL.Interface;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;

namespace Zhouli.BLL.Implements
{
    public class SysRaRelatedBLL : BaseBLL<SysRaRelated>, ISysRaRelatedBLL
    {
        private readonly ISysRaRelatedDAL sysRaRelated;
        /// <summary>
        /// 用于实例化父级，sysRaRelated
        /// </summary>
        /// <param name="sysRaRelated"></param>
        public SysRaRelatedBLL(ISysRaRelatedDAL sysRaRelated) : base(sysRaRelated)
        {
            this.sysRaRelated = sysRaRelated;
        }
    }
}
