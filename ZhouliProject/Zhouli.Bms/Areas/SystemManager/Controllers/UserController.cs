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

namespace ZhouliSystem.Areas.SystemManager.Controllers
{
    [VerificationLogin]
    [Area("System")]
    public class UserController : Controller
    {
        private readonly WholeInjection _injection;
        public UserController(WholeInjection injection)
        {
            _injection = injection;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserAdd()
        {
            ViewBag.UserGroupList = _injection.GetT<ISysUserGroupBLL>().GetModels(t => t.DeleteSign.Equals((int)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted));
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
        public string GetUserList(string page, string limit, string searchstr)
        {
            var messageModel = _injection.GetT<ISysUserBLL>()
                .GetUserList(page, limit, searchstr);
            return new
            {
                code = 0,
                msg = "获取成功",
                count = messageModel.Data.RowCount,
                data = messageModel.Data.Data
            }.Json();
        }
        #endregion
        #region 添加/编辑用户
        /// <summary>
        /// 添加/编辑用户
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public string AddorEditUser(SysUserDto userDto)
        {
            var resModel = new ResponseModel();
            var userLogin = _injection.GetT<UserAccount>().GetUserInfo();
            var mModel = _injection.GetT<ISysUserBLL>().AddorEditUser(userDto, userLogin.UserId);
            resModel.StateCode = mModel.Result ? StatesCode.success : StatesCode.failure;
            resModel.Messages = mModel.Message;
            resModel.JsonData = mModel.Data;
            return resModel.Json();
        }
        #endregion
        #region 禁用/启用用户
        /// <summary>
        /// 禁用/启用用户
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public string DisableUser(string UserId)
        {
            var resModel = new ResponseModel();
            if (!string.IsNullOrEmpty(UserId))
            {
                var user = _injection.GetT<ISysUserBLL>().GetModels(t => t.UserId.Equals(UserId)).SingleOrDefault();
                user.UserStatus = user.UserStatus == 0 ? 1 : 0;
                _injection.GetT<ISysUserBLL>().Update(user);
                resModel.Messages = user.UserStatus == 1 ? "启用成功" : "禁用成功";
            }
            else
            {
                resModel.StateCode = StatesCode.failure;
                resModel.Messages = "操作失败";
            }
            return resModel.Json();
        }
        #endregion
        #region 批量删除用户
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public string DelUser(List<string> UserId)
        {
            var resModel = new ResponseModel();
            //此处删除进行逻辑删除
            MessageModel model = _injection.GetT<ISysUserBLL>().DelUser(UserId);
            resModel.StateCode = model.Result ? StatesCode.success : StatesCode.failure;
            resModel.Messages = model.Message;
            return resModel.Json();
        }
        #endregion
    }
}