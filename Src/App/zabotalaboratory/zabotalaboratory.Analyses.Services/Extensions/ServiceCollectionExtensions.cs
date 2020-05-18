using Microsoft.Extensions.DependencyInjection;
using zabotalaboratory.Analyses.Database.Repository.Extentions;
using zabotalaboratory.Analyses.Services.AnalysesService;

namespace zabotalaboratory.Analyses.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAnalysesServices(this IServiceCollection services, string connectionString)
        {
            services.AddAnalysesRepository(connectionString);
            services.AddScoped<IAnalysesService, AnalysesService.AnalysesService>();
            return services;
        }
    }
}
