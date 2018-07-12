using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Zhouli.BLL.Interface;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;

namespace Zhouli.BLL.Implements
{
    /// <summary>
    /// 菜单表Service接口
    /// </summary>
    public class SysMenuBLL : BaseBLL<SysMenu>, ISysMenuBLL
    {
        private List<SysMenuDto> listMenuDtos;
        private ISysMenuDAL sysMenuDAL;
        private ISysAuthorityBLL sysAuthorityBLL;
        /// <summary>
        /// 用于实例化父级，sysMenuDAL
        /// </summary>
        /// <param name="sysMenuDAL"></param>
        public SysMenuBLL(ISysMenuDAL sysMenuDAL, ISysAuthorityBLL sysAuthorityBLL) : base(sysMenuDAL)
        {
            this.sysMenuDAL = sysMenuDAL;
            this.sysAuthorityBLL = sysAuthorityBLL;
        }
        /// <summary>
        /// 根据用户获取功能菜单
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <returns></returns>
        public MessageModel GetMenusBy(SysUser user)
        {
            var listMenuDto = new List<SysMenuDto>();
            listMenuDtos = Mapper.Map<List<SysMenuDto>>(((List<SysAuthority>)(sysAuthorityBLL.GetSysAuthorities(user, ZhouLiEnum.Enum_AuthorityType.Type_Menu).Data)).Select(t => t.sysMenu).ToList());
            //找出所有一级菜单
            listMenuDto.AddRange(listMenuDtos.Where(t => t.ParentMenuId.Equals(Guid.Empty)).OrderByDescending(t => t.MenuSort));
            foreach (var item in listMenuDto)
            {
                item.children = GetMenuChildren(item.MenuId);
            }
            return new MessageModel
            {
                Data = listMenuDto
            };
        }
        private List<SysMenuDto> GetMenuChildren(Guid ParentMenuId)
        {
            var listMenuDto = listMenuDtos.Where(t => t.ParentMenuId.Equals(ParentMenuId)).OrderByDescending(t => t.MenuSort).ToList();
            foreach (var item in listMenuDto)
            {
                item.children = GetMenuChildren(item.MenuId);
            }

            return listMenuDto;
        }
    }
}
