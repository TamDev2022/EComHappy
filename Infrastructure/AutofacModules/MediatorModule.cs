using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AutofacModules
{
    public class MediatorModule : Autofac.Module
    {
        public MediatorModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
            .AsImplementedInterfaces();

            //var mediatrOpenTypes = new[]
            //{
            //    typeof(IRequestHandler<,>),
            //    typeof(IRequestExceptionHandler<,,>),
            //    typeof(IRequestExceptionAction<,>),
            //    typeof(INotificationHandler<>),
            //    typeof(IStreamRequestHandler<,>)
            //};

            //foreach (var mediatrOpenType in mediatrOpenTypes)
            //{
            //    builder
            //        .RegisterAssemblyTypes(typeof(Ping).GetTypeInfo().Assembly)
            //        .AsClosedTypesOf(mediatrOpenType);
            //}

            builder.RegisterAssemblyTypes(GetType().Assembly)
              .Where(s => s.IsClosedTypeOf(typeof(IRequestHandler<,>)))
              .Where(s => s.Name.EndsWith("Handler"))
              .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(GetType().Assembly)
              .Where(s => s.IsClosedTypeOf(typeof(INotificationHandler<>)))
              .Where(s => s.Name.EndsWith("Handler"))
              .AsClosedTypesOf(typeof(INotificationHandler<>));

            builder.Register<ServiceFactory>(context =>
                {
                    var componentContext = context.Resolve<IComponentContext>();
                    return t => componentContext.Resolve(t);
                }).InstancePerLifetimeScope(); ;


        }
    }
}
