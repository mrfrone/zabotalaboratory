using Microsoft.Extensions.DependencyInjection;
using zabotalaboratory.Common.Razor.RazorRender;
using zabotalaboratory.Common.RazorReports.HtmlToPDFConverter;
using zabotalaboratory.Common.RazorReports.Reports.Analyses;

namespace zabotalaboratory.Common.Razor.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRazorPagesReports(this IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddScoped<IRazorRenderService, RazorRenderService>();
            services.AddScoped<IAnalysesReportsService, AnalysesReportsService>();
            services.AddScoped<IHtmlToPDFConverterService, HtmlToPDFConverterService>();
            return services; 
        }
    }
}
