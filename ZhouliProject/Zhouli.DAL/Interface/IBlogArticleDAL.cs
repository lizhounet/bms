using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.Common.ResultModel;
using Zhouli.DbEntity.Models;
using Zhouli.DbEntity.Views;

namespace Zhouli.DAL.Interface
{
   public interface IBlogArticleDAL : IBaseDAL<BlogArticle>
    {
        /// <summary>
        /// ��ȡ�����������ֵ
        /// </summary>
        /// <returns></returns>
        int GetMaxArticleSortValue();
        #region ��ȡ�����б�
        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        /// <param name="page">�ڼ�ҳ</param>
        /// <param name="limit">ҳ����</param>
        /// <param name="searchstr">��������</param>
        /// <returns>��ҳ����</returns>
        PageModel GetBlogArticleList(string page, string limit, string searchstr);
        #endregion
        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        HandleResult<dynamic> GetArticleDetails(int articleId);

    }
}
