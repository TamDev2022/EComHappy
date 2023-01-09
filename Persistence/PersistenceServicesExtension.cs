using Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceServicesExtension
    {
        public static IServiceCollection AddPersistenceServicesExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                    .AddScoped(typeof(IUserRepository), typeof(UserRepository))
                    .AddScoped(typeof(IRoleRepository), typeof(RoleRepository));

            services.AddScoped(typeof(IUnitOfWork), services =>
            {
                return services.GetRequiredService<ApplicationDbContext>();
            });



            return services;
        }
    }
}
