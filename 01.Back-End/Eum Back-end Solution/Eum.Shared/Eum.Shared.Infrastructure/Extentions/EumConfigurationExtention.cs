using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Eum.Shared.Infrastructure.Controllers;
using System.Reflection;


namespace Eum.Shared.Infrastructure.Extentions
{
    public static class EumConfigurationExtention
    {
        //    public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services, IConfiguration config)
        //    {
        //        services.AddMediatR(typeof());
        //        return services;
        //    }
        public static IServiceCollection AddEumService(this IServiceCollection services)
        {

            var eumAssemblies = Assembly.GetExecutingAssembly();

            return services.AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}


//public static IServiceCollection AddCore(this IServiceCollection services)
//{
//    return services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
//        .AddAutoMapper(Assembly.GetExecutingAssembly())
//        .AddMediatR(Assembly.GetExecutingAssembly());
//}