using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.DbEntity.Models;

namespace Zhouli.BLL.Interface
{
    public interface IBlogFriendshipLinkBLL : IBaseBLL<BlogFriendshipLink>
    {
        /// <summary>
        /// 获取友情链接分页数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="searchstr"></param>
        /// <returns></returns>
        MessageModel GetFriendshipLinkList(string page, string limit, string searchstr);
        /// <summary>
        /// 添加/编辑用户
        /// </summary>
        /// <param name="blog"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        MessageModel AddorEditFriendshipLink(BlogFriendshipLink blog, string UserId);
        /// <summary>
        /// 删除友情链接
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        MessageModel DelFriendshipLink(IEnumerable<string> FriendshipLinkId);
    }
}
