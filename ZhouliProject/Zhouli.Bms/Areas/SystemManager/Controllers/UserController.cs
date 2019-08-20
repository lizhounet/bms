using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zhouli.DI;
using Microsoft.AspNetCore.Mvc;
using Zhouli.BLL;
using Zhouli.BLL.Interface;
using Zhouli.Common;
using Zhouli.Dto.ModelDto;
using Zhouli.DbEntity.Models;
using ZhouliSystem.Filters;
using ZhouliSystem.Models;
using ZhouliSystem.Data;
using Zhouli.CommonEntity;
using Zhouli.Enum;

namespace ZhouliSystem.Areas.SystemManager.Controllers
{
    [VerificationLogin]
    [Area("System")]
    public class UserController : Controller
    {
        private readonly ISysUserGroupBLL _sysUserGroupBLL;
        private readonly ISysUserBLL _sysUserBLL;
        private readonly UserAccount _userAccount;
        public UserController(ISysUserGroupBLL sysUserGroupBLL, ISysUserBLL sysUserBLL, UserAccount userAccount)
        {
            _sysUserGroupBLL = sysUserGroupBLL;
            _sysUserBLL = sysUserBLL;
            _userAccount = userAccount;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserAdd()
        {
            ViewBag.UserGroupList = _sysUserGroupBLL.GetModels(t => t.DeleteSign.Equals((int)DeleteSign.Sing_Deleted));
            return View();
        }
        #region 获取用户列表
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="limit">页容量</param>
        /// <param name="searchstr">搜索内容</param>
        /// <returns></returns>
        public IActionResult GetUserList(string page, string limit, string searchstr)
        {
            var messageModel = _sysUserBLL
                .GetUserList(page, limit, searchstr);
            return Ok(new
            {
                code = 0,
                msg = "获取成功",
                count = messageModel.Data.RowCount,
                data = messageModel.Data.Data
            });
        }
        #endregion
        #region 添加/编辑用户
        /// <summary>
        /// 添加/编辑用户
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public IActionResult AddorEditUser(SysUserDto userDto)
        {
            var resModel = new ResponseModel();
            var userLogin = _userAccount.GetUserInfo();
            var handleResult = _sysUserBLL.AddorEditUser(userDto, userLogin.UserId);
            resModel.RetCode = handleResult.Result ? StatesCode.success : StatesCode.failure;
            resModel.RetMsg = handleResult.Msg;
            resModel.Data = handleResult.Data;
            return Ok(resModel);
        }
        #endregion
        #region 禁用/启用用户
        /// <summary>
        /// 禁用/启用用户
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public IActionResult DisableUser(string UserId)
        {
            var resModel = new ResponseModel();
            if (!string.IsNullOrEmpty(UserId))
            {
                var user = _sysUserBLL.GetModels(t => t.UserId.Equals(UserId)).SingleOrDefault();
                user.UserStatus = user.UserStatus == 0 ? 1 : 0;
                _sysUserBLL.Update(user);
                resModel.RetMsg = user.UserStatus == 1 ? "启用成功" : "禁用成功";
            }
            else
            {
                resModel.RetCode = StatesCode.failure;
                resModel.RetMsg = "操作失败";
            }
            return Ok(resModel);
        }
        #endregion
        #region 批量删除用户
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public IActionResult DelUser(List<string> UserId)
        {
            var resModel = new ResponseModel();
            //此处删除进行逻辑删除
            var handleResult = _sysUserBLL.DelUser(UserId);
            resModel.RetCode = handleResult.Result ? StatesCode.success : StatesCode.failure;
            resModel.RetMsg = handleResult.Msg;
            return Ok(resModel);
        }
        #endregion
    }
}