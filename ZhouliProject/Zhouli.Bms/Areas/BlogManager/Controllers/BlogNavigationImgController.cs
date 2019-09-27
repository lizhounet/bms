using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Zhouli.BLL;
using Zhouli.BLL.Interface;
using Zhouli.Common.ResultModel;
using Zhouli.DbEntity.Models;
using Zhouli.DI;
using ZhouliSystem.Data;
using ZhouliSystem.Filters;
using ZhouliSystem.Models;

namespace Zhouli.Bms.Areas.BlogManager.Controllers
{
    [VerificationLogin]
    [Area("Blog")]
    public class BlogNavigationImgController : Controller
    {
        private readonly IOptionsSnapshot<CustomConfiguration> _optionsSnapshot;
        private readonly UserAccount _userAccount;
        private readonly IBlogNavigationImgBLL _blogNavigationImgBLL;
        public BlogNavigationImgController(IOptionsSnapshot<CustomConfiguration> optionsSnapshot,
            UserAccount userAccount, IBlogNavigationImgBLL blogNavigationImgBLL)
        {
            _optionsSnapshot = optionsSnapshot;
            _userAccount = userAccount;
            _blogNavigationImgBLL = blogNavigationImgBLL;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BlogNavigationImgAdd()
        {
            ViewBag.FileServiceAdress = _optionsSnapshot.Value.FileServiceAdress;
            return View();
        }
        #region 获取博客轮播图分页数据
        /// <summary>
        /// 获取博客轮播图分页数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="searchstr"></param>
        /// <returns></returns>
        public IActionResult GetBlogNavigationImgList(string page, string limit, string searchstr)
        {
            return Ok(new
            {
                code = 0,
                msg = "获取成功",
                count = _blogNavigationImgBLL.GetCount(t => t.NavigationImgDescribe.Contains(searchstr)),
                data = _blogNavigationImgBLL.GetModelsByPage(int.Parse(limit), int.Parse(page), false, t => t.NavigationImgSortValue, t => t.NavigationImgDescribe.Contains(searchstr))
            });
        }
        #endregion
        //#region 添加博客轮播图链接
        ///// <summary>
        ///// 添加博客轮播图链接
        ///// </summary>
        ///// <param name="bl"></param>
        ///// <returns></returns>
        //public IActionResult AddorUpdateBlogNavigationImg(BlogNavigationImgDto bl)
        //{
        //    var resModel = new ResponseModel();
        //    var handleResult = _blogNavigationImgBLL.AddorEditBlogNavigationImg(bl, _userAccount.GetUserInfo().UserId);
        //    resModel.RetCode = handleResult.Result ? StatesCode.success : StatesCode.failure;
        //    resModel.RetMsg = handleResult.Msg;
        //    resModel.Data = handleResult.Data;
        //    return Ok(resModel);
        //}
        //#endregion
        //#region 删除博客轮播图链接
        ///// <summary>
        ///// 删除博客轮播图链接
        ///// </summary>
        ///// <param name="blogNavigationImgId"></param>
        ///// <returns></returns>
        //public IActionResult DeleteBlogNavigationImg(List<string> blogNavigationImgId)
        //{
        //    var resModel = new ResponseModel();
        //    //此处删除进行逻辑删除
        //    var handleResult = _blogNavigationImgBLL.DelBlogNavigationImg(blogNavigationImgId);
        //    resModel.RetCode = handleResult.Result ? StatesCode.success : StatesCode.failure;
        //    resModel.RetMsg = handleResult.Msg;
        //    return Ok(resModel);
        //}
        //#endregion
    }
}