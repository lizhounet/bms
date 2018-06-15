using DInjectionProvider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Zhouli.BLL.Interface;

namespace ZhouliSystem.Components
{
    [ViewComponent(Name = "Navigation")]
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
            var MenuDto =  injection.GetExamples<ISysMenuBLL>().GetMenusBy(user.UserId);
            return View(MenuDto);
        }
    }
}
