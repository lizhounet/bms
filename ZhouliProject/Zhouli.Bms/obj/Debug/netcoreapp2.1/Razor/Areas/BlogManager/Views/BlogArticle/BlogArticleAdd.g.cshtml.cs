#pragma checksum "D:\周黎\code\bms\ZhouliProject\Zhouli.Bms\Areas\BlogManager\Views\BlogArticle\BlogArticleAdd.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e93476d8d4daa977f08e32e3614b320b6538c39c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BlogManager_Views_BlogArticle_BlogArticleAdd), @"mvc.1.0.view", @"/Areas/BlogManager/Views/BlogArticle/BlogArticleAdd.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BlogManager/Views/BlogArticle/BlogArticleAdd.cshtml", typeof(AspNetCore.Areas_BlogManager_Views_BlogArticle_BlogArticleAdd))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e93476d8d4daa977f08e32e3614b320b6538c39c", @"/Areas/BlogManager/Views/BlogArticle/BlogArticleAdd.cshtml")]
    public class Areas_BlogManager_Views_BlogArticle_BlogArticleAdd : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/layui/css/layui.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/public.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/main.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/require/require.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-main", new global::Microsoft.AspNetCore.Html.HtmlString("../js/Areas/BlogManager/BlogArticle/BlogArticleAdd"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "D:\周黎\code\bms\ZhouliProject\Zhouli.Bms\Areas\BlogManager\Views\BlogArticle\BlogArticleAdd.cshtml"
  
    Layout = "~/Views/Shared/Ordinary.cshtml";
    ViewData["Title"] = "BlogArticleAdd";

#line default
#line hidden
            DefineSection("css", async() => {
                BeginContext(111, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(117, 58, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "48e6dfda693845ad96b597d616924504", async() => {
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
                BeginContext(175, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(181, 49, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "43912e315b2d4aeeb6a48fa0e1a0a9f7", async() => {
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
                BeginContext(230, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(235, 2163, true);
            WriteLiteral(@"<div style=""padding:20px;"">
    <form class=""layui-form layui-row layui-col-space10"">
        <input type=""hidden"" class=""articleId"" name=""articleId"" />
        <input type=""hidden"" class=""articleSortValue"" name=""articleSortValue"" />
        <div class=""layui-col-md9 layui-col-xs12"">
            <div class=""layui-row layui-col-space10"">
                <div class=""layui-col-md9 layui-col-xs7"">
                    <div class=""layui-form-item magt3"">
                        <label class=""layui-form-label"">文章标题</label>
                        <div class=""layui-input-block"">
                            <input type=""text"" class=""layui-input articleTitle"" name=""articleTitle"" lay-verify=""articleTitle"" placeholder=""请输入文章标题"" />
                        </div>
                    </div>
                    <div class=""layui-form-item"">
                        <label class=""layui-form-label"">内容摘要</label>
                        <div class=""layui-input-block"">
                            <textarea placehol");
            WriteLiteral(@"der=""请输入内容摘要(不填默认截取文章内容前个50字)"" name=""articleBodySummary"" class=""layui-textarea abstract articleBodySummary""></textarea>
                        </div>
                    </div>
                </div>
                <div class=""layui-col-md3 layui-col-xs5"">
                    <div class=""layui-upload-list thumbBox mag0 magt3"">
                        <img class=""layui-upload-img thumbImg articleThrink"" id=""articleThrink"" src=""/"" />
                    </div>
                </div>
            </div>
            <div class=""layui-form-item magb0"">
                <label class=""layui-form-label"">文章内容</label>
                <div class=""layui-input-block"">
                    <textarea class=""layui-textarea layui-hide articleBody"" name=""content"" lay-verify=""content"" id=""articleBody""></textarea>
                </div>
            </div>
        </div>
        <div class=""layui-col-md3 layui-col-xs12"">
            <blockquote class=""layui-elem-quote title""><i class=""seraph icon-caidan""></i>博客标签");
            WriteLiteral("</blockquote>\r\n            <div class=\"border category\">\r\n                <div class=\"\">\r\n                    <p>\r\n");
            EndContext();
#line 47 "D:\周黎\code\bms\ZhouliProject\Zhouli.Bms\Areas\BlogManager\Views\BlogArticle\BlogArticleAdd.cshtml"
                         foreach (var blogLable in ViewBag.ListBlogLable)
                        {

#line default
#line hidden
            BeginContext(2500, 65, true);
            WriteLiteral("                            <input type=\"checkbox\" name=\"lableId\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2565, "\"", 2591, 1);
#line 49 "D:\周黎\code\bms\ZhouliProject\Zhouli.Bms\Areas\BlogManager\Views\BlogArticle\BlogArticleAdd.cshtml"
WriteAttributeValue("", 2573, blogLable.LableId, 2573, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 2592, "\"", 2620, 1);
#line 49 "D:\周黎\code\bms\ZhouliProject\Zhouli.Bms\Areas\BlogManager\Views\BlogArticle\BlogArticleAdd.cshtml"
WriteAttributeValue("", 2600, blogLable.LableName, 2600, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2621, 24, true);
            WriteLiteral(" lay-skin=\"primary\" />\r\n");
            EndContext();
#line 50 "D:\周黎\code\bms\ZhouliProject\Zhouli.Bms\Areas\BlogManager\Views\BlogArticle\BlogArticleAdd.cshtml"
                        }

#line default
#line hidden
            BeginContext(2672, 1045, true);
            WriteLiteral(@"                    </p>
                </div>
            </div>
            <blockquote class=""layui-elem-quote title magt10""><i class=""layui-icon"">&#xe609;</i> 发布</blockquote>
            <div class=""border"">
                <div class=""layui-form-item newsTop"">
                    <label class=""layui-form-label""><i class=""seraph icon-zhiding""></i> 置　顶</label>
                    <div class=""layui-input-block"">
                        <input type=""checkbox"" name=""articleTop"" id=""articleTop"" lay-skin=""switch"" lay-text=""是|否"">
                    </div>
                </div>
                <hr class=""layui-bg-gray"" />
                <div class=""layui-right"">
                    <a class=""layui-btn layui-btn-sm"" lay-filter=""addNews"" lay-submit><i class=""layui-icon"">&#xe609;</i>发布</a>
                    <a class=""layui-btn layui-btn-primary layui-btn-sm"" lay-filter=""look"" lay-submit>预览</a>
                </div>
            </div>
        </div>
    </form>
</div>
<input type=""hidden"" i");
            WriteLiteral("d=\"FileServiceAdress\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 3717, "\"", 3751, 1);
#line 71 "D:\周黎\code\bms\ZhouliProject\Zhouli.Bms\Areas\BlogManager\Views\BlogArticle\BlogArticleAdd.cshtml"
WriteAttributeValue("", 3725, ViewBag.FileServiceAdress, 3725, 26, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3752, 5, true);
            WriteLiteral(" />\r\n");
            EndContext();
            BeginContext(3757, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5c90c4c074934f36a18b4b590df33135", async() => {
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
            BeginContext(3794, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(3796, 111, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e1a9660c6954423b8a0b14fe21e64962", async() => {
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
            BeginContext(3907, 2, true);
            WriteLiteral("\r\n");
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
