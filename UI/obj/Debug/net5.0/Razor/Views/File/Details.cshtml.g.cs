#pragma checksum "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52217ed11254362ca9cdb7b1d0c55b1b3118ca75"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_File_Details), @"mvc.1.0.view", @"/Views/File/Details.cshtml")]
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
#line 1 "D:\main projects\NavyArchNewVersion\UI\Views\_ViewImports.cshtml"
using UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\main projects\NavyArchNewVersion\UI\Views\_ViewImports.cshtml"
using UI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\main projects\NavyArchNewVersion\UI\Views\_ViewImports.cshtml"
using Domain.Entites;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\main projects\NavyArchNewVersion\UI\Views\_ViewImports.cshtml"
using Application.Features.FileSrc.Queries.GetSrcDetails;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\main projects\NavyArchNewVersion\UI\Views\_ViewImports.cshtml"
using Application.Features.FileSrc.Queries.GetSrcList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\main projects\NavyArchNewVersion\UI\Views\_ViewImports.cshtml"
using Application.Features.FileSrc.Command.CreateSrcFile;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\main projects\NavyArchNewVersion\UI\Views\_ViewImports.cshtml"
using Application.Features.FileSrc.Command.UpdateSrcFile;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\main projects\NavyArchNewVersion\UI\Views\_ViewImports.cshtml"
using Infrastructure.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\main projects\NavyArchNewVersion\UI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\main projects\NavyArchNewVersion\UI\Views\_ViewImports.cshtml"
using Infrastructure.ViewModels.RolesViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\main projects\NavyArchNewVersion\UI\Views\_ViewImports.cshtml"
using Application.Features.FileDest.Queries;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\main projects\NavyArchNewVersion\UI\Views\_ViewImports.cshtml"
using Application.Features.FileDest.Queries.GetFileDestDetails;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\main projects\NavyArchNewVersion\UI\Views\_ViewImports.cshtml"
using Application.Features.FileDest.Commands.CreateFileDest;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\main projects\NavyArchNewVersion\UI\Views\_ViewImports.cshtml"
using Application.Features.FileDest.Commands.UpdateFileDest;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\main projects\NavyArchNewVersion\UI\Views\_ViewImports.cshtml"
using Application.Features.FileSrc.Command.DeleteSrcFile;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\main projects\NavyArchNewVersion\UI\Views\_ViewImports.cshtml"
using Application.Features.Officer.GetOfficerDetails;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\main projects\NavyArchNewVersion\UI\Views\_ViewImports.cshtml"
using Application.Features.Officer.GetOfficersList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\main projects\NavyArchNewVersion\UI\Views\_ViewImports.cshtml"
using Application.Features.Officer.Commands.CreateOfficer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "D:\main projects\NavyArchNewVersion\UI\Views\_ViewImports.cshtml"
using Application.Features.Officer.Commands.UpdateCommand;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "D:\main projects\NavyArchNewVersion\UI\Views\_ViewImports.cshtml"
using Application.Features.FileInfo.Commands.CreateFile;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
using UI.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52217ed11254362ca9cdb7b1d0c55b1b3118ca75", @"/Views/File/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"644abe3af802f4e21fe54c469c2ea6969891f85c", @"/Views/_ViewImports.cshtml")]
    public class Views_File_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FileDetailsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("target", new global::Microsoft.AspNetCore.Html.HtmlString("_blank"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>تفاصيل ملف</h1>\r\n\r\n<div>\r\n    <h4>");
#nullable restore
#line 11 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
   Write(Model.AboutTag);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            الجهة المرسله\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n");
#nullable restore
#line 18 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
              
                var soruce = string.Join(" - ", Model.SoruceName); 
            

#line default
#line hidden
#nullable disable
            WriteLiteral("          ");
#nullable restore
#line 21 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
     Write(Html.DisplayFor(modelItem=>soruce));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            القسم\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n");
#nullable restore
#line 27 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
              
                var department = string.Join(" - ", Model.DepartmentName); 
            

#line default
#line hidden
#nullable disable
            WriteLiteral("          ");
#nullable restore
#line 30 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
     Write(Html.DisplayFor(modelItem=>department));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ضابط\r\n        </dt>\r\n           <dd class=\"col-sm-10\">\r\n");
#nullable restore
#line 36 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
                
                var officer = string.Join(" - ", Model.OfficerName); 
            

#line default
#line hidden
#nullable disable
            WriteLiteral("          ");
#nullable restore
#line 39 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
     Write(Html.DisplayFor(modelItem=>officer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            بشأن\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 45 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
       Write(Html.DisplayFor(model => model.AboutTag));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n");
#nullable restore
#line 46 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
             if (Model.AboutUrl != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "52217ed11254362ca9cdb7b1d0c55b1b3118ca7511683", async() => {
                WriteLiteral("أضغط للقراءة");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1249, "~/images/", 1249, 9, true);
#nullable restore
#line 48 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
AddHtmlAttributeValue("", 1258, Model.AboutUrl, 1258, 15, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 49 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span><b>لا يوجد ملف</b></span>\r\n");
#nullable restore
#line 53 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            القيد\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 59 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
       Write(Html.DisplayFor(model => model.Const));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            الاجراء\r\n        </dt>\r\n        \r\n         <dd class = \"col-sm-10\">\r\n");
#nullable restore
#line 66 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
             if (Model.ProcedcureTage != null)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
           Write(Html.DisplayFor(model => model.ProcedcureTage));

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
                                                               
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
             if(Model.ProcedcureUrl != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "52217ed11254362ca9cdb7b1d0c55b1b3118ca7515197", async() => {
                WriteLiteral("أضغط للقراءة");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1947, "~/images/", 1947, 9, true);
#nullable restore
#line 72 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
AddHtmlAttributeValue("", 1956, Model.AboutUrl, 1956, 15, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 73 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 74 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
             if(Model.ProcedcureTage == null && Model.ProcedcureUrl == null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span><b>لم يتم إتخاذ إجراء</b></span>\r\n");
#nullable restore
#line 77 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("         </dd>        \r\n        <dt class = \"col-sm-2\">\r\n            تاريخ الأستلام\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 83 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
       Write(Html.DisplayFor(model => model.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            أخر ميعاد للرد\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 89 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
       Write(Html.DisplayFor(model => model.ReminderDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ملاحظات\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n");
#nullable restore
#line 95 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
             if (Model.Note != null)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 97 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
           Write(Html.DisplayFor(model => model.Note));

#line default
#line hidden
#nullable disable
#nullable restore
#line 97 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
                                                     
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span>لا يوجد</span>\r\n");
#nullable restore
#line 102 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "52217ed11254362ca9cdb7b1d0c55b1b3118ca7519387", async() => {
                WriteLiteral("تعديل");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 107 "D:\main projects\NavyArchNewVersion\UI\Views\File\Details.cshtml"
                           WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "52217ed11254362ca9cdb7b1d0c55b1b3118ca7521598", async() => {
                WriteLiteral("رجوع");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FileDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591