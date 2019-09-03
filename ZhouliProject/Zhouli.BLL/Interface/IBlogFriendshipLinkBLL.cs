using System.Collections.Generic;
using Zhouli.Common.ResultModel;
using Zhouli.DbEntity.Models;
using Zhouli.DbEntity.Views;
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
        HandleResult<PageModel> GetFriendshipLinkList(string page, string limit, string searchstr);
        /// <summary>
        /// 添加/编辑友情链接
        /// </summary>
        /// <param name="friendshipLinkDto"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        HandleResult<bool> AddorEditFriendshipLink(BlogFriendshipLinkDto friendshipLinkDto, string userId);
        /// <summary>
        /// 删除友情链接
        /// </summary>
        /// <param name="friendshipLinkId"></param>
        /// <returns></returns>
        HandleResult<bool> DelFriendshipLink(IEnumerable<string> friendshipLinkId);
        /// <summary>
        /// 添加未审核友情链接
        /// </summary>
        /// <param name="friendshipLinkDto"></param>
        /// <returns></returns>
        HandleResult<bool> AddFriendshipLink(BlogFriendshipLinkDto friendshipLinkDto);
        /// <summary>
        /// 获取已审核友情链接
        /// </summary>
        /// <returns></returns>
        HandleResult<PageModel> GetAuditedFriendshipLinkList();
        /// <summary>
        /// 审核友情链接
        /// </summary>
        /// <param name="friendshipLinkId"></param>
        /// <returns></returns>
        HandleResult<bool> SfFriendshipLinkList(int friendshipLinkId);

    }
}
