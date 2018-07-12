using DInjectionProvider;
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
        private readonly WholeInjection injection;
        public NavigationViewComponent(WholeInjection injection)
        {
            this.injection = injection;
        }
        public IViewComponentResult Invoke()
        {
            var user = injection.GetExamples<UserAccount>().GetUserInfo();
            var MenuDto = injection.GetExamples<ISysMenuBLL>().GetMenusBy(user).Data;
            return View(MenuDto);
        }
    }
}
