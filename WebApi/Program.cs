using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using WebApi.ConfigurationOptions;
using WebApi.CustomExtensions;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureContainer<ContainerBuilder>(builder =>
        {
            builder.RegisterMediatR(typeof(Program).Assembly);
            builder.RegisterModule(new ApplicationModule());
            builder.RegisterModule(new MediatorModule());
        });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom configurations
builder.Services.AddCustomConfiguration(builder.Configuration);
builder.Services.AddCustomDbContext(builder.Configuration);
builder.Services.AddCustomSwagger(builder.Configuration);
builder.Services.AddCustomAuthentication(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);

// Add service reference
//builder.Services.AddPersistenceServicesExtension(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var _provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

        // build a swagger endpoint for each discovered API version
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
            options.DefaultModelsExpandDepth(-1);
            options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List);
        }

        options.DefaultModelsExpandDepth(-1);

    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
