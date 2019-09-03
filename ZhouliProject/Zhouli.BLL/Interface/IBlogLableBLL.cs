using System.Collections.Generic;
using Zhouli.Common.ResultModel;
using Zhouli.DbEntity.Models;
using Zhouli.DbEntity.Views;
using Zhouli.Dto.ModelDto;

namespace Zhouli.BLL.Interface
{
    public interface IBlogLableBLL : IBaseBLL<BlogLable>
    {
        /// <summary>
        /// 获取博客标签分页数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="searchstr"></param>
        /// <returns></returns>
        HandleResult<PageModel> GetBlogLableList(string page, string limit, string searchstr);
        /// <summary>
        /// 添加/编辑博客标签
        /// </summary>
        /// <param name="bl"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        HandleResult<bool> AddorEditBlogLable(BlogLableDto bl, string UserId);
        /// <summary>
        /// 删除博客标签
        /// </summary>
        /// <param name="blogLableId"></param>
        /// <returns></returns>
        HandleResult<bool> DelBlogLable(IEnumerable<string> blogLableId);
    }
}
