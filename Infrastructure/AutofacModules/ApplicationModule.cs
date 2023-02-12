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

            builder.RegisterType<BrandRepository>()
               .As<IBrandRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterType<TokenRepository>()
                .As<ITokenRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CategoryRepository>()
               .As<ICategoryRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterType<ProductRepository>()
               .As<IProductRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterType<ProductVariantRepository>()
               .As<IProductVariantRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterType<VariantValueRepository>()
              .As<IVariantValueRepository>()
              .InstancePerLifetimeScope();

            builder.RegisterType<ProductMediaRepository>()
               .As<IProductMediaRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterType<ProductOptionRepository>()
                .As<IProductOptionRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<OptionRepository>()
               .As<IOptionRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterType<OptionValueRepository>()
               .As<IOptionValueRepository>()
               .InstancePerLifetimeScope();

        }
    }
}
