#pragma checksum "F:\CODE\资料文档\个人项目\bms\ZhouliProject\ZhouliSystem\Views\Shared\Components\Navigation\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "66c71c0bddeddac29e98a9867f15ca7ae295f421"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Navigation_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Navigation/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/Navigation/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_Navigation_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66c71c0bddeddac29e98a9867f15ca7ae295f421", @"/Views/Shared/Components/Navigation/Default.cshtml")]
    public class Views_Shared_Components_Navigation_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Zhouli.BLL.SysMenuDto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(36, 17, true);
            WriteLiteral("\r\n<ul id=\"nav\">\r\n");
            EndContext();
#line 4 "F:\CODE\资料文档\个人项目\bms\ZhouliProject\ZhouliSystem\Views\Shared\Components\Navigation\Default.cshtml"
     foreach (var item1 in Model)
    {

#line default
#line hidden
            BeginContext(95, 123, true);
            WriteLiteral("        <li>\r\n            <a href=\"javascript:;\">\r\n                <i class=\"iconfont\">&#xe6b8;</i>\r\n                <cite>");
            EndContext();
            BeginContext(219, 14, false);
#line 9 "F:\CODE\资料文档\个人项目\bms\ZhouliProject\ZhouliSystem\Views\Shared\Components\Navigation\Default.cshtml"
                 Write(item1.MenuName);

#line default
#line hidden
            EndContext();
            BeginContext(233, 87, true);
            WriteLiteral("</cite>\r\n                <i class=\"iconfont nav_right\">&#xe697;</i>\r\n            </a>\r\n");
            EndContext();
#line 12 "F:\CODE\资料文档\个人项目\bms\ZhouliProject\ZhouliSystem\Views\Shared\Components\Navigation\Default.cshtml"
             if (item1.children.Count > 0)
            {

#line default
#line hidden
            BeginContext(379, 39, true);
            WriteLiteral("                <ul class=\"sub-menu\">\r\n");
            EndContext();
#line 15 "F:\CODE\资料文档\个人项目\bms\ZhouliProject\ZhouliSystem\Views\Shared\Components\Navigation\Default.cshtml"
                     foreach (var item2 in item1.children)
                    {
                        if (item2.children.Count > 0)
                        {

#line default
#line hidden
            BeginContext(583, 89, true);
            WriteLiteral("                            <li>\r\n                                <ul class=\"sub-menu\">\r\n");
            EndContext();
#line 21 "F:\CODE\资料文档\个人项目\bms\ZhouliProject\ZhouliSystem\Views\Shared\Components\Navigation\Default.cshtml"
                                     foreach (var item3 in item2.children)
                                    {

#line default
#line hidden
            BeginContext(787, 92, true);
            WriteLiteral("                                        <li>\r\n                                            <a");
            EndContext();
            BeginWriteAttribute("_href", " _href=\"", 879, "\"", 901, 1);
#line 24 "F:\CODE\资料文档\个人项目\bms\ZhouliProject\ZhouliSystem\Views\Shared\Components\Navigation\Default.cshtml"
WriteAttributeValue("", 887, item3.MenuUrl, 887, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(902, 139, true);
            WriteLiteral(">\r\n                                                <i class=\"iconfont\">&#xe6a7;</i>\r\n                                                <cite>");
            EndContext();
            BeginContext(1042, 14, false);
#line 26 "F:\CODE\资料文档\个人项目\bms\ZhouliProject\ZhouliSystem\Views\Shared\Components\Navigation\Default.cshtml"
                                                 Write(item3.MenuName);

#line default
#line hidden
            EndContext();
            BeginContext(1056, 106, true);
            WriteLiteral("</cite>\r\n                                            </a>\r\n                                        </li>\r\n");
            EndContext();
#line 29 "F:\CODE\资料文档\个人项目\bms\ZhouliProject\ZhouliSystem\Views\Shared\Components\Navigation\Default.cshtml"
                                    }

#line default
#line hidden
            BeginContext(1201, 74, true);
            WriteLiteral("                                </ul>\r\n                            </li>\r\n");
            EndContext();
#line 32 "F:\CODE\资料文档\个人项目\bms\ZhouliProject\ZhouliSystem\Views\Shared\Components\Navigation\Default.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(1359, 68, true);
            WriteLiteral("                            <li>\r\n                                <a");
            EndContext();
            BeginWriteAttribute("_href", " _href=\"", 1427, "\"", 1449, 1);
#line 36 "F:\CODE\资料文档\个人项目\bms\ZhouliProject\ZhouliSystem\Views\Shared\Components\Navigation\Default.cshtml"
WriteAttributeValue("", 1435, item2.MenuUrl, 1435, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1450, 115, true);
            WriteLiteral(">\r\n                                    <i class=\"iconfont\">&#xe6a7;</i>\r\n                                    <cite>");
            EndContext();
            BeginContext(1566, 14, false);
#line 38 "F:\CODE\资料文档\个人项目\bms\ZhouliProject\ZhouliSystem\Views\Shared\Components\Navigation\Default.cshtml"
                                     Write(item2.MenuName);

#line default
#line hidden
            EndContext();
            BeginContext(1580, 82, true);
            WriteLiteral("</cite>\r\n                                </a>\r\n                            </li>\r\n");
            EndContext();
#line 41 "F:\CODE\资料文档\个人项目\bms\ZhouliProject\ZhouliSystem\Views\Shared\Components\Navigation\Default.cshtml"
                        }
                    }

#line default
#line hidden
            BeginContext(1712, 23, true);
            WriteLiteral("                </ul>\r\n");
            EndContext();
#line 44 "F:\CODE\资料文档\个人项目\bms\ZhouliProject\ZhouliSystem\Views\Shared\Components\Navigation\Default.cshtml"
            }

#line default
#line hidden
            BeginContext(1750, 15, true);
            WriteLiteral("        </li>\r\n");
            EndContext();
#line 46 "F:\CODE\资料文档\个人项目\bms\ZhouliProject\ZhouliSystem\Views\Shared\Components\Navigation\Default.cshtml"
    }

#line default
#line hidden
            BeginContext(1772, 7, true);
            WriteLiteral("</ul>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Zhouli.BLL.SysMenuDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
