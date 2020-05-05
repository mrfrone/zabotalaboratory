using Microsoft.Extensions.DependencyInjection;
using zabotalaboratory.Common.PasswordService.JwtGenerate;
using zabotalaboratory.Common.PasswordService.PasswordHash;

namespace zabotalaboratory.Common.PasswordService.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPasswordHashing(this IServiceCollection services)
        {
            services.AddScoped<IJwtGenerator, JwtGenerator>();
            services.AddScoped<IPasswordHashCalculator, PasswordHashCalculator>();
            return services;
        }
    }
}
