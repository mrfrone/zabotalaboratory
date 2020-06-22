using Microsoft.Extensions.DependencyInjection;
using zabotalaboratory.Common.ExcelReports.Analyses;

namespace zabotalaboratory.Common.Razor.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddExcelReports(this IServiceCollection services)
        {
            services.AddScoped<ILaboratoryAnalysesExcelReportsService, LaboratoryAnalysesExcelReportsService>();
            return services; 
        }
    }
}
