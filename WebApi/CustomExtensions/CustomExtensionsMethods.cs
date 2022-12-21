using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.Text;
using WebApi.ConfigurationOptions;

namespace WebApi.CustomExtensions
{
    public static class CustomExtensionsMethods
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }

        public static IServiceCollection AddCustomConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<AppSettings>(configuration);

            return services;
        }

        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }

        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            AppSettings appSettings = new AppSettings();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(opts =>
            {
                opts.Authority = appSettings.jwtSettings.Authority;
                opts.Audience = appSettings.jwtSettings.ApiName;
                opts.RequireHttpsMetadata = appSettings.jwtSettings.RequireHttpsMetadata;
                opts.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = appSettings.jwtSettings.Issuer,
                    ValidAudience = appSettings.jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(appSettings.jwtSettings.SecretKey)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });

            return services;
        }
    }
}
