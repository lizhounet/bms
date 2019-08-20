using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Zhouli.BLL.Interface;
using Zhouli.Common.ResultModel;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using Zhouli.DbEntity.Views;
using Zhouli.Dto.ModelDto;
using Zhouli.Enum;

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
        public HandleResult<PageModel> GetFriendshipLinkList(string page, string limit, string searchstr)
        {
            var query = _blogFriendshipLinkDAL.GetModelsByPage(Convert.ToInt32(limit), Convert.ToInt32(page), false, t => t.CreateTime,
                t => t.FriendshipLinkName.Contains(searchstr) || string.IsNullOrEmpty(searchstr)
                && t.DeleteSign.Equals((int)DeleteSign.Sing_Deleted));
            return new HandleResult<PageModel>
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
        /// <param name="userId"></param>
        /// <returns></returns>
        public HandleResult<bool> AddorEditFriendshipLink(BlogFriendshipLinkDto friendshipLinkDto, string userId)
        {
            var handleResult = new HandleResult<bool>();
            var friendshipLink = Mapper.Map<BlogFriendshipLink>(friendshipLinkDto);
            //添加
            if (friendshipLink.FriendshipLinkId == 0)
            {
                int intcount = _blogFriendshipLinkDAL.GetCount(t => t.FriendshipLinkUrl.Equals(friendshipLink.FriendshipLinkUrl)
                && t.DeleteSign.Equals((int)DeleteSign.Sing_Deleted));
                if (intcount > 0)
                {
                    handleResult.Msg = "已经有该站点";
                    handleResult.Result = false;
                }
                else
                {
                    friendshipLink.CreateTime = DateTime.Now;
                    friendshipLink.EditTime = DateTime.Now;
                    friendshipLink.DeleteSign = (int)DeleteSign.Sing_Deleted;
                    friendshipLink.CreateUserId = userId;
                    friendshipLink.FriendshipLinkSfsh = (int)Sfsh.Audited;
                    if (Add(friendshipLink))
                    {
                        handleResult.Msg = "添加成功";
                    }
                    else
                    {
                        handleResult.Msg = "添加失败";
                        handleResult.Result = false;
                    }
                }
            }
            else//修改
            {
                var edit = GetModels(t => t.FriendshipLinkId == friendshipLinkDto.FriendshipLinkId).SingleOrDefault();
                edit.FriendshipLinkId = friendshipLinkDto.FriendshipLinkId;
                edit.FriendshipLinkName = friendshipLinkDto.FriendshipLinkName;
                edit.FriendshipLinkEmail = friendshipLinkDto.FriendshipLinkEmail;
                edit.FriendshipLinkUrl = friendshipLinkDto.FriendshipLinkUrl;
                edit.Note = friendshipLinkDto.Note;
                edit.EditTime = DateTime.Now;
                if (Update(edit))
                {
                    handleResult.Msg = "修改成功";
                }
                else
                {
                    handleResult.Msg = "修改失败";
                }
            }
            return handleResult;
        }
        /// <summary>
        /// 删除友情链接
        /// </summary>
        /// <param name="friendshipLinkId"></param>
        /// <returns></returns>
        public HandleResult<bool> DelFriendshipLink(IEnumerable<string> friendshipLinkId)
        {
            var handleResult = new HandleResult<bool>();
            bool bResult = false;
            var friendshipLinkDAL = GetModels(u => friendshipLinkId.Any(a => a.Equals(u.FriendshipLinkId.ToString())));
            foreach (var item in friendshipLinkDAL)
            {
                bResult = Delete(item);
            }
            handleResult.Result = bResult;
            handleResult.Msg = bResult ? "删除成功" : "删除失败";
            return handleResult;
        }
        /// <summary>
        /// 添加未审核友情链接
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        public HandleResult<bool> AddFriendshipLink(BlogFriendshipLinkDto friendshipLinkDto)
        {
            var handleResult = new HandleResult<bool>();
            var friendshipLink = Mapper.Map<BlogFriendshipLink>(friendshipLinkDto);
            int intcount = _blogFriendshipLinkDAL.GetCount(t => t.FriendshipLinkUrl.Equals(friendshipLink.FriendshipLinkUrl)
                 && t.DeleteSign.Equals((int)DeleteSign.Sing_Deleted));
            if (intcount > 0)
            {
                handleResult.Msg = "已经有该站点";
                handleResult.Result = false;
            }
            else
            {
                friendshipLink.CreateTime = DateTime.Now;
                friendshipLink.EditTime = DateTime.Now;
                friendshipLink.DeleteSign = (int)DeleteSign.Sing_Deleted;
                friendshipLink.CreateUserId = Guid.Empty.ToString();
                friendshipLink.FriendshipLinkSfsh = (int)Sfsh.Unreviewed;
                if (Add(friendshipLink))
                {
                    handleResult.Msg = "添加成功";
                }
                else
                {
                    handleResult.Msg = "添加失败";
                    handleResult.Result = false;
                }
            }
            return handleResult;
        }
        /// <summary>
        /// 获取已审核友情链接
        /// </summary>
        /// <returns></returns>
        public HandleResult<PageModel> GetAuditedFriendshipLinkList()
        {

            var query = _blogFriendshipLinkDAL.GetModels(t => t.DeleteSign.Equals((int)DeleteSign.Sing_Deleted)
            && t.FriendshipLinkSfsh.Equals((int)Sfsh.Audited));
            return new HandleResult<PageModel>
            {
                Data = new PageModel
                {
                    RowCount = query.Count(),
                    Data = query.ToList()
                }
            };
        }
        /// <summary>
        /// 审核友情链接
        /// </summary>
        /// <param name="friendshipLinkId"></param>
        /// <returns></returns>
        public HandleResult<bool> SfFriendshipLinkList(int friendshipLinkId)
        {
            var handleResult = new HandleResult<bool>();
            var edit = GetModels(t => t.FriendshipLinkId == friendshipLinkId).SingleOrDefault();
            edit.FriendshipLinkSfsh = (int)Sfsh.Audited;
            edit.EditTime = DateTime.Now;
            if (Update(edit))
            {
                handleResult.Msg = "审核成功";
            }
            else
            {
                handleResult.Result = false;
                handleResult.Msg = "审核失败";
            }
            return handleResult;
        }
    }
}
