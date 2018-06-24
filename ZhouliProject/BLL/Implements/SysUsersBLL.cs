using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Zhouli.BLL.Interface;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using Zhouli.DbEntity.Views;
using System.Text;
using AutoMapper;

namespace Zhouli.BLL.Implements
{
    public class SysUserBLL : BaseBLL<SysUser>, ISysUserBLL
    {
        private ISysUserDAL usersDAL;
        private ISysUuRelatedDAL uuRelatedDAL;
        /// <summary>
        /// 用于实例化父级，usersDAL变量
        /// </summary>
        /// <param name="usersDAL"></param>
        public SysUserBLL(ISysUserDAL usersDAL, ISysUuRelatedDAL uuRelatedDAL) : base(usersDAL)
        {
            this.usersDAL = usersDAL;
            this.uuRelatedDAL = uuRelatedDAL;
        }
        #region 获取需要登录的用户所有信息
        /// <summary>
        /// 获取需要登录的用户所有信息
        /// </summary>
        /// <returns></returns>
        public MessageModel GetLoginSysUser(SysUser user)
        {
            var messageModel = new MessageModel();
            messageModel.Data = usersDAL.GetLoginSysUser(user);
            return messageModel;
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
        public MessageModel GetUserList(string page, string limit, string searchstr)
        {
            var messageModel = new MessageModel();
            var PageModel = new PageModel();
            Expression<Func<SysUser, bool>> expression = t => (string.IsNullOrEmpty(searchstr) || t.UserName.Contains(searchstr) ||
                t.UserNikeName.Contains(searchstr) ||
                t.UserPhone.Contains(searchstr) ||
                t.UserQq.Contains(searchstr) ||
                t.UserWx.Contains(searchstr) ||
                t.UserEmail.Contains(searchstr)) && t.DeleteSign.Equals((int)DeleteSign.Sing_Deleted);
            PageModel.RowCount = usersDAL.GetCount(expression);
            PageModel.Data = Mapper.Map<List<SysUserDto>>(usersDAL.GetModelsByPage(Convert.ToInt32(limit), Convert.ToInt32(page),
                false, t => t.CreateTime,
                expression).ToList());
            messageModel.Data = PageModel;
            return messageModel;
        }
        #endregion
        #region 添加/编辑用户
        /// <summary>
        /// 添加/编辑用户
        /// </summary>
        /// <param name="userDto"></param>
        /// <param name="userId">当前登录用户id</param>
        /// <returns></returns>
        public MessageModel AddorEditUser(SysUserDto userDto, Guid userId)
        {
            var messageModel = new MessageModel();
            var user = Mapper.Map<SysUser>(userDto);
            int intcount = usersDAL.GetCount(t => (t.UserName.Equals(user.UserName) || t.UserEmail.Equals(user.UserEmail == null ? "0" : user.UserEmail) || t.UserPhone.Equals(user.UserPhone == null ? "0" : user.UserPhone)) && !t.UserId.Equals(user.UserId) && t.DeleteSign.Equals(DeleteSign.Sing_Deleted));
            if (intcount == 0)
            {
                //添加
                if (user.UserId.Equals(default(Guid)))
                {
                    user.UserId = Guid.NewGuid();
                    user.CreateUserId = userId;//创建人id
                    //添加用户
                    if (Add(user))
                    {
                        var listSysUuRelated = new List<SysUuRelated>();//用户组与用户关联表集合
                        if (!string.IsNullOrEmpty(userDto.UserGroup))
                        {
                            foreach (var item in userDto.UserGroup.Split(','))
                            {
                                listSysUuRelated.Add(new SysUuRelated
                                {
                                    UserId = user.UserId,
                                    UserGroupId = Guid.Parse(item)
                                });
                            }
                            if (listSysUuRelated.Count > 0)
                            {
                                uuRelatedDAL.AddRange(listSysUuRelated);
                                uuRelatedDAL.SaveChanges();
                            }
                        }
                        messageModel.Message = "添加成功";
                    }
                    else
                    {
                        messageModel.Message = "添加失败";
                        messageModel.Result = false;
                    }
                }
                //修改
                else
                {
                    var user_edit = GetModels(t => t.UserId.Equals(user.UserId)).SingleOrDefault();
                    user_edit.UserName= user.UserName;
                    user_edit.UserNikeName = user.UserNikeName;
                    user_edit.UserSex = user.UserSex;
                    user_edit.UserBirthday = user.UserBirthday;
                    user_edit.UserEmail = user.UserEmail;
                    user_edit.UserQq = user.UserQq;
                    user_edit.UserWx = user.UserWx;
                    user_edit.UserPhone = user.UserPhone;
                    user_edit.EditTime = DateTime.Now;
                    if (Update(user_edit))
                    {
                        messageModel.Message = "修改成功";
                    }
                    else
                    {
                        messageModel.Message = "修改失败";
                    }

                }
            }
            else
            {
                messageModel.Message = "用户名或手机号或邮箱已经被注册";
                messageModel.Result = false;
            }
            return messageModel;
        }
        #endregion
        #region 删除用户(批量删除)
        /// <summary>
        /// 删除用户(批量删除)
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public MessageModel DelUser(IEnumerable<Guid> UserId)
        {
            var model = new MessageModel();
            StringBuilder builder = new StringBuilder(20);
            builder.AppendLine(value: $"UPDATE SYS_USER SET DeleteSign={(Int32)DeleteSign.Sign_Undeleted},DeleteTime='{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE USERID IN (");
            builder.AppendLine($"'{String.Join("','", UserId)}')");
            bool bResult = ExecuteSql(builder.ToString()) > 0;
            model.Result = bResult;
            model.Message = bResult ? "删除成功" : "删除失败";
            return model;
        }
        #endregion
    }
}
