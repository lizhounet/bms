using Zhouli.DI;
using Microsoft.AspNetCore.Mvc;
using Zhouli.BLL.Interface;
using ZhouliSystem.Data;
using ZhouliSystem.Filters;

namespace ZhouliSystem.Components
{
    [ViewComponent(Name = "Navigation")]
    [VerificationLogin]
    public class NavigationViewComponent : ViewComponent
    {
        private readonly UserAccount _userAccount;
        private readonly ISysMenuBLL _sysMenuBLL;
        public NavigationViewComponent(UserAccount userAccount, ISysMenuBLL sysMenuBLL)
        {
            _userAccount = userAccount;
            _sysMenuBLL = sysMenuBLL;
        }
        public IViewComponentResult Invoke()
        {
            var user = _userAccount.GetUserInfo();
            var MenuDto = _sysMenuBLL.GetMenusBy(user).Data;
            return View(MenuDto);
        }
    }
}
