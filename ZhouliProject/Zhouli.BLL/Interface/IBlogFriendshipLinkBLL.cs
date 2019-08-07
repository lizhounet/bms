using System.Collections.Generic;
using Zhouli.DbEntity.Models;
using Zhouli.Dto.ModelDto;

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
        /// 添加/编辑友情链接
        /// </summary>
        /// <param name="blog"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        MessageModel AddorEditFriendshipLink(BlogFriendshipLinkDto blog, string UserId);
        /// <summary>
        /// 删除友情链接
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        MessageModel DelFriendshipLink(IEnumerable<string> FriendshipLinkId);
        /// <summary>
        /// 添加未审核友情链接
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        MessageModel AddFriendshipLink(BlogFriendshipLinkDto blog);
        /// <summary>
        /// 获取已审核友情链接
        /// </summary>
        /// <returns></returns>
        MessageModel GetAuditedFriendshipLinkList();
        /// <summary>
        /// 审核友情链接
        /// </summary>
        /// <param name="FriendshipLinkId"></param>
        /// <returns></returns>
        MessageModel SfFriendshipLinkList(int FriendshipLinkId);

    }
}
