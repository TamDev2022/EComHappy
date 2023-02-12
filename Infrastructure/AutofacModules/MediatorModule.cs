using Application.Mappings;
using Application.Users.Commands;
using Autofac;
using AutoMapper;
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
            //        .RegisterAssemblyTypes(typeof(CreateUserCommand).GetTypeInfo().Assembly)
            //        .AsClosedTypesOf(mediatrOpenType);
            //}

            builder.RegisterAssemblyTypes(typeof(InsertUserCommand).GetTypeInfo().Assembly)
                   .AsClosedTypesOf(typeof(IRequestHandler<,>));

            //builder.RegisterAssemblyTypes(GetType().Assembly)
            //  .Where(s => s.IsClosedTypeOf(typeof(IRequestHandler<,>)))
            //  .Where(s => s.Name.EndsWith("Handler"))
            //  .AsClosedTypesOf(typeof(IRequestHandler<,>));

            //builder.RegisterAssemblyTypes(GetType().Assembly)
            //  .Where(s => s.IsClosedTypeOf(typeof(INotificationHandler<>)))
            //  .Where(s => s.Name.EndsWith("Handler"))
            //  .AsClosedTypesOf(typeof(INotificationHandler<>));

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                //Register Mapper Profile
                cfg.AddProfile<AutoMapping>();
            }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(context =>
                {
                    var componentContext = context.Resolve<IComponentContext>();
                    return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
                });


        }
    }
}
