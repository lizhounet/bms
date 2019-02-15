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
    }
}
