#pragma checksum "F:\CODE\后台管理系统\bms\ZhouliProject\ZhouliSystem\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fc4a9530746253f92b24119d36cd02d408a32353"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc4a9530746253f92b24119d36cd02d408a32353", @"/Views/Home/Index.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Zhouli.DbEntity.Models.SysUser>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "F:\CODE\后台管理系统\bms\ZhouliProject\ZhouliSystem\Views\Home\Index.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";
    ViewData["Title"] = "后台管理系统主页";
    

#line default
#line hidden
            BeginContext(136, 1703, true);
            WriteLiteral(@"<div class=""layui-layout layui-layout-admin"">
    <!-- 顶部 -->
    <div class=""layui-header header"">
        <div class=""layui-main mag0"">
            <a href=""#"" class=""logo"">后台管理系统</a>
            <!-- 显示/隐藏菜单 -->
            <a href=""javascript:;"" class=""seraph hideMenu icon-caidan""></a>
            <!-- 顶级菜单 -->
            <ul class=""layui-nav mobileTopLevelMenus"" mobile>
                <li class=""layui-nav-item"" data-menu=""contentManagement"">
                    <a href=""javascript:;""><i class=""seraph icon-caidan""></i><cite>layuiCMS</cite></a>
                    <dl class=""layui-nav-child"">
                        <dd class=""layui-this"" data-menu=""contentManagement""><a href=""javascript:;""><i class=""layui-icon"" data-icon=""&#xe63c;"">&#xe63c;</i><cite>内容管理</cite></a></dd>
                        <dd data-menu=""memberCenter""><a href=""javascript:;""><i class=""seraph icon-icon10"" data-icon=""icon-icon10""></i><cite>用户中心</cite></a></dd>
                        <dd data-menu=""systemeSttings""><a href");
            WriteLiteral(@"=""javascript:;""><i class=""layui-icon"" data-icon=""&#xe620;"">&#xe620;</i><cite>系统设置</cite></a></dd>
                        <dd data-menu=""seraphApi""><a href=""javascript:;""><i class=""layui-icon"" data-icon=""&#xe705;"">&#xe705;</i><cite>使用文档</cite></a></dd>
                    </dl>
                </li>
            </ul>
            <!-- 顶部右侧菜单 -->
            <ul class=""layui-nav top_menu"">
                <li class=""layui-nav-item lockcms"" pc>
                    <a href=""javascript:;""><i class=""seraph icon-lock""></i><cite>锁屏</cite></a>
                </li>
                <li class=""layui-nav-item"" id=""userInfo"">
                    <a href=""javascript:;""><img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1839, "\"", 1862, 1);
#line 32 "F:\CODE\后台管理系统\bms\ZhouliProject\ZhouliSystem\Views\Home\Index.cshtml"
WriteAttributeValue("", 1845, Model.UserAvatar, 1845, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1863, 81, true);
            WriteLiteral(" class=\"layui-nav-img userAvatar\" width=\"35\" height=\"35\"><cite class=\"adminName\">");
            EndContext();
            BeginContext(1945, 18, false);
#line 32 "F:\CODE\后台管理系统\bms\ZhouliProject\ZhouliSystem\Views\Home\Index.cshtml"
                                                                                                                                                   Write(Model.UserNikeName);

#line default
#line hidden
            EndContext();
            BeginContext(1963, 773, true);
            WriteLiteral(@"</cite></a>
                    <dl class=""layui-nav-child"">
                        <dd><a href=""javascript:;"" data-url=""page/user/userInfo.html""><i class=""seraph icon-ziliao"" data-icon=""icon-ziliao""></i><cite>个人资料</cite></a></dd>
                        <dd><a href=""javascript:;"" data-url=""page/user/changePwd.html""><i class=""seraph icon-xiugai"" data-icon=""icon-xiugai""></i><cite>修改密码</cite></a></dd>
                        <dd><a href=""/User/Login"" class=""signOut""><i class=""seraph icon-tuichu""></i><cite>退出</cite></a></dd>
                    </dl>
                </li>
            </ul>
        </div>
    </div>
    <!-- 左侧导航 -->
    <div class=""layui-side layui-bg-black"">
        <div class=""user-photo"">
            <a class=""img"" title=""我的头像""><img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 2736, "\"", 2759, 1);
#line 45 "F:\CODE\后台管理系统\bms\ZhouliProject\ZhouliSystem\Views\Home\Index.cshtml"
WriteAttributeValue("", 2742, Model.UserAvatar, 2742, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2760, 67, true);
            WriteLiteral(" class=\"userAvatar\"></a>\r\n            <p>您好！<span class=\"userName\">");
            EndContext();
            BeginContext(2828, 18, false);
#line 46 "F:\CODE\后台管理系统\bms\ZhouliProject\ZhouliSystem\Views\Home\Index.cshtml"
                                    Write(Model.UserNikeName);

#line default
#line hidden
            EndContext();
            BeginContext(2846, 35, true);
            WriteLiteral("</span>, 欢迎登录</p>\r\n        </div>\r\n");
            EndContext();
            BeginContext(3644, 81, true);
            WriteLiteral("        <div class=\"left-nav\">\r\n            <div id=\"side-nav\">\r\n                ");
            EndContext();
            BeginContext(3726, 41, false);
#line 63 "F:\CODE\后台管理系统\bms\ZhouliProject\ZhouliSystem\Views\Home\Index.cshtml"
           Write(await Component.InvokeAsync("Navigation"));

#line default
#line hidden
            EndContext();
            BeginContext(3767, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(8529, 1588, true);
            WriteLiteral(@"            </div>
        </div>
    </div>
    <!-- 右侧内容 -->
    <div class=""layui-body layui-form"">
        <div class=""layui-tab mag0"" lay-filter=""bodyTab"" lay-allowClose=""true""  id=""top_tabs_box"">
            <ul class=""layui-tab-title top_tab"" id=""top_tabs"">
                <li class=""layui-this"" lay-id=""""><i class=""layui-icon"">&#xe68e;</i><cite id=""houtaihome"" >后台首页</cite></li>
            </ul>
            <ul class=""layui-nav closeBox"">
                <li class=""layui-nav-item"">
                    <a href=""javascript:;""><i class=""layui-icon caozuo"">&#xe643;</i> 页面操作</a>
                    <dl class=""layui-nav-child"">
                        <dd><a href=""javascript:;"" class=""refresh refreshThis""><i class=""layui-icon"">&#x1002;</i> 刷新当前</a></dd>
                        <dd><a href=""javascript:;"" class=""closePageOther""><i class=""seraph icon-prohibit""></i> 关闭其他</a></dd>
                        <dd><a href=""javascript:;"" class=""closePageAll""><i class=""seraph icon-guanbi""></i> 关闭全部</a></dd");
            WriteLiteral(@">
                    </dl>
                </li>
            </ul>
            <div class=""layui-tab-content clildFrame"">
                <div class=""layui-tab-item layui-show"">
                    <iframe src=""/Home/Welcome""></iframe>
                </div>
            </div>
        </div>
    </div>
    <!-- 底部 -->
    <div class=""layui-footer footer"">
        <p><span>copyright 2018 作者:周黎</span>
    </div>
</div>
<!-- 移动导航 -->
<div class=""site-tree-mobile""><i class=""layui-icon"">&#xe602;</i></div>
<div class=""site-mobile-shade""></div>
");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Zhouli.DbEntity.Models.SysUser> Html { get; private set; }
    }
}
#pragma warning restore 1591
