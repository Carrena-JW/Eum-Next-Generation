using Eum.Shared.Common.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eum.Shared.Common.Extentions
{
    public static class ControllerExtentions
    {
        public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers().ConfigureApplicationPartManager(manager =>
            {
                manager.FeatureProviders.Add(new ControllerProvier());
            });

            services.AddControllers()
                .ConfigureApplicationPartManager(manager =>
                {
                    manager.FeatureProviders.Add(new ControllerProvier());
                });
            return services;
        }
    }
}
