#pragma checksum "C:\Users\akinb\OneDrive\FintrakTestSolution\ComplaintService.Client\Views\Home\Weather.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a9ea2480c9fd54eda086a30e503747e324a709f4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Weather), @"mvc.1.0.view", @"/Views/Home/Weather.cshtml")]
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
#line 1 "C:\Users\akinb\OneDrive\FintrakTestSolution\ComplaintService.Client\Views\_ViewImports.cshtml"
using ComplaintService;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\akinb\OneDrive\FintrakTestSolution\ComplaintService.Client\Views\_ViewImports.cshtml"
using ComplaintService.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9ea2480c9fd54eda086a30e503747e324a709f4", @"/Views/Home/Weather.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94dc4617175883d7d7968aa2d1b81bc0158a5c58", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Weather : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ComplaintService.Client.Models.WeatherModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\akinb\OneDrive\FintrakTestSolution\ComplaintService.Client\Views\Home\Weather.cshtml"
  
    ViewData["Title"] = "Weather";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Weather</h2>\r\n\r\n<h1>Weather</h1>\r\n<table class=\"table table-striped\">\r\n");
#nullable restore
#line 11 "C:\Users\akinb\OneDrive\FintrakTestSolution\ComplaintService.Client\Views\Home\Weather.cshtml"
     foreach (var weather in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 14 "C:\Users\akinb\OneDrive\FintrakTestSolution\ComplaintService.Client\Views\Home\Weather.cshtml"
           Write(weather.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 15 "C:\Users\akinb\OneDrive\FintrakTestSolution\ComplaintService.Client\Views\Home\Weather.cshtml"
           Write(weather.Summary);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 16 "C:\Users\akinb\OneDrive\FintrakTestSolution\ComplaintService.Client\Views\Home\Weather.cshtml"
           Write(weather.TemperatureC);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 17 "C:\Users\akinb\OneDrive\FintrakTestSolution\ComplaintService.Client\Views\Home\Weather.cshtml"
           Write(weather.TemperatureF);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 19 "C:\Users\akinb\OneDrive\FintrakTestSolution\ComplaintService.Client\Views\Home\Weather.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ComplaintService.Client.Models.WeatherModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
