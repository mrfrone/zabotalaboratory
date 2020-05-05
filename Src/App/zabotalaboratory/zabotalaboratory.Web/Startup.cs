using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using zabotalaboratory.Auth.Datamodel.Mapping;
using zabotalaboratory.Auth.Datamodel.Tokens;
using zabotalaboratory.Auth.Services.Extensions;
using zabotalaboratory.Common.AutoMapper.Extensions;
using zabotalaboratory.Common.Datamodel.PasswordHashing;
using zabotalaboratory.Common.Filters;
using zabotalaboratory.Common.PasswordService.Extensions;
using zabotalaboratory.Common.Storage;

namespace zabotalaboratory
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _environment;
        
        public Startup(IWebHostEnvironment hostEnv)
        {
            var _config = new ConfigurationBuilder()
                .SetBasePath(hostEnv.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{hostEnv.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = _config.Build();
            _environment = hostEnv;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<JwtSettings>(Configuration.GetSection(nameof(JwtSettings)));
            services.Configure<PasswordHashingSettings>(Configuration.GetSection(nameof(PasswordHashingSettings)));
            
            services.AddAuthServices(Configuration.GetConnectionString("PostgreSQL"));
            services.AddPasswordHashing();
            services.AddScoped<IIdentityRequestStorage, IdentityRequestStorage>();
            
            services.AddMiMapping(
                typeof(MappingProfile)
            );
            
            var jwtOptions = Configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>();
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtOptions.Issuer,
                        ValidateAudience = true,
                        ValidAudience = jwtOptions.Audience,
                        ValidateLifetime = true,
                        IssuerSigningKey = jwtOptions.GetSecurityKey(),
                        ValidateIssuerSigningKey = true
                    };
                });
            
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            
            services.AddMvc(options =>
            {
                options.Filters.Add<IdentityStorageFilterAttribute>();
                options.EnableEndpointRouting = false;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseCors("EnableCORS");
            
            app.UseStaticFiles();
            app.UseAuthentication();
            
            //app.UseMvcWithDefaultRoute();
            app.UseMvc();
        }
    }
}
