#pragma checksum "C:\Users\jimmy\OneDrive\Desktop\RCDT\RCDT\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f4d580d21dee30e5dee823abf90023a2230071e9"
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
#line 1 "C:\Users\jimmy\OneDrive\Desktop\RCDT\RCDT\Views\_ViewImports.cshtml"
using RCDT;

#line default
#line hidden
#line 2 "C:\Users\jimmy\OneDrive\Desktop\RCDT\RCDT\Views\_ViewImports.cshtml"
using RCDT.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f4d580d21dee30e5dee823abf90023a2230071e9", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0409a7539e6683a72f1af41e11c52fda8378cff8", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RCDT.Models.SessionUserModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(37, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\jimmy\OneDrive\Desktop\RCDT\RCDT\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home";

#line default
#line hidden
            BeginContext(79, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "C:\Users\jimmy\OneDrive\Desktop\RCDT\RCDT\Views\Home\Index.cshtml"
 using (Html.BeginForm())
{
  

#line default
#line hidden
            BeginContext(114, 23, false);
#line 9 "C:\Users\jimmy\OneDrive\Desktop\RCDT\RCDT\Views\Home\Index.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(141, 601, true);
            WriteLiteral(@"  <div class=""container mt-2"">
    <div style=""margin-top:50px"">
      <div class=""text-center"" style=""margin-top:300px"">
        <h1 class=""display-4"">RCDT</h1>

        <div class=""form-group"">
          <div class=""col-md-12"">
             <input type=""text"" class=""userIDForm"" name=""userID"" placeholder=""User ID"" id=""userID"" required name=""userID"">
              <input type=""number"" class=""seshKeyForm"" name=""sessionKey"" placeholder=""Session key"" id=""sessionKey"" required name=""sessionKey"">
          </div>
        </div>

        <div class=""col-md-offset-2 col-md-12"">
           ");
            EndContext();
            BeginContext(743, 87, false);
#line 24 "C:\Users\jimmy\OneDrive\Desktop\RCDT\RCDT\Views\Home\Index.cshtml"
      Write(Html.ValidationMessageFor(model => model.sessionKey, "", new { @class = "text-danger"}));

#line default
#line hidden
            EndContext();
            BeginContext(830, 13, true);
            WriteLiteral("\r\n           ");
            EndContext();
            BeginContext(844, 83, false);
#line 25 "C:\Users\jimmy\OneDrive\Desktop\RCDT\RCDT\Views\Home\Index.cshtml"
      Write(Html.ValidationMessageFor(model => model.userID, "", new { @class = "text-danger"}));

#line default
#line hidden
            EndContext();
            BeginContext(927, 339, true);
            WriteLiteral(@"
        </div>

        <div class=""form-group"">
            <div class=""col-md-offset-5 col-md-12"">
                <input type=""submit"" value=""Submit"" class=""btn btn-default"" />
                <input type=""reset"" value=""Clear"" class=""btn btn-default"" />
            </div>
        </div>

      </div>
    </div>
  </div>
");
            EndContext();
#line 38 "C:\Users\jimmy\OneDrive\Desktop\RCDT\RCDT\Views\Home\Index.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RCDT.Models.SessionUserModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
