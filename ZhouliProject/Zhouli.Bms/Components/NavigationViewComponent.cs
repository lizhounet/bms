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
        private readonly WholeInjection _injection;
        public NavigationViewComponent(WholeInjection injection)
        {
            _injection = injection;
        }
        public IViewComponentResult Invoke()
        {
            var user = _injection.GetT<UserAccount>().GetUserInfo();
            var MenuDto = _injection.GetT<ISysMenuBLL>().GetMenusBy(user).Data;
            return View(MenuDto);
        }
    }
}
