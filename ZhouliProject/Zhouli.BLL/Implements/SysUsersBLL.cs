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
using Zhouli.Dto.ModelDto;
using Zhouli.Common;

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
        #region 获取需要登录的用户所有信息
        /// <summary>
        /// 获取需要登录的用户所有信息
        /// </summary>
        /// <returns></returns>
        public MessageModel GetLoginSysUser(SysUser user)
        {
            return new MessageModel
            {
                Data = usersDAL.SetLoginSysUser(user)
            };
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
                t.UserEmail.Contains(searchstr)) && t.DeleteSign.Equals((int)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted);
            PageModel.RowCount = usersDAL.GetCount(expression);
            //int iBeginRow = Convert.ToInt32(limit) * (Convert.ToInt32(page) - 1) + 1, iEndRow = Convert.ToInt32(page) * Convert.ToInt32(limit);
            //var list = usersDAL.SqlQuery<SysUserDto>($@"
            //                               SELECT *
            //                    FROM (
            //                        SELECT ROW_NUMBER() OVER (ORDER BY T1.CREATETIME DESC) AS RN, T1.*
            //                        FROM Sys_User T1
            //                        WHERE (T1.UserNikeName LIKE '%{searchstr}%'
            //                                OR T1.UserPhone LIKE '%{searchstr}%'
            //                                OR T1.UserQq LIKE '%{searchstr}%'
            //                                OR T1.UserWx LIKE '%{searchstr}%'
            //                                OR T1.UserEmail LIKE '%{searchstr}%')
            //                            AND T1.DeleteSign = 1
            //                    ) T
            //                    WHERE RN BETWEEN {iBeginRow} AND {iEndRow}");
            var list = usersDAL.GetModelsByPage(Convert.ToInt32(limit), Convert.ToInt32(page), false, t => t.CreateTime, expression);
            PageModel.Data = Mapper.Map<List<SysUserDto>>(list.ToList());
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
        public MessageModel AddorEditUser(SysUserDto userDto, string userId)
        {
            var messageModel = new MessageModel();
            var user = Mapper.Map<SysUser>(userDto);
            //添加
            if (string.IsNullOrEmpty(user.UserId))
            {
                int intcount = usersDAL.GetCount(t => (t.UserName.Equals(user.UserName) ||
                t.UserEmail.Equals(user.UserEmail) ||
                t.UserPhone.Equals(user.UserPhone)) && t.DeleteSign.Equals((int)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted));
                if (intcount > 0)
                {
                    messageModel.Message = "用户名或手机号或邮箱已经被注册";
                    messageModel.Result = false;
                }
                else
                {
                    user.UserId = Guid.NewGuid().ToString();
                    //创建人id
                    user.CreateUserId = userId.ToString();
                    user.CreateTime = DateTime.Now;
                    user.UserPwd = MD5Encrypt.Get32MD5One("123456");//默认密码
                                                                    //添加用户
                    if (Add(user))
                    {
                        messageModel.Message = "添加成功";
                    }
                    else
                    {
                        messageModel.Message = "添加失败";
                        messageModel.Result = false;
                    }
                }
            }
            //修改
            else
            {
                var user_edit = GetModels(t => t.UserId.Equals(user.UserId)).SingleOrDefault();
                user_edit.UserName = user.UserName;
                user_edit.UserNikeName = user.UserNikeName;
                user_edit.UserSex = user.UserSex;
                user_edit.UserBirthday = user.UserBirthday;
                user_edit.UserEmail = user.UserEmail;
                user_edit.UserQq = user.UserQq;
                user_edit.UserWx = user.UserWx;
                user_edit.UserPhone = user.UserPhone;
                user_edit.UserGroupId = user.UserGroupId;
                user_edit.Note = user.Note;
                user_edit.EditTime = DateTime.Now;
                if (!string.IsNullOrEmpty(user.UserAvatar))
                    user_edit.UserAvatar = user.UserAvatar;
                if (Update(user_edit))
                {
                    messageModel.Message = "修改成功";
                }
                else
                {
                    messageModel.Message = "修改失败";
                }

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
        public MessageModel DelUser(IEnumerable<string> UserId)
        {
            var model = new MessageModel();
            var sysUsers = usersDAL.GetModels(t => UserId.Any(a => a.Equals(t.UserId)));
            foreach (var item in sysUsers)
            {
                item.DeleteSign = (int)ZhouLiEnum.Enum_DeleteSign.Sign_Undeleted;
                item.EditTime = DateTime.Now;
            }
            bool bResult = usersDAL.SaveChanges();
            model.Result = bResult;
            model.Message = bResult ? "删除成功" : "删除失败";
            return model;
        }
        #endregion
    }
}
