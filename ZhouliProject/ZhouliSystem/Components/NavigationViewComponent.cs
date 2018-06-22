using DInjectionProvider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zhouli.BLL.Interface;
using ZhouliSystem.Filters;

namespace ZhouliSystem.Components
{
    [ViewComponent(Name = "Navigation")]
    [VerificationLogin]
    public class NavigationViewComponent: ViewComponent
    {
        private readonly WholeInjection injection;
        public NavigationViewComponent(WholeInjection injection)
        {
            this.injection = injection;
        }
        public IViewComponentResult Invoke()
        {
            var user=injection.GetHttpContext.HttpContext.Session.GetSession<Zhouli.DbEntity.Models.SysUser>("UserLogin");
            var MenuDto =  injection.GetExamples<ISysMenuBLL>().GetMenusBy(user);
            return View(MenuDto);
        }
    }
}
