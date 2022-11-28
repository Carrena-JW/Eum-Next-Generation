using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Eum.Shared.Common.Extentions
{
    public static class EumDIContainerExtention
    {

        public static WebApplicationBuilder EumDIContainerBuilder(this WebApplicationBuilder builder)
        {

            var eumAssemblies = AppDomain.CurrentDomain.GetEumModuleAssemblies();

            //autofac
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
             {
                 builder.RegisterAssemblyTypes(eumAssemblies)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
             });

            //mapper, mediatR
            builder.Services.AddAutoMapper(eumAssemblies).AddMediatR(eumAssemblies);

            return builder;
        }
    }
}

