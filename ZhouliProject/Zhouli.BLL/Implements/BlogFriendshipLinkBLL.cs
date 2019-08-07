using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Zhouli.BLL.Interface;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using Zhouli.DbEntity.Views;
using Zhouli.Dto.ModelDto;

namespace Zhouli.BLL.Implements
{
    public class BlogFriendshipLinkBLL : BaseBLL<BlogFriendshipLink>, IBlogFriendshipLinkBLL
    {
        private readonly IBlogFriendshipLinkDAL _blogFriendshipLinkDAL;

        public IBlogFriendshipLinkDAL BlogFriendshipLinkDAL => _blogFriendshipLinkDAL;

        /// <summary>
        /// 用于实例化父级，blogFriendshipLinkDAL
        /// </summary>
        /// <param name="blogFriendshipLinkDAL"></param>
        public BlogFriendshipLinkBLL(IBlogFriendshipLinkDAL blogFriendshipLinkDAL) : base(blogFriendshipLinkDAL)
        {
            this._blogFriendshipLinkDAL = blogFriendshipLinkDAL;
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
            var query = _blogFriendshipLinkDAL.GetModelsByPage(Convert.ToInt32(limit), Convert.ToInt32(page), false, t => t.CreateTime,
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
        public MessageModel AddorEditFriendshipLink(BlogFriendshipLinkDto blog, string UserId)
        {
            var messageModel = new MessageModel();
            var friendshipLink = Mapper.Map<BlogFriendshipLink>(blog);
            //添加
            if (friendshipLink.FriendshipLinkId == 0)
            {
                int intcount = _blogFriendshipLinkDAL.GetCount(t => t.FriendshipLinkUrl.Equals(friendshipLink.FriendshipLinkUrl)
                && t.DeleteSign.Equals((int)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted));
                if (intcount > 0)
                {
                    messageModel.Message = "已经有该站点";
                    messageModel.Result = false;
                }
                else
                {
                    friendshipLink.CreateTime = DateTime.Now;
                    friendshipLink.EditTime = DateTime.Now;
                    friendshipLink.DeleteSign = (int)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted;
                    friendshipLink.CreateUserId = UserId;
                    friendshipLink.FriendshipLinkSfsh = (int)ZhouLiEnum.Enum_Sfsh.Audited;
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
            bool bResult = false;
            var friendshipLinkDAL = GetModels(u => FriendshipLinkId.Any(a => a.Equals(u.FriendshipLinkId.ToString())));
            foreach (var item in friendshipLinkDAL)
            {
                bResult = Delete(item);
            }
            model.Result = bResult;
            model.Message = bResult ? "删除成功" : "删除失败";
            return model;
        }
        /// <summary>
        /// 添加未审核友情链接
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        public MessageModel AddFriendshipLink(BlogFriendshipLinkDto blog)
        {
            var messageModel = new MessageModel();
            var friendshipLink = Mapper.Map<BlogFriendshipLink>(blog);
            int intcount = _blogFriendshipLinkDAL.GetCount(t => t.FriendshipLinkUrl.Equals(friendshipLink.FriendshipLinkUrl)
                 && t.DeleteSign.Equals((int)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted));
            if (intcount > 0)
            {
                messageModel.Message = "已经有该站点";
                messageModel.Result = false;
            }
            else
            {
                friendshipLink.CreateTime = DateTime.Now;
                friendshipLink.EditTime = DateTime.Now;
                friendshipLink.DeleteSign = (int)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted;
                friendshipLink.CreateUserId = Guid.Empty.ToString();
                friendshipLink.FriendshipLinkSfsh = (int)ZhouLiEnum.Enum_Sfsh.Unreviewed;
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
            return messageModel;
        }
        /// <summary>
        /// 获取已审核友情链接
        /// </summary>
        /// <returns></returns>
        public MessageModel GetAuditedFriendshipLinkList()
        {

            var query = _blogFriendshipLinkDAL.GetModels(t => t.DeleteSign.Equals((int)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted)
            && t.FriendshipLinkSfsh.Equals((int)ZhouLiEnum.Enum_Sfsh.Audited));
            return new MessageModel
            {
                Data = new PageModel
                {
                    RowCount = query.Count(),
                    Data = query.ToList()
                }
            };
        }

        public MessageModel SfFriendshipLinkList(int FriendshipLinkId)
        {
            var messageModel = new MessageModel();
            var edit = GetModels(t => t.FriendshipLinkId == FriendshipLinkId).SingleOrDefault();
            edit.FriendshipLinkSfsh = (int)ZhouLiEnum.Enum_Sfsh.Audited;
            edit.EditTime = DateTime.Now;
            if (Update(edit))
            {
                messageModel.Message = "审核成功";
            }
            else
            {
                messageModel.Message = "审核失败";
            }
            return messageModel;
        }
    }
}
