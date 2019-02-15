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
    }
}
