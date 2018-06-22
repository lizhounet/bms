using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Zhouli.BLL.Interface;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using Zhouli.DbEntity.Views;
using AutoMapper;

namespace Zhouli.BLL.Implements
{
    public class SysUserBLL : BaseBLL<SysUser>, ISysUserBLL
    {
        private ISysUserDAL usersDAL;
        /// <summary>
        /// 用于实例化父级，usersDAL变量
        /// </summary>
        /// <param name="usersDAL"></param>
        public SysUserBLL(ISysUserDAL usersDAL) : base(usersDAL)
        {
            this.usersDAL = usersDAL;
        }
        #region
        /// <summary>
        /// 获取需要登录的用户所有信息
        /// </summary>
        /// <returns></returns>
        public SysUser GetLoginSysUser(SysUser user)
        {
            return usersDAL.GetLoginSysUser(user);
        }
        #endregion
        #region 获取用户列表
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="limit">页容量</param>
        /// <param name="searchstr">搜索内容</param>
        /// <returns></returns>
        public PageModel GetUserList(string page, string limit, string searchstr)
        {
            var PageModel = new PageModel();
            Expression<Func<SysUser, bool>> expression = t => string.IsNullOrEmpty(searchstr) || t.UserName.Contains(searchstr) ||
                t.UserNikeName.Contains(searchstr) ||
                t.UserPhone.Contains(searchstr) ||
                t.UserQq.Contains(searchstr) ||
                t.UserWx.Contains(searchstr);
            PageModel.RowCount = usersDAL.GetCount(expression);
            PageModel.Data = Mapper.Map<List<SysUserDto>>(usersDAL.GetModelsByPage(Convert.ToInt32(limit), Convert.ToInt32(page),
                false, t => t.CreateTime,
                expression).ToList());
            return PageModel;
        }
        #endregion
    }
}
