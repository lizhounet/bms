#pragma checksum "F:\CODE\资料文档\个人项目\bms\ZhouliProject\ZhouliSystem\Areas\SystemManager\Views\UserGroup\UserGroupAdd.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b29ea960c8f92868d558b2557ab2de14e28c5454"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_SystemManager_Views_UserGroup_UserGroupAdd), @"mvc.1.0.view", @"/Areas/SystemManager/Views/UserGroup/UserGroupAdd.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/SystemManager/Views/UserGroup/UserGroupAdd.cshtml", typeof(AspNetCore.Areas_SystemManager_Views_UserGroup_UserGroupAdd))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b29ea960c8f92868d558b2557ab2de14e28c5454", @"/Areas/SystemManager/Views/UserGroup/UserGroupAdd.cshtml")]
    public class Areas_SystemManager_Views_UserGroup_UserGroupAdd : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/layui/css/layui.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/public.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/main.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/require/require.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-main", new global::Microsoft.AspNetCore.Html.HtmlString("../js/Ares/SystemManager/UserGroup/UserGroupAdd"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "F:\CODE\资料文档\个人项目\bms\ZhouliProject\ZhouliSystem\Areas\SystemManager\Views\UserGroup\UserGroupAdd.cshtml"
  
    Layout = "~/Views/Shared/Ordinary.cshtml";
    ViewData["Title"] = "用户组管理";


#line default
#line hidden
            DefineSection("css", async() => {
                BeginContext(104, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(110, 58, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "952cac9517634098a2ac2884cdb98cec", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(168, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(174, 49, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "415849fd72434a5c9601ccd97fd56f60", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(223, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(228, 720, true);
            WriteLiteral(@"<div class=""childrenBody"">
    <form class=""layui-form"" style=""width:80%;"">
        <div class=""layui-form-item layui-row layui-col-xs12"">
            <label class=""layui-form-label"">用户组名称<i style=""color:red;"">*</i></label>
            <div class=""layui-input-block"">
                <input type=""text"" class=""layui-input userGroupName"" lay-verify=""required"" placeholder=""请输入用户组名称"">
            </div>
        </div>
        <div class=""layui-form-item layui-row layui-col-xs12"">
            <label class=""layui-form-label"">父用户组<i>&nbsp;</i></label>
            <div class=""layui-input-block"">
                <select  lay-search class=""parentUserGroupId"">
                    <option value="""">请选择</option>
");
            EndContext();
#line 23 "F:\CODE\资料文档\个人项目\bms\ZhouliProject\ZhouliSystem\Areas\SystemManager\Views\UserGroup\UserGroupAdd.cshtml"
                      
                        foreach (var item in ViewBag.UserGroupList)
                        {

#line default
#line hidden
            BeginContext(1068, 35, true);
            WriteLiteral("                            <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1103, "\"", 1128, 1);
#line 26 "F:\CODE\资料文档\个人项目\bms\ZhouliProject\ZhouliSystem\Areas\SystemManager\Views\UserGroup\UserGroupAdd.cshtml"
WriteAttributeValue("", 1111, item.UserGroupId, 1111, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1129, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1131, 18, false);
#line 26 "F:\CODE\资料文档\个人项目\bms\ZhouliProject\ZhouliSystem\Areas\SystemManager\Views\UserGroup\UserGroupAdd.cshtml"
                                                         Write(item.UserGroupName);

#line default
#line hidden
            EndContext();
            BeginContext(1149, 11, true);
            WriteLiteral("</option>\r\n");
            EndContext();
#line 27 "F:\CODE\资料文档\个人项目\bms\ZhouliProject\ZhouliSystem\Areas\SystemManager\Views\UserGroup\UserGroupAdd.cshtml"
                        }
                    

#line default
#line hidden
            BeginContext(1210, 805, true);
            WriteLiteral(@"                </select>
            </div>
        </div>
        <div class=""layui-form-item layui-row layui-col-xs12"">
            <label class=""layui-form-label"">备注<i>&nbsp;</i></label>
            <div class=""layui-input-block"">
                <textarea placeholder=""备注"" class=""layui-textarea note""></textarea>
            </div>
        </div>
        <input type=""text"" style=""display:none;"" class=""userGroupId"">
        <div class=""layui-form-item layui-row layui-col-xs12"">
            <div class=""layui-input-block"">
                <button class=""layui-btn layui-btn-sm"" lay-submit="""" lay-filter=""addUserGroup"">保存</button>
                <button type=""reset"" class=""layui-btn layui-btn-sm layui-btn-primary"">重置</button>
            </div>
        </div>
    </form>
</div>
");
            EndContext();
            BeginContext(2015, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7651c0b1545b4276bd77a9e1f431aae2", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2052, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(2054, 108, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "63af7da7d0c8447b84e9edccd890a40b", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2162, 4, true);
            WriteLiteral("\r\n\r\n");
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
