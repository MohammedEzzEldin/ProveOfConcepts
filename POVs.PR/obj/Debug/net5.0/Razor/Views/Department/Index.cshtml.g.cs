#pragma checksum "F:\Development\My Projects\Dot Net Projects\Dot Net Core Projects\ProveOfConcepts\ProveOfConcepts\POVs.PR\Views\Department\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "41213b4a55da6b61d2158845b5a0a90171c9e649"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Department_Index), @"mvc.1.0.view", @"/Views/Department/Index.cshtml")]
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
#line 1 "F:\Development\My Projects\Dot Net Projects\Dot Net Core Projects\ProveOfConcepts\ProveOfConcepts\POVs.PR\Views\_ViewImports.cshtml"
using POVs.BL;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41213b4a55da6b61d2158845b5a0a90171c9e649", @"/Views/Department/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d35bdf3762b2bf49c746b467e54765de5add3a0", @"/Views/_ViewImports.cshtml")]
    public class Views_Department_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "F:\Development\My Projects\Dot Net Projects\Dot Net Core Projects\ProveOfConcepts\ProveOfConcepts\POVs.PR\Views\Department\Index.cshtml"
  
    ViewData["Title"] = "Department";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>Welcome in Department</h2>\r\n\r\n\r\n<br />\r\n\r\n<center>\r\n    <h2>");
#nullable restore
#line 10 "F:\Development\My Projects\Dot Net Projects\Dot Net Core Projects\ProveOfConcepts\ProveOfConcepts\POVs.PR\Views\Department\Index.cshtml"
   Write(ViewData["x"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n    <h2>");
#nullable restore
#line 11 "F:\Development\My Projects\Dot Net Projects\Dot Net Core Projects\ProveOfConcepts\ProveOfConcepts\POVs.PR\Views\Department\Index.cshtml"
   Write(ViewBag.y);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n    <h2>");
#nullable restore
#line 12 "F:\Development\My Projects\Dot Net Projects\Dot Net Core Projects\ProveOfConcepts\ProveOfConcepts\POVs.PR\Views\Department\Index.cshtml"
   Write(TempData["z"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n</center>");
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
