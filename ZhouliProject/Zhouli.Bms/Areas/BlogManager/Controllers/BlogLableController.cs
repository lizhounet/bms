using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Zhouli.BLL;
using Zhouli.BLL.Interface;
using Zhouli.Common;
using Zhouli.CommonEntity;
using Zhouli.DI;
using Zhouli.Dto.ModelDto;
using ZhouliSystem.Data;
using ZhouliSystem.Filters;
using ZhouliSystem.Models;

namespace Zhouli.Bms.Areas.BlogManager.Controllers
{
    [VerificationLogin]
    [Area("Blog")]
    public class BlogLableController : Controller
    {
        private readonly IBlogLableBLL _blogLableBLL;
        private readonly UserAccount _userAccount;
        public BlogLableController(IBlogLableBLL blogLableBLL, UserAccount userAccount)
        {
            _blogLableBLL = blogLableBLL;
            _userAccount = userAccount;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BlogLableAdd()
        {
            return View();
        }
        #region 获取博客标签分页数据
        /// <summary>
        /// 获取博客标签分页数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="searchstr"></param>
        /// <returns></returns>
        public IActionResult GetBlogLableList(string page, string limit, string searchstr)
        {
            var messageModel = _blogLableBLL
                 .GetBlogLableList(page, limit, searchstr);
            return Ok(new
            {
                code = 0,
                msg = "获取成功",
                count = messageModel.Data.RowCount,
                data = messageModel.Data.Data
            });
        }
        #endregion
        #region 添加博客标签链接
        /// <summary>
        /// 添加博客标签链接
        /// </summary>
        /// <param name="bl"></param>
        /// <returns></returns>
        public IActionResult AddorUpdateBlogLable(BlogLableDto bl)
        {
            var resModel = new ResponseModel();
            var handleResult = _blogLableBLL.AddorEditBlogLable(bl, _userAccount.GetUserInfo().UserId);
            resModel.RetCode = handleResult.Result ? StatesCode.success : StatesCode.failure;
            resModel.RetMsg = handleResult.Msg;
            resModel.Data = handleResult.Data;
            return Ok(resModel);
        }
        #endregion
        #region 删除博客标签链接
        /// <summary>
        /// 删除博客标签链接
        /// </summary>
        /// <param name="blogLableId"></param>
        /// <returns></returns>
        public IActionResult DeleteBlogLable(List<string> blogLableId)
        {
            var resModel = new ResponseModel();
            //此处删除进行逻辑删除
            var handleResult = _blogLableBLL.DelBlogLable(blogLableId);
            resModel.RetCode = handleResult.Result ? StatesCode.success : StatesCode.failure;
            resModel.RetMsg = handleResult.Msg;
            return Ok(resModel);
        }
        #endregion
    }
}