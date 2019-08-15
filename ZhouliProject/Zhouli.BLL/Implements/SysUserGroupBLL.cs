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
using Zhouli.Dto.ModelDto;
using Zhouli.Enum;

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
            var pageModel = userGroupDAL.GetUserGroupList(page, limit, searchstr);
            pageModel.Data = Mapper.Map<List<SysUserGroupDto>>(pageModel.Data);
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
        public MessageModel DelUserGroup(IEnumerable<string> UserGroupId)
        {
            var model = new MessageModel();
            var sysUserGroups = userGroupDAL.GetModels(t => UserGroupId.Any(a => a.Equals(t.UserGroupId)));
            foreach (var item in sysUserGroups)
            {
                item.DeleteSign = (int)DeleteSign.Sign_Undeleted;
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
