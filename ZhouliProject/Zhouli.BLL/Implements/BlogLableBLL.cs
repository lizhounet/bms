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
    public class BlogLableBLL : BaseBLL<BlogLable>, IBlogLableBLL
    {
        private readonly IBlogLableDAL _blogLableDAL;
        /// <summary>
        /// 用于实例化父级，blogLableDAL
        /// </summary>
        /// <param name="BlogLableDAL"></param>
        public BlogLableBLL(IBlogLableDAL blogLableDAL) : base(blogLableDAL)
        {
            this._blogLableDAL = blogLableDAL;
        }
        /// <summary>
        /// 添加/编辑博客标签
        /// </summary>
        /// <param name="bl"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public MessageModel AddorEditBlogLable(BlogLableDto bl, string UserId)
        {
            var messageModel = new MessageModel();
            var blogLable = Mapper.Map<BlogLable>(bl);
            //添加
            if (blogLable.LableId == 0)
            {
                int intcount = _blogLableDAL.GetCount(t => t.LableName.Equals(blogLable.LableName) && t.DeleteSign.Equals((int)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted));
                if (intcount > 0)
                {
                    messageModel.Message = "博客标签名称已注册";
                    messageModel.Result = false;
                }
                else
                {
                    blogLable.CreateTime = DateTime.Now;
                    blogLable.EditTime = DateTime.Now;
                    blogLable.DeleteSign = (Int32)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted;
                    blogLable.CreateUserId = UserId;
                    if (Add(blogLable))
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
                var edit = GetModels(t => t.LableId == blogLable.LableId).SingleOrDefault();
                edit.LableId = blogLable.LableId;
                edit.LableName = blogLable.LableName;
                edit.Note = blogLable.Note;
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
        /// 删除博客标签
        /// </summary>
        /// <param name="blogLableId"></param>
        /// <returns></returns>
        public MessageModel DelBlogLable(IEnumerable<string> blogLableId)
        {
            var model = new MessageModel();
            bool bResult = false;
            var blogLableList = GetModels(u => blogLableId.Any(a => a.Equals(u.LableId.ToString())));
            foreach (var item in blogLableList)
            {
                bResult = Delete(item);
            }
            model.Result = bResult;
            model.Message = bResult ? "删除成功" : "删除失败";
            return model;
        }
        /// <summary>
        /// 博客标签条件分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="searchstr"></param>
        /// <returns></returns>
        public MessageModel GetBlogLableList(string page, string limit, string searchstr)
        {
            var query = _blogLableDAL.GetModelsByPage(Convert.ToInt32(limit), Convert.ToInt32(page), false, t => t.CreateTime,
                t => t.LableName.Contains(searchstr) || string.IsNullOrEmpty(searchstr)
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
