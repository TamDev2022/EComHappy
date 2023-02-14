using Application.Common;
using Domain.Interfaces;
using Infrastructure.File;
using Infrastructure.JWT;
using Infrastructure.Storages;
using Infrastructure.Storages.Azure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class InfrastructureServicesExtension
    {

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<IJwtTokenService, JwtTokenService>();
            services.AddAzureBlobStorageManager();
            return services;
        }

        public static IServiceCollection AddAzureBlobStorageManager(this IServiceCollection services)
        {
            services.AddSingleton<IFileStorageManager, AzureBlobStorageManager>();

            return services;
        }

    }
}
