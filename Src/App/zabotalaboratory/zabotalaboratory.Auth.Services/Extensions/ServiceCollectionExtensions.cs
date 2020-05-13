using Microsoft.Extensions.DependencyInjection;
using zabotalaboratory.Auth.Database.Repository.Extentions;
using zabotalaboratory.Auth.Services.UserProfile;
using zabotalaboratory.Auth.Services.Identities;
using zabotalaboratory.Auth.Services.Login;

namespace zabotalaboratory.Auth.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAuthServices(this IServiceCollection services, string connectionString)
        {
            services.AddAuthRepository(connectionString);
            services.AddScoped<IUserProfileService, UserProfilesService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<ILoginService, LoginService>();
            return services;
        }
    }
}
