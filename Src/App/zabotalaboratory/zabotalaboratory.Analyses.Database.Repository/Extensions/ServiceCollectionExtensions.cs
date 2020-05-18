using zabotalaboratory.Analyses.Database.Extensions;
using zabotalaboratory.Analyses.Database.Repository.LaboratoryAnalysesRepository;
using Microsoft.Extensions.DependencyInjection;

namespace zabotalaboratory.Analyses.Database.Repository.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAnalysesRepository(this IServiceCollection services, string connectionString)
        {
            services.AddAnalysesDatabase(connectionString);
            services.AddScoped<ILaboratoryAnalysesRepository, LaboratoryAnalysesRepository.LaboratoryAnalysesRepository>();
            return services;
        }
    }
}
