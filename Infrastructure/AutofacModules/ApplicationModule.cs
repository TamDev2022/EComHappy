using Domain.Repositories;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        public ApplicationModule()
        {

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork<ApplicationDbContext>>()
              .As<IUnitOfWork<ApplicationDbContext>>()
              .InstancePerLifetimeScope();


            builder.RegisterType<UserRepository>()
               .As<IUserRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterType<RoleRepository>()
                .As<IRoleRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
