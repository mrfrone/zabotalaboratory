using zabotalaboratory.Auth.Database.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace zabotalaboratory.Auth.Database.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAuthDatabase(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<AuthContext>(builder =>
            {
                builder.UseNpgsql(connectionString, options =>
                {
                    options.MigrationsAssembly("zabotalaboratory.Auth.Database");
                    options.EnableRetryOnFailure();
                    options.MigrationsHistoryTable("__EFMigrationsHistory", AuthContext.SchemaName);
                });
            });

            return services;
        }
    }
}
