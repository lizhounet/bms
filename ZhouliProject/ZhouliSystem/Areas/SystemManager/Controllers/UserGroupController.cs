using System;
using System.Collections.Generic;
using System.Linq;
using DInjectionProvider;
using Microsoft.AspNetCore.Mvc;
using Zhouli.BLL;
using Zhouli.BLL.Interface;
using Zhouli.Common;
using Zhouli.DbEntity.Models;
using ZhouliSystem.Data;
using ZhouliSystem.Filters;
using ZhouliSystem.Models;

namespace ZhouliSystem.Areas.SystemManager.Controllers
{
    [VerificationLogin]
    [Area("System")]
    public class UserGroupController : Controller
    {
        private readonly WholeInjection injection;
        public UserGroupController(WholeInjection injection)
        {
            this.injection = injection;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserGroupAdd(Guid? UserGroupId)
        {

            ViewBag.UserGroupList = injection.GetT<ISysUserGroupBLL>().GetModels(t => (!UserGroupId.HasValue || !t.UserGroupId.Equals(UserGroupId.Value)) && t.DeleteSign.Equals((int)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted));
            return View();
        }
        #region 获取分页也用户组数据
        /// <summary>
        /// 获取分页用户组数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="searchstr"></param>
        /// <returns></returns>
        public string GetUserGroupList(string page, string limit, string searchstr)
        {
            var messageModel = injection.GetT<ISysUserGroupBLL>()
                 .GetUserGroupList(page, limit, searchstr);
            return JsonHelper.ObjectToJson(new
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
        public string AddorEditUserGroup(SysUserGroupDto userGroupDto)
        {
            bool bResult = true;
            string sMessage = "保存成功";
            var userGroupBLL = injection.GetT<ISysUserGroupBLL>();
            var userGroup = AutoMapper.Mapper.Map<SysUserGroup>(userGroupDto);
            if (userGroupBLL.GetCount(t => t.UserGroupName.Equals(userGroupDto.UserGroupName) && !t.UserGroupId.Equals(userGroupDto.UserGroupId)&&t.DeleteSign.Equals((int)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted)) > 0)
            {
                sMessage = "用户组名称不能重复";
                bResult = !bResult;
            }
            else
            {
                //添加
                if (userGroupDto.UserGroupId.Equals(Guid.Empty))
                {

                    userGroup.DeleteSign = (Int32)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted;
                    userGroup.CreateUserId = injection.GetT<UserAccount>().GetUserInfo().UserId;
                    bResult = userGroupBLL.Add(userGroup);

                }
                else//修改
                {
                    var userGroup_Edit = userGroupBLL.GetModels(t => t.UserGroupId.Equals(userGroup.UserGroupId)).SingleOrDefault();
                    userGroup_Edit.UserGroupName = userGroup.UserGroupName;
                    userGroup_Edit.ParentUserGroupId = userGroup.ParentUserGroupId;
                    userGroup_Edit.EditTime = DateTime.Now;
                    bResult = userGroupBLL.Update(userGroup_Edit);
                }
            }
            return JsonHelper.ObjectToJson(new ResponseModel
            {
                StateCode = bResult ? StatesCode.success : StatesCode.failure,
                Messages = sMessage
            });
        }
        #endregion
        #region 批量删除用户组
        /// <summary>
        /// 批量删除用户组
        /// </summary>
        /// <param name="UserGroupId"></param>
        /// <returns></returns>
        public string DelUserGroup(List<Guid> UserGroupId)
        {
            var resModel = new ResponseModel();
            //此处删除进行逻辑删除
            MessageModel model = injection.GetT<ISysUserGroupBLL>().DelUserGroup(UserGroupId);
            resModel.StateCode = model.Result ? StatesCode.success : StatesCode.failure;
            resModel.Messages = model.Message;
            return JsonHelper.ObjectToJson(resModel);
        }
        #endregion
    }
}