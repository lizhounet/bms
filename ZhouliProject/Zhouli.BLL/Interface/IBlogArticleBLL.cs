using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.DbEntity.Models;

namespace Zhouli.BLL.Interface
{
    public interface IBlogArticleBLL : IBaseBLL<BlogArticle>
    {
        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="searchstr"></param>
        /// <returns></returns>
        MessageModel GetBlogArticlelist(string page, string limit, string searchstr);
        /// <summary>
        /// ���/�޸�����
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="searchstr"></param>
        /// <returns></returns>
        MessageModel AddOrUpdateArticlelist(BlogArticleDto blogArticleDto);
    }
}
