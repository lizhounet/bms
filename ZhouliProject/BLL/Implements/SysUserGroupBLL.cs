using AutoMapper;
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
    public class SysUserGroupBLL : BaseBLL<SysUserGroup>, ISysUserGroupBLL
    {
        private ISysUserGroupDAL userGroupDAL;
        /// <summary>
        /// 用于实例化父级，userGroupDAL
        /// </summary>
        /// <param name="userGroupDAL"></param>
        public SysUserGroupBLL(ISysUserGroupDAL userGroupDAL) : base(userGroupDAL)
        {
            this.userGroupDAL = userGroupDAL;
        }
        #region 获取用户组列表
        /// <summary>
        /// 获取用户组列表
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="limit">页容量</param>
        /// <param name="searchstr">搜索内容</param>
        /// <returns></returns>
        public MessageModel GetUserGroupList(string page, string limit, string searchstr)
        {
            var messageModel = new MessageModel();
            var pageModel = new PageModel();
            Expression<Func<SysUserGroup, bool>> expression = t => (string.IsNullOrEmpty(searchstr) || t.UserGroupName.Contains(searchstr)) && t.DeleteSign.Equals((int)DeleteSign.Sing_Deleted);
            pageModel.RowCount = userGroupDAL.GetCount(expression);
            pageModel.Data = Mapper.Map<List<SysUserGroupDto>>(userGroupDAL.GetModelsByPage(Convert.ToInt32(limit), Convert.ToInt32(page),
                false, t => t.CreateTime,
                expression).ToList());
            messageModel.Data = pageModel;
            return messageModel;
        }
        #endregion
    }
}
