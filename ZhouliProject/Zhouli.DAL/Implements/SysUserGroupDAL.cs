using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.DbEntity.Views;
using System.Linq.Expressions;
using Zhouli.Dto.ModelDto;
using Microsoft.Extensions.Configuration;

namespace Zhouli.DAL.Implements
{
    public class SysUserGroupDAL : BaseDAL<SysUserGroup>, ISysUserGroupDAL
    {
        public SysUserGroupDAL(ZhouLiContext db, IConfiguration configuration) : base(db, configuration) { }
        #region 获取用户组列表
        /// <summary>
        /// 获取用户组列表
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="limit">页容量</param>
        /// <param name="searchstr">搜索内容</param>
        /// <returns>分页对象</returns>
        public PageModel GetUserGroupList(string page, string limit, string searchstr)
        {
            var pageModel = new PageModel();
            Expression<Func<SysUserGroup, bool>> expression = t => (string.IsNullOrEmpty(searchstr) || t.UserGroupName.Contains(searchstr)) && t.DeleteSign.Equals((int)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted);
            pageModel.RowCount = GetCount(expression);
            int iBeginRow = Convert.ToInt32(limit) * (Convert.ToInt32(page) - 1) + 1, iEndRow = Convert.ToInt32(page) * Convert.ToInt32(limit);
            pageModel.Data = SqlQuery<SysUserGroupDto>($@"
                                           SELECT *
                                            FROM (
	                                            SELECT ROW_NUMBER() OVER (ORDER BY T1.CREATETIME DESC) AS RN, T1.*
		                                            , (
			                                            SELECT UserGroupName
			                                            FROM Sys_UserGroup s
			                                            WHERE s.UserGroupId = t1.ParentUserGroupId
		                                            ) AS ParentUserGroupName
	                                            FROM Sys_UserGroup T1
	                                            WHERE T1.UserGroupName LIKE '%{searchstr}%'
		                                            AND T1.DeleteSign = 1
                                            ) T
                                            WHERE RN BETWEEN {iBeginRow} AND {iEndRow}");
            return pageModel;
        }
        #endregion
    }
}
