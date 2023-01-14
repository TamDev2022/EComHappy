using Domain.Infrastructure.Storages;
using Infrastructure.Storages.Azure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Storages
{
    public static class StoragesServicesExtensions
    {
        public static IServiceCollection AddAzureBlobStorageManager(this IServiceCollection services, AzureBlobSettings options)
        {
            services.AddSingleton<IFileStorageManager, AzureBlobStorageManager>();

            services.AddSingleton<IFileStorageManager>(new AzureBlobStorageManager(options, new Application.Service.FileService()));

            return services;
        }

        public static IServiceCollection AddStorageManager(this IServiceCollection services, StorageOptions options)
        {
            services.AddAzureBlobStorageManager(options.AzureBlob);

            return services;
        }
    }
}
