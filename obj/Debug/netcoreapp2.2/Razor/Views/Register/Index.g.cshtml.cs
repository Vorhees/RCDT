#pragma checksum "C:\Users\Isaiah\Github\RCDT\Views\Register\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d75b5750b2ba6b137ae997715c7514d2f715906c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Register_Index), @"mvc.1.0.view", @"/Views/Register/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Register/Index.cshtml", typeof(AspNetCore.Views_Register_Index))]
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
#line 1 "C:\Users\Isaiah\Github\RCDT\Views\_ViewImports.cshtml"
using RCDT;

#line default
#line hidden
#line 2 "C:\Users\Isaiah\Github\RCDT\Views\_ViewImports.cshtml"
using RCDT.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d75b5750b2ba6b137ae997715c7514d2f715906c", @"/Views/Register/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0409a7539e6683a72f1af41e11c52fda8378cff8", @"/Views/_ViewImports.cshtml")]
    public class Views_Register_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Isaiah\Github\RCDT\Views\Register\Index.cshtml"
  
    ViewData["Title"] = "Registration Page";

#line default
#line hidden
            BeginContext(53, 165, true);
            WriteLiteral("\r\n<div class=\"container\">\r\n  <div class=\"row\">\r\n    <div class=\"col-md-4\"></div>\r\n    <div class=\"col-md-4\" style=\"margin-top:150px\">\r\n      <h3>Sign Up</h3>\r\n      ");
            EndContext();
            BeginContext(218, 972, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d75b5750b2ba6b137ae997715c7514d2f715906c3589", async() => {
                BeginContext(224, 854, true);
                WriteLiteral(@"
        <div class=""form-group"">
          <input type=""text"" class=""form-control"" required name=""username"" placeholder=""Enter Username"">
        </div>
        <div class=""form-group"">
          <input type=""password"" class=""form-control"" required name=""password"" placeholder=""Enter Password"">
        </div>
        <div class=""form-group"">
          <input type=""password"" class=""form-control"" required name=""password"" placeholder=""Reenter Password"">
        </div>
        <div class=""form-group"">
          <input type=""email"" class=""form-control"" required name=""email"" placeholder=""Enter Email"">
        </div>
        <div class=""form-group text-center"">
        <button type=""submit"" class=""btn btn-primary form-control mb-2"">
          Submit
        </button>
        <button class=""btn btn-primary form-control"" type=""button""");
                EndContext();
                BeginWriteAttribute("onclick", " onclick=\"", 1078, "\"", 1133, 3);
                WriteAttributeValue("", 1088, "location.href=\'", 1088, 15, true);
#line 27 "C:\Users\Isaiah\Github\RCDT\Views\Register\Index.cshtml"
WriteAttributeValue("", 1103, Url.Action("Index" , "Home"), 1103, 29, false);

#line default
#line hidden
                WriteAttributeValue("", 1132, "\'", 1132, 1, true);
                EndWriteAttribute();
                BeginContext(1134, 49, true);
                WriteLiteral("> Cancel\r\n        </button>\r\n      </div>\r\n      ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1190, 66, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"col-md-4\"></div>\r\n  </div>\r\n</div>\r\n");
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
