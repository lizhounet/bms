#pragma checksum "C:\bms\ZhouliProject\Blog\Views\Error\_404.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "969c1a82955c8d70b058a091a2ef9e5d0acdd8e5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Error__404), @"mvc.1.0.view", @"/Views/Error/_404.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Error/_404.cshtml", typeof(AspNetCore.Views_Error__404))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"969c1a82955c8d70b058a091a2ef9e5d0acdd8e5", @"/Views/Error/_404.cshtml")]
    public class Views_Error__404 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 25, true);
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            EndContext();
            BeginContext(25, 2024, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f06e201f2d3c47b4936e57b328ce7d7e", async() => {
                BeginContext(31, 2011, true);
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <title>/(ㄒoㄒ)/~~</title>
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0"">
    <meta http-equiv=""X-UA-Compatible"" content=""ie=edge"">

    <style>
        * {
            padding: 0;
            margin: 0
        }

        a {
            text-decoration: none
        }

        .notfoud-container .img-404 {
            height: 155px;
            background: url(/images/page-404_39c5442.png) center center no-repeat;
            -webkit-background-size: 150px auto;
            margin-top: 40px;
            margin-bottom: 20px
        }

        .notfoud-container .notfound-p {
            line-height: 22px;
            font-size: 17px;
            padding-bottom: 15px;
            border-bottom: 1px solid #f6f6f6;
            text-align: center;
            color: #262b31
        }

        .notfoud-container .notfound-reason {
            color: #9ca4ac;
            font-size: 13px;");
                WriteLiteral(@"
            line-height: 13px;
            text-align: left;
            width: 210px;
            margin: 0 auto
        }

            .notfoud-container .notfound-reason p {
                margin-top: 13px
            }

            .notfoud-container .notfound-reason ul li {
                margin-top: 10px;
                margin-left: 36px
            }

        .notfoud-container .notfound-btn-container {
            margin: 40px auto 0;
            text-align: center
        }

            .notfoud-container .notfound-btn-container .notfound-btn {
                display: inline-block;
                border: 1px solid #ebedef;
                background-color: #239bf0;
                color: #fff;
                font-size: 15px;
                border-radius: 5px;
                text-align: center;
                padding: 10px;
                line-height: 16px;
                white-space: nowrap
            }
    </style>

");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2049, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(2051, 471, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f9969c12ee41475699cf8d3df98b2493", async() => {
                BeginContext(2057, 458, true);
                WriteLiteral(@"

    <div class=""notfoud-container"">
        <div class=""img-404"">
        </div>
        <p class=""notfound-p"">哎呀迷路了...</p>
        <div class=""notfound-reason"">
            <p>可能的原因：</p>
            <ul>
                <li>原来的页面不存在了</li>
                <li>我们的服务器被外星人劫持了</li>
            </ul>
        </div>
        <div class=""notfound-btn-container"">
            <a class=""notfound-btn"" href=""/"">返回首页</a>
        </div>
    </div>

");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2522, 11, true);
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
