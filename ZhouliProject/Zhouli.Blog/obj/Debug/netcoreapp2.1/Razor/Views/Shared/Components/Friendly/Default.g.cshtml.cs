#pragma checksum "F:\zhouli\code\project\bms\ZhouliProject\Zhouli.Blog\Views\Shared\Components\Friendly\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a170510208388afd2480c51c7ad054b641c04b44"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Friendly_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Friendly/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/Friendly/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_Friendly_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a170510208388afd2480c51c7ad054b641c04b44", @"/Views/Shared/Components/Friendly/Default.cshtml")]
    public class Views_Shared_Components_Friendly_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/layui/css/layui.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/layui/layui.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(71, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(73, 58, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dc1b65c6b1664c77ab2fc8b0f71d9cf2", async() => {
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
            BeginContext(131, 103, true);
            WriteLiteral("\r\n<div class=\"content-block friendly-content row\" >\r\n    <h2 class=\"title\"><strong>本站友链</strong></h2>\r\n");
            EndContext();
            BeginContext(663, 1988, true);
            WriteLiteral(@"    <div id=""view""></div>
</div>
<div class=""content-block comment"">
    <h2 class=""title""><strong>提交友链</strong></h2>
    <form method=""post"" class=""form-inline"" id=""comment-form"">
        <div class=""comment-title"">
            <div class=""form-group"">
                <label for=""messageName"">网站名称：</label>
                <input type=""text"" name=""SiteName"" class=""form-control"" id=""SiteName"" placeholder=""网站名称"">
            </div>
            <div class=""form-group"">
                <label for=""messageEmail"">网站地址：</label>
                <input type=""text"" name=""SiteUrl"" class=""form-control"" id=""SiteUrl"" placeholder=""网站地址"">
            </div>
            <div class=""form-group"">
                <label for=""messageEmail"">站长邮箱：</label>
                <input type=""text"" name=""SiteEmail"" class=""form-control"" id=""SiteEmail"" placeholder=""xxxx@xxxx.com"">
            </div>
        </div>
        <div class=""comment-form"">
            <textarea placeholder=""请填写网站简介"" name=""messageContent"" id=""SiteS");
            WriteLiteral(@"ummary""></textarea>
            <div class=""comment-form-footer"">
                <div class=""comment-form-text"">请先 <a href=""javascript:;"">登录</a> 或 <a href=""javascript:;"">注册</a>，也可匿名提交友链 </div>
                <div class=""comment-form-btn"">
                    <button type=""submit"" id=""submitSite"" lay-submit="""" lay-filter=""submitSite"" class=""btn btn-default btn-comment"">提交友链</button>
                </div>
            </div>
        </div>
    </form>
</div>
<script id=""laytplSite"" type=""text/html"">
    {{#  layui.each(d, function(index, item){ }}
    <div class=""col-md-4 col-xs-6"">
        <span data-toggle=""tooltip"" data-placement=""bottom"" title=""点击进入 {{item.FriendshipLinkName}}""><a target=""_blank"" href=""{{item.FriendshipLinkUrl}}"">{{item.FriendshipLinkName}}</a></span>
        <p style=""height:3.5em"">{{item.Note==null?"""":item.Note}}</p>
    </div>
    {{#  }); }}
    {{#  if(d.length === 0){ }}
    无数据
    {{#  } }}
</script>
");
            EndContext();
            BeginContext(2651, 44, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a17673b5d0394821ab048cee160a8e1c", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2695, 338, true);
            WriteLiteral(@"
<script>
    layui.use(['form', 'layer','laytpl'], function () {
        var layer = layui.layer,
            form = layui.form,
            laytpl = layui.laytpl,
            $ = layui.jquery;

        var getTpl = laytplSite.innerHTML
            , view = document.getElementById('view');
        $.ajax({
            url: """);
            EndContext();
            BeginContext(3034, 22, false);
#line 67 "F:\zhouli\code\project\bms\ZhouliProject\Zhouli.Blog\Views\Shared\Components\Friendly\Default.cshtml"
             Write(ViewBag.BlogApiAddress);

#line default
#line hidden
            EndContext();
            BeginContext(3056, 240, true);
            WriteLiteral("/api/blog/getfriendly\",\r\n            type: \"GET\",\r\n            dataType: \"json\",\r\n            beforeSend: function (xhr) {\r\n                //    //发送ajax请求之前向http的head里面加入验证信息\r\n                xhr.setRequestHeader(\"Authorization\", \"Bearer ");
            EndContext();
            BeginContext(3297, 17, false);
#line 72 "F:\zhouli\code\project\bms\ZhouliProject\Zhouli.Blog\Views\Shared\Components\Friendly\Default.cshtml"
                                                         Write(ViewBag.BlogToken);

#line default
#line hidden
            EndContext();
            BeginContext(3314, 994, true);
            WriteLiteral(@""");  // 请求发起前在头部附加token
            },
            success: function (res) {
                console.log(res);
                laytpl(getTpl).render(res.Data, function (html) {
                        view.innerHTML = html;
                    });
            }
        });
        form.on(""submit(submitSite)"", function (data) {

            //弹出loading
            // var index = top.layer.msg('数据提交中，请稍候', { icon: 16, time: false, shade: 0.8 });
            var postData = {
                SiteName: $(""#SiteName"").val(),
                SiteUrl: $(""#SiteUrl"").val(),
                SiteEmail: $(""#SiteEmail"").val(),
                SiteSummary: $(""#SiteSummary"").val()
            };
            if (!/^([hH][tT]{2}[pP]:\/\/|[hH][tT]{2}[pP][sS]:\/\/|www\.)(([A-Za-z0-9-~]+)\.)+([A-Za-z0-9-~\/])+$/.test(postData.SiteUrl)) {
                layer.msg(""url格式错误!"");
                return false;
            }
            if (!new RegExp(""^[a-z0-9]+([._\\-]*[a-z0-9])*");
            EndContext();
            BeginContext(4309, 338, true);
            WriteLiteral(@"@([a-z0-9]+[-a-z0-9]*[a-z0-9]+.){1,63}[a-z0-9]+$"").test(postData.SiteEmail)) {
                layer.msg(""邮箱格式错误!"");
                return false;
            }
            if (postData.SiteSummary == """") {
                layer.msg(""请填写网站简介!"");
                return false;
            }
          $.ajax({
              url: """);
            EndContext();
            BeginContext(4648, 22, false);
#line 104 "F:\zhouli\code\project\bms\ZhouliProject\Zhouli.Blog\Views\Shared\Components\Friendly\Default.cshtml"
               Write(ViewBag.BlogApiAddress);

#line default
#line hidden
            EndContext();
            BeginContext(4670, 338, true);
            WriteLiteral(@"/api/blog/submitfriendly"",
              type: ""POST"",
              dataType: ""json"",
              data: postData,
              beforeSend: function (xhr) {
                  layer.load(2, { time: 10 * 1000 });
                //    //发送ajax请求之前向http的head里面加入验证信息
                  xhr.setRequestHeader(""Authorization"", ""Bearer ");
            EndContext();
            BeginContext(5009, 17, false);
#line 111 "F:\zhouli\code\project\bms\ZhouliProject\Zhouli.Blog\Views\Shared\Components\Friendly\Default.cshtml"
                                                           Write(ViewBag.BlogToken);

#line default
#line hidden
            EndContext();
            BeginContext(5026, 369, true);
            WriteLiteral(@""");  // 请求发起前在头部附加token

              },
              success: function (res) {
                  layer.closeAll();
                  layer.msg(res.RetMsg);
                  setTimeout(function () {
                      location.reload();
                  }, 1000);
              }
        });
            return false;
        });
    });
</script> ");
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
