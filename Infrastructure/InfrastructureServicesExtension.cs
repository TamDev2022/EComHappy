using Application.Common;
using Application.Service;
using Domain.Infrastructure.Storages;
using Infrastructure.Storages;
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

            return services;
        }
    }
}
