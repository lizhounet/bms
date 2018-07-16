using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Zhouli.BLL.Interface;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using Zhouli.DbEntity.Views;

namespace Zhouli.BLL.Implements
{
    public class SysRoleBLL : BaseBLL<SysRole>, ISysRoleBLL
    {
        private ISysRoleDAL sysRoleDAL;
        /// <summary>
        /// 用于实例化父级，sysRoleDAL
        /// </summary>
        /// <param name="sysRoleDAL"></param>
        public SysRoleBLL(ISysRoleDAL sysRoleDAL) : base(sysRoleDAL)
        {
            this.sysRoleDAL = sysRoleDAL;
        }
        #region 删除角色(批量删除)
        /// <summary>
        /// 删除用户(批量删除)
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public MessageModel DelRole(IEnumerable<Guid> RoleId)
        {
            var model = new MessageModel();
            StringBuilder builder = new StringBuilder(20);
            builder.AppendLine(value: $"UPDATE Sys_Role SET DeleteSign={(Int32)ZhouLiEnum.Enum_DeleteSign.Sign_Undeleted},DeleteTime='{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE RoleId IN (");
            builder.AppendLine($"'{String.Join("','", RoleId)}')");
            bool bResult = ExecuteSql(builder.ToString()) > 0;
            model.Result = bResult;
            model.Message = bResult ? "删除成功" : "删除失败";
            return model;
        }
        #endregion
        #region 获取角色列表
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="limit">页容量</param>
        /// <param name="searchstr">搜索内容</param>
        /// <returns></returns>
        public MessageModel GetRoleList(string page, string limit, string searchstr)
        {
            var query = sysRoleDAL.GetModelsByPage(Convert.ToInt32(limit), Convert.ToInt32(page), false, t => t.CreateTime,
                t => t.RoleName.Contains(searchstr) || string.IsNullOrEmpty(searchstr) 
                && t.DeleteSign.Equals((int)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted));
            return new MessageModel
            {
                Data = new PageModel
                {
                    RowCount = query.Count(),
                    Data = AutoMapper.Mapper.Map<List<SysRole>>(query.ToList())
                }
            };
        }
        #endregion
    }
}
