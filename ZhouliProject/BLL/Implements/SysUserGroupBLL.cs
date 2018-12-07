using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Zhouli.BLL.Interface;
using Zhouli.DAL.Interface;
using Zhouli.MsSql.DbEntity.Models;
using Zhouli.MsSql.DbEntity.Views;

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
            Expression<Func<SysUserGroup, bool>> expression = t => (string.IsNullOrEmpty(searchstr) || t.UserGroupName.Contains(searchstr)) && t.DeleteSign.Equals((int)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted);
            pageModel.RowCount = userGroupDAL.GetCount(expression);
            var list = userGroupDAL.GetModelsByPage(Convert.ToInt32(limit), Convert.ToInt32(page), false, t => t.CreateTime, expression);
            pageModel.Data = Mapper.Map<List<SysUserGroupDto>>(list.ToList());
            messageModel.Data = pageModel;
            return messageModel;
        }
        #endregion
        #region 删除用户组(批量删除)
        /// <summary>
        /// 删除用户(批量删除)
        /// </summary>
        /// <param name="UserGroupId"></param>
        /// <returns></returns>
        public MessageModel DelUserGroup(IEnumerable<Guid> UserGroupId)
        {
            var model = new MessageModel();
            var sysUserGroups = userGroupDAL.GetModels(t => UserGroupId.Any(a => a.Equals(t.UserGroupId)));
            foreach (var item in sysUserGroups)
            {
                item.DeleteSign = (int)ZhouLiEnum.Enum_DeleteSign.Sign_Undeleted;
                item.EditTime = DateTime.Now;
                userGroupDAL.Update(item);
            }
            bool bResult = userGroupDAL.SaveChanges();
            model.Result = bResult;
            model.Message = bResult ? "删除成功" : "删除失败";
            return model;
        }
        #endregion
    }
}
