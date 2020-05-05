using zabotalaboratory.Auth.Database.Repository.Extentions;
using zabotalaboratory.Auth.Services.Identities;
using zabotalaboratory.Auth.Services.Login;
using Microsoft.Extensions.DependencyInjection;

namespace zabotalaboratory.Auth.Services.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAuthServices(this IServiceCollection services, string connectionString)
        {
            services.AddAuthRepository(connectionString);
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<ILoginService, LoginService>();
            return services;
        }
    }
}
