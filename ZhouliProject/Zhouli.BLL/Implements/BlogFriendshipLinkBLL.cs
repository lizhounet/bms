﻿using AutoMapper;
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
    public class BlogFriendshipLinkBLL : BaseBLL<BlogFriendshipLink>, IBlogFriendshipLinkBLL
    {
        private readonly IBlogFriendshipLinkDAL blogFriendshipLinkDAL;
        /// <summary>
        /// 用于实例化父级，blogFriendshipLinkDAL
        /// </summary>
        /// <param name="blogFriendshipLinkDAL"></param>
        public BlogFriendshipLinkBLL(IBlogFriendshipLinkDAL blogFriendshipLinkDAL) : base(blogFriendshipLinkDAL)
        {
            this.blogFriendshipLinkDAL = blogFriendshipLinkDAL;
        }
        /// <summary>
        /// 获取友情链接分页数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="searchstr"></param>
        /// <returns></returns>
        public MessageModel GetFriendshipLinkList(string page, string limit, string searchstr)
        {
            var query = blogFriendshipLinkDAL.GetModelsByPage(Convert.ToInt32(limit), Convert.ToInt32(page), false, t => t.CreateTime,
                t => t.FriendshipLinkName.Contains(searchstr) || string.IsNullOrEmpty(searchstr)
                && t.DeleteSign.Equals((int)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted));
            return new MessageModel
            {
                Data = new PageModel
                {
                    RowCount = query.Count(),
                    Data = query.ToList()
                }
            };
        }
        /// <summary>
        /// 添加/编辑友情链接
        /// </summary>
        /// <param name="blog"></param>
        /// <param name="FriendshipLinkId"></param>
        /// <returns></returns>
        public MessageModel AddorEditFriendshipLink(BlogFriendshipLink blog, string UserId)
        {
            var messageModel = new MessageModel();
            var friendshipLink = Mapper.Map<BlogFriendshipLink>(blog);
            //添加
            if (friendshipLink.FriendshipLinkId == 0)
            {
                friendshipLink.CreateTime = DateTime.Now;
                friendshipLink.EditTime = DateTime.Now;
                friendshipLink.DeleteSign = (Int32)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted;
                friendshipLink.CreateUserId = UserId;
                friendshipLink.FriendshipLinkSfsh = 0;
                friendshipLink.FriendshipLinkSortValue = 1;
                if (Add(friendshipLink))
                {
                    messageModel.Message = "添加成功";
                }
                else
                {
                    messageModel.Message = "添加失败";
                    messageModel.Result = false;
                }
            }
            else//修改
            {
                var edit = GetModels(t => t.FriendshipLinkId == blog.FriendshipLinkId).SingleOrDefault();
                edit.FriendshipLinkId = blog.FriendshipLinkId;
                edit.FriendshipLinkName = blog.FriendshipLinkName;
                edit.FriendshipLinkEmail = blog.FriendshipLinkEmail;
                edit.FriendshipLinkUrl = blog.FriendshipLinkUrl;
                edit.Note = blog.Note;
                edit.EditTime = DateTime.Now;
                if (Update(edit))
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
        /// <summary>
        /// 删除友情链接
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        public MessageModel DelFriendshipLink(IEnumerable<string> FriendshipLinkId)
        {
            var model = new MessageModel();
            var friendshipLinkDAL = GetModels(u => FriendshipLinkId.Any(a => a.Equals(u.FriendshipLinkId.ToString())));
            foreach (var item in friendshipLinkDAL)
            {
                item.DeleteSign = (int)ZhouLiEnum.Enum_DeleteSign.Sign_Undeleted;
                item.EditTime = DateTime.Now;
            }
            bool bResult = blogFriendshipLinkDAL.SaveChanges();
            model.Result = bResult;
            model.Message = bResult ? "删除成功" : "删除失败";
            return model;
        }
    }
}
