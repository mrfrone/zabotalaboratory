using Microsoft.Extensions.DependencyInjection;
using zabotalaboratory.Analyses.Database.Repository.Extentions;
using zabotalaboratory.Analyses.Services.Analyses;
using zabotalaboratory.Analyses.Services.LaboratoryAnalyses;

namespace zabotalaboratory.Analyses.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAnalysesServices(this IServiceCollection services, string connectionString)
        {
            services.AddAnalysesRepository(connectionString);
            services.AddScoped<ILaboratoryAnalysesService, LaboratoryAnalysesService>();
            services.AddScoped<IAnalysesService, AnalysesService>();
            return services;
        }
    }
}
