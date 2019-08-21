using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zhouli.BLL;
using Zhouli.BLL.Interface;
using Zhouli.Common;
using Zhouli.Common.ResultModel;
using Zhouli.DbEntity.Models;
using Zhouli.DI;
using Zhouli.Dto.ModelDto;
using ZhouliSystem.Data;
using ZhouliSystem.Filters;
using ZhouliSystem.Models;

namespace Zhouli.Bms.Areas.BlogManager.Controllers
{
    [VerificationLogin]
    [Area("Blog")]
    public class FriendshipLinkController : Controller
    {
        private readonly IBlogFriendshipLinkBLL _blogFriendshipLinkBLL;
        private readonly UserAccount _userAccount;
        public FriendshipLinkController(IBlogFriendshipLinkBLL blogFriendshipLinkBLL, UserAccount userAccount)
        {
            _blogFriendshipLinkBLL = blogFriendshipLinkBLL;
            _userAccount = userAccount;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FriendshipLinkAdd()
        {
            return View();
        }
        #region 获取友情链接分页数据
        /// <summary>
        /// 获取友情链接分页数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="searchstr"></param>
        /// <returns></returns>
        public IActionResult GetFriendshipLinkList(string page, string limit, string searchstr)
        {
            var messageModel = _blogFriendshipLinkBLL
                 .GetFriendshipLinkList(page, limit, searchstr);
            return Ok(new
            {
                code = 0,
                msg = "获取成功",
                count = messageModel.Data.RowCount,
                data = messageModel.Data.Data
            });
        }
        #endregion
        #region 添加友情链接
        /// <summary>
        /// 添加友情链接
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        public IActionResult AddorUpdateFriendshipLink(BlogFriendshipLinkDto blog)
        {
            var resModel = new ResponseModel();
            var handleResult = _blogFriendshipLinkBLL.AddorEditFriendshipLink(blog, _userAccount.GetUserInfo().UserId);
            resModel.RetCode = handleResult.Result ? StatesCode.success : StatesCode.failure;
            resModel.RetMsg = handleResult.Msg;
            resModel.Data = handleResult.Data;
            return Ok(resModel);
        }
        #endregion

        #region 删除友情链接
        /// <summary>
        /// 删除友情链接
        /// </summary>
        /// <param name="FriendshipLinkId"></param>
        /// <returns></returns>
        public IActionResult DeleteFriendshipLink(List<string> friendshipLinkId)
        {
            var resModel = new ResponseModel();
            //此处删除进行逻辑删除
            var handleResult = _blogFriendshipLinkBLL.DelFriendshipLink(friendshipLinkId);
            resModel.RetCode = handleResult.Result ? StatesCode.success : StatesCode.failure;
            resModel.RetMsg = handleResult.Msg;
            return Ok(resModel);
        }
        #endregion
        #region 审核友情链接
        /// <summary>
        /// 审核友情链接
        /// </summary>
        /// <param name="FriendshipLinkId"></param>
        /// <returns></returns>
        public IActionResult SfFriendshipLink(int friendshipLinkId)
        {
            var resModel = new ResponseModel();
            var handleResult = _blogFriendshipLinkBLL.SfFriendshipLinkList(friendshipLinkId);
            resModel.RetCode = handleResult.Result ? StatesCode.success : StatesCode.failure;
            resModel.RetMsg = handleResult.Msg;
            return Ok(resModel);
        }
        #endregion
    }
}