using zabotalaboratory.Analyses.Database.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace zabotalaboratory.Analyses.Database.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAnalysesDatabase(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<AnalysesContext>(builder =>
            {
                builder.UseNpgsql(connectionString, options =>
                {
                    options.EnableRetryOnFailure();
                    options.MigrationsHistoryTable("__EFMigrationsHistory", AnalysesContext.SchemaName);
                });
            });

            return services;
        }
    }
}
