using Contracts.ConfigurationOptions;
using Infrastructure;
using Infrastructure.Storages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using Microsoft.OpenApi.Models;
using Persistence;
using SixLabors.ImageSharp;
using System.Reflection;
using System.Text;

namespace WebApi.CustomExtensions
{
    public static class CustomExtensionsMethods
    {

        private static AppSettings appSettings = new AppSettings();

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ApplicationDbContext")));

            return services;
        }

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApiVersioning(options =>
            {
                //Specify the default Api version as 1.0
                options.DefaultApiVersion = new ApiVersion(1, 0);
                // If the client hasn't specified the API version in the request, use the default API version number 
                options.AssumeDefaultVersionWhenUnspecified = true;
                // Advertise the API versions supported for the particular endpoint
                options.ReportApiVersions = true;

                // Combine (or not) API Versioning Mechanisms:
                //options.ApiVersionReader = ApiVersionReader.Combine(
                //    // The Default versioning mechanism which reads the API version from the "api-version" Query String paramater.
                //    new QueryStringApiVersionReader("api-version"),
                //    // Use the following, if you would like to specify the version as a custom HTTP Header.
                //    new HeaderApiVersionReader("Accept-Version"),
                //    // Use the following, if you would like to specify the version as a Media Type Header.
                //    new MediaTypeApiVersionReader("api-version")
                //);
            });

            services.AddVersionedApiExplorer(options =>
            {
                // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                // note: the specified format code will format the version as "'v'major[.minor][-status]"
                options.GroupNameFormat = "'v'VVV";

                // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                // can also be used to control the format of the API version in route templates
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddSwaggerGen(options =>
            {
                // If we would like to provide request and response examples (Part 1/2)
                // Enable the Automatic (or Manual) annotation of the [SwaggerRequestExample] and [SwaggerResponseExample].
                // Read more here: https://github.com/mattfrear/Swashbuckle.AspNetCore.Filters
                options.ExampleFilters();

                // If we would like to provide security information about the authorization scheme that we are using (e.g. Bearer).
                // Add Security information to each operation for bearer tokens and define the scheme.
                options.OperationFilter<SecurityRequirementsOperationFilter>(true, "Bearer");

                var _provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
                foreach (var description in _provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName,
                        new Microsoft.OpenApi.Models.OpenApiInfo()
                        {
                            Title = Assembly.GetExecutingAssembly().GetName().Name,
                            Version = description.ApiVersion.ToString()
                        });
                }

                options.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme, securityScheme: new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });

                // If we use the [Authorize] attribute to specify which endpoints require Authorization, then we can
                // Show an "(Auth)" info to the summary so that we can easily see which endpoints require Authorization.
                options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                //options.OperationFilter<AuthOperationFilter>();


                //// If we would like to include documentation comments in the OpenAPI definition file and SwaggerUI.
                //// Set the comments path for the XmlComments file.
                //// Read more here: https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-6.0&tabs=visual-studio#xml-comments
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //options.IncludeXmlComments(xmlPath, true);

            });
            // If we would like to provide request and response examples (Part 2/2)
            // Register examples with the ServiceProvider based on the location assembly or example type.
            services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());



            return services;
        }

        public static IServiceCollection AddCustomConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<AppSettings>(configuration);
            configuration.Bind(appSettings);

            return services;
        }

        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }

        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(opts =>
            {
                opts.Authority = appSettings.IdentityAuthentication.Authority;
                opts.Audience = appSettings.IdentityAuthentication.IdentityUrl;
                opts.RequireHttpsMetadata = appSettings.IdentityAuthentication.RequireHttpsMetadata;
                opts.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = appSettings.IdentityAuthentication.Issuer,
                    ValidAudience = appSettings.IdentityAuthentication.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(appSettings.IdentityAuthentication.SecretKey)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });

            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructureServices();

            return services;
        }
    }
}
