using zabotalaboratory.Auth.Database.Extensions;
using zabotalaboratory.Auth.Database.Repository.Identities;
using zabotalaboratory.Auth.Database.Repository.Tokens;
using zabotalaboratory.Auth.Database.Repository.UserProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace zabotalaboratory.Auth.Database.Repository.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAuthRepository(this IServiceCollection services, string connectionString)
        {
            services.AddAuthDatabase(connectionString);
            services.AddScoped<ITokensRepository, TokensRepository>();
            services.AddScoped<IIdentitiesRepository, IdentitiesRepository>();
            services.AddScoped<IUsersProfilesRepository, UsersProfilesRepository>();
            return services;
        }
    }
}
