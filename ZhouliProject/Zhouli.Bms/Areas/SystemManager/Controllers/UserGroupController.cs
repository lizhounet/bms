using System;
using System.Collections.Generic;
using System.Linq;
using Zhouli.DI;
using Microsoft.AspNetCore.Mvc;
using Zhouli.BLL;
using Zhouli.BLL.Interface;
using Zhouli.Common;
using Zhouli.Dto.ModelDto;
using Zhouli.DbEntity.Models;
using ZhouliSystem.Data;
using ZhouliSystem.Filters;
using ZhouliSystem.Models;
using Zhouli.CommonEntity;
using Zhouli.Enum;

namespace ZhouliSystem.Areas.SystemManager.Controllers
{
    [VerificationLogin]
    [Area("System")]
    public class UserGroupController : Controller
    {
        private readonly ISysUserGroupBLL _sysUserGroupBLL;
        private readonly UserAccount _userAccount;
        public UserGroupController(ISysUserGroupBLL sysUserGroupBLL, UserAccount userAccount)
        {
            _sysUserGroupBLL = sysUserGroupBLL;
            _userAccount = userAccount;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserGroupAdd(string UserGroupId)
        {

            ViewBag.UserGroupList = _sysUserGroupBLL.GetModels(t => (Guid.Empty.ToString().Equals(UserGroupId) || !t.UserGroupId.Equals(UserGroupId)) && t.DeleteSign.Equals((int)DeleteSign.Sing_Deleted));
            return View();
        }
        #region 获取分页用户组数据
        /// <summary>
        /// 获取分页用户组数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="searchstr"></param>
        /// <returns></returns>
        public IActionResult GetUserGroupList(string page, string limit, string searchstr)
        {
            var messageModel = _sysUserGroupBLL
                 .GetUserGroupList(page, limit, searchstr);
            return Ok(new
            {
                code = 0,
                msg = "获取成功",
                count = messageModel.Data.RowCount,
                data = messageModel.Data.Data
            });
        }
        #endregion
        #region 添加/修改用户组
        /// <summary>
        /// 添加/修改用户组
        /// </summary>
        /// <param name="userGroupDto"></param>
        /// <returns></returns>
        public IActionResult AddorEditUserGroup(SysUserGroupDto userGroupDto)
        {
            bool bResult = true;
            string sMessage = "保存成功";
            var userGroup = AutoMapper.Mapper.Map<SysUserGroup>(userGroupDto);
            if (_sysUserGroupBLL.GetCount(t => t.UserGroupName.Equals(userGroupDto.UserGroupName) && !t.UserGroupId.Equals(userGroupDto.UserGroupId) && t.DeleteSign.Equals((int)DeleteSign.Sing_Deleted)) > 0)
            {
                sMessage = "用户组名称不能重复";
                bResult = !bResult;
            }
            else
            {
                //添加
                if (userGroupDto.UserGroupId == null)
                {
                    userGroup.CreateTime = DateTime.Now;
                    userGroup.DeleteSign = (Int32)DeleteSign.Sing_Deleted;
                    userGroup.CreateUserId = _userAccount.GetUserInfo().UserId;
                    userGroup.CreateTime = DateTime.Now;
                    bResult = _sysUserGroupBLL.Add(userGroup);

                }
                else//修改
                {
                    var userGroup_Edit = _sysUserGroupBLL.GetModels(t => t.UserGroupId.Equals(userGroup.UserGroupId)).SingleOrDefault();
                    userGroup_Edit.UserGroupName = userGroup.UserGroupName;
                    userGroup_Edit.ParentUserGroupId = userGroup.ParentUserGroupId;
                    userGroup_Edit.EditTime = DateTime.Now;
                    userGroup_Edit.Note = userGroup.Note;
                    bResult = _sysUserGroupBLL.Update(userGroup_Edit);
                }
            }
            return Ok(new ResponseModel
            {
                RetCode = bResult ? StatesCode.success : StatesCode.failure,
                RetMsg = sMessage
            });
        }
        #endregion
        #region 批量删除用户组
        /// <summary>
        /// 批量删除用户组
        /// </summary>
        /// <param name="UserGroupId"></param>
        /// <returns></returns>
        public IActionResult DelUserGroup(List<string> UserGroupId)
        {
            var resModel = new ResponseModel();
            //此处删除进行逻辑删除
            var handleResult = _sysUserGroupBLL.DelUserGroup(UserGroupId);
            resModel.RetCode = handleResult.Result ? StatesCode.success : StatesCode.failure;
            resModel.RetMsg = handleResult.Msg;
            return Ok(resModel);
        }
        #endregion
    }
}