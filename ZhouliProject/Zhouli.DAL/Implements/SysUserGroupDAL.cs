using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.DbEntity.Views;
using System.Linq.Expressions;
using Zhouli.Dto.ModelDto;
using Microsoft.Extensions.Configuration;
using System.Data;
using Zhouli.Enum;

namespace Zhouli.DAL.Implements
{
    public class SysUserGroupDAL : BaseDAL<SysUserGroup>, ISysUserGroupDAL
    {
        public SysUserGroupDAL(ZhouLiContext db, IDbConnection dbConnection) : base(db, dbConnection) { }
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
            Expression<Func<SysUserGroup, bool>> expression = t => (string.IsNullOrEmpty(searchstr) || t.UserGroupName.Contains(searchstr)) && t.DeleteSign.Equals((int)DeleteSign.Sing_Deleted);
            pageModel.RowCount = GetCount(expression);
            int iBeginRow = Convert.ToInt32(limit) * (Convert.ToInt32(page) - 1) + 1, iEndRow = Convert.ToInt32(page) * Convert.ToInt32(limit);
            pageModel.Data = SqlQuery<SysUserGroupDto>($@"
                                           SELECT *   FROM (SELECT ROW_NUMBER() OVER (ORDER BY T1.create_time DESC) AS RN, T1.user_group_id 'UserGroupId',T1.user_group_name 'UserGroupName',
T1.parent_user_group_id 'ParentUserGroupId',T1.create_time 'CreateTime',T1.note 'Note'
		                                            , (
			                                            SELECT user_group_name
			                                            FROM sys_user_group s
			                                            WHERE s.user_group_id = T1.parent_user_group_id
		                                            ) AS ParentUserGroupName
	                                            FROM sys_user_group T1
	                                            WHERE T1.user_group_name LIKE '%{searchstr}%'
		                                            AND T1.delete_sign = 1
                                            ) T
                                            WHERE RN BETWEEN {iBeginRow} AND {iEndRow}");
            return pageModel;
        }
        #endregion
    }
}
