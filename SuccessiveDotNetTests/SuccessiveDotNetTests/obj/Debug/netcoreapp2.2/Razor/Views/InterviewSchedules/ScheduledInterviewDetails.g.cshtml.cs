#pragma checksum "C:\Users\akash\Desktop\Assignment Test\dotnet-2020-net-core-assignment\SuccessiveDotNetTests\SuccessiveDotNetTests\Views\InterviewSchedules\ScheduledInterviewDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4cca0a52e5a1caf7160323216b260f7aeb55fdc8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_InterviewSchedules_ScheduledInterviewDetails), @"mvc.1.0.view", @"/Views/InterviewSchedules/ScheduledInterviewDetails.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/InterviewSchedules/ScheduledInterviewDetails.cshtml", typeof(AspNetCore.Views_InterviewSchedules_ScheduledInterviewDetails))]
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
#line 1 "C:\Users\akash\Desktop\Assignment Test\dotnet-2020-net-core-assignment\SuccessiveDotNetTests\SuccessiveDotNetTests\Views\_ViewImports.cshtml"
using SuccessiveDotNetTests;

#line default
#line hidden
#line 2 "C:\Users\akash\Desktop\Assignment Test\dotnet-2020-net-core-assignment\SuccessiveDotNetTests\SuccessiveDotNetTests\Views\_ViewImports.cshtml"
using SuccessiveDotNetTests.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4cca0a52e5a1caf7160323216b260f7aeb55fdc8", @"/Views/InterviewSchedules/ScheduledInterviewDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dba490d54e66371ac8a418dc02a72b2a700f494d", @"/Views/_ViewImports.cshtml")]
    public class Views_InterviewSchedules_ScheduledInterviewDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Schedule.Entities.InterviewSchedule>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\akash\Desktop\Assignment Test\dotnet-2020-net-core-assignment\SuccessiveDotNetTests\SuccessiveDotNetTests\Views\InterviewSchedules\ScheduledInterviewDetails.cshtml"
  
    ViewData["Title"] = "ScheduledInterviewDetails";

#line default
#line hidden
            BeginContext(118, 124, true);
            WriteLiteral("\r\n<h1>ScheduledInterviewDetails</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(243, 56, false);
#line 12 "C:\Users\akash\Desktop\Assignment Test\dotnet-2020-net-core-assignment\SuccessiveDotNetTests\SuccessiveDotNetTests\Views\InterviewSchedules\ScheduledInterviewDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.candidates.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(299, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(355, 52, false);
#line 15 "C:\Users\akash\Desktop\Assignment Test\dotnet-2020-net-core-assignment\SuccessiveDotNetTests\SuccessiveDotNetTests\Views\InterviewSchedules\ScheduledInterviewDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.candidates.Email));

#line default
#line hidden
            EndContext();
            BeginContext(407, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(463, 57, false);
#line 18 "C:\Users\akash\Desktop\Assignment Test\dotnet-2020-net-core-assignment\SuccessiveDotNetTests\SuccessiveDotNetTests\Views\InterviewSchedules\ScheduledInterviewDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.candidates.Experience));

#line default
#line hidden
            EndContext();
            BeginContext(520, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(576, 44, false);
#line 21 "C:\Users\akash\Desktop\Assignment Test\dotnet-2020-net-core-assignment\SuccessiveDotNetTests\SuccessiveDotNetTests\Views\InterviewSchedules\ScheduledInterviewDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.TimeFrom));

#line default
#line hidden
            EndContext();
            BeginContext(620, 100, true);
            WriteLiteral("\r\n            </th>\r\n            \r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 28 "C:\Users\akash\Desktop\Assignment Test\dotnet-2020-net-core-assignment\SuccessiveDotNetTests\SuccessiveDotNetTests\Views\InterviewSchedules\ScheduledInterviewDetails.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(769, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(830, 55, false);
#line 32 "C:\Users\akash\Desktop\Assignment Test\dotnet-2020-net-core-assignment\SuccessiveDotNetTests\SuccessiveDotNetTests\Views\InterviewSchedules\ScheduledInterviewDetails.cshtml"
               Write(Html.DisplayFor(modelItem => item.candidates.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(885, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(953, 51, false);
#line 35 "C:\Users\akash\Desktop\Assignment Test\dotnet-2020-net-core-assignment\SuccessiveDotNetTests\SuccessiveDotNetTests\Views\InterviewSchedules\ScheduledInterviewDetails.cshtml"
               Write(Html.DisplayFor(modelItem => item.candidates.Email));

#line default
#line hidden
            EndContext();
            BeginContext(1004, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1072, 56, false);
#line 38 "C:\Users\akash\Desktop\Assignment Test\dotnet-2020-net-core-assignment\SuccessiveDotNetTests\SuccessiveDotNetTests\Views\InterviewSchedules\ScheduledInterviewDetails.cshtml"
               Write(Html.DisplayFor(modelItem => item.candidates.Experience));

#line default
#line hidden
            EndContext();
            BeginContext(1128, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1196, 43, false);
#line 41 "C:\Users\akash\Desktop\Assignment Test\dotnet-2020-net-core-assignment\SuccessiveDotNetTests\SuccessiveDotNetTests\Views\InterviewSchedules\ScheduledInterviewDetails.cshtml"
               Write(Html.DisplayFor(modelItem => item.TimeFrom));

#line default
#line hidden
            EndContext();
            BeginContext(1239, 106, true);
            WriteLiteral("\r\n                </td>\r\n               \r\n                <td>\r\n                   |\r\n                    ");
            EndContext();
            BeginContext(1345, 31, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4cca0a52e5a1caf7160323216b260f7aeb55fdc89118", async() => {
                BeginContext(1368, 4, true);
                WriteLiteral("Back");
                EndContext();
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
            EndContext();
            BeginContext(1376, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 49 "C:\Users\akash\Desktop\Assignment Test\dotnet-2020-net-core-assignment\SuccessiveDotNetTests\SuccessiveDotNetTests\Views\InterviewSchedules\ScheduledInterviewDetails.cshtml"
        }

#line default
#line hidden
            BeginContext(1431, 22, true);
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Schedule.Entities.InterviewSchedule>> Html { get; private set; }
    }
}
#pragma warning restore 1591