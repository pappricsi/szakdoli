#pragma checksum "C:\Users\pappr.DESKTOP-FUG8TPL\Desktop\Szakdoli\szakdoli\Szakdoli\Szakdoli\Views\Keszlet\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3ea92b6fe8299e227cb9340b853424f84b57c9a3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Keszlet_Details), @"mvc.1.0.view", @"/Views/Keszlet/Details.cshtml")]
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
#nullable restore
#line 1 "C:\Users\pappr.DESKTOP-FUG8TPL\Desktop\Szakdoli\szakdoli\Szakdoli\Szakdoli\Views\_ViewImports.cshtml"
using Szakdoli;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\pappr.DESKTOP-FUG8TPL\Desktop\Szakdoli\szakdoli\Szakdoli\Szakdoli\Views\_ViewImports.cshtml"
using Szakdoli.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ea92b6fe8299e227cb9340b853424f84b57c9a3", @"/Views/Keszlet/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ba27c93e9e1bbcb5ba51a394fa700ed22e12e63", @"/Views/_ViewImports.cshtml")]
    public class Views_Keszlet_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Szakdoli.Models.Keszlet>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\pappr.DESKTOP-FUG8TPL\Desktop\Szakdoli\szakdoli\Szakdoli\Szakdoli\Views\Keszlet\Details.cshtml"
  
    ViewData["Title"] = "Részletek";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Részletek</h1>\r\n\r\n<div>\r\n    <h4>Készlet</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 15 "C:\Users\pappr.DESKTOP-FUG8TPL\Desktop\Szakdoli\szakdoli\Szakdoli\Szakdoli\Views\Keszlet\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TermekTipus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "C:\Users\pappr.DESKTOP-FUG8TPL\Desktop\Szakdoli\szakdoli\Szakdoli\Szakdoli\Views\Keszlet\Details.cshtml"
       Write(Html.DisplayFor(model => model.TermekTipus.TipusNev));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "C:\Users\pappr.DESKTOP-FUG8TPL\Desktop\Szakdoli\szakdoli\Szakdoli\Szakdoli\Views\Keszlet\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Raktar));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "C:\Users\pappr.DESKTOP-FUG8TPL\Desktop\Szakdoli\szakdoli\Szakdoli\Szakdoli\Views\Keszlet\Details.cshtml"
       Write(Html.DisplayFor(model => model.Raktar.Nev));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "C:\Users\pappr.DESKTOP-FUG8TPL\Desktop\Szakdoli\szakdoli\Szakdoli\Szakdoli\Views\Keszlet\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Mennyiseg));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "C:\Users\pappr.DESKTOP-FUG8TPL\Desktop\Szakdoli\szakdoli\Szakdoli\Szakdoli\Views\Keszlet\Details.cshtml"
       Write(Html.DisplayFor(model => model.Mennyiseg));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ea92b6fe8299e227cb9340b853424f84b57c9a35994", async() => {
                WriteLiteral("Vissza a lista nézethez");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Szakdoli.Models.Keszlet> Html { get; private set; }
    }
}
#pragma warning restore 1591
