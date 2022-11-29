using Autofac;
using Autofac.Extensions.DependencyInjection;
using Eum.Shared.Common.Helpers.MVC;
using Eum.Shared.Common.Helpers.SeriLog;
using Eum.Shared.Common.Swagger;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Eum.Shared.Common.Extentions
{
    public static class EumWebApplicationExtention
    {

        public static WebApplicationBuilder EumWebApplicationBuilder(this WebApplicationBuilder builder)
        {
            //Custom 하게 추가된 내용은 여기서 모두 정의함

            #region [Api Versioning]
            builder.Services.AddEndpointsApiExplorer()
                            .AddApiVersioning(EumMVCHelper.ConfigureApiVersoning)
                            .AddVersionedApiExplorer(EumMVCHelper.ConfigureApiExplorer);
            #endregion

            #region [Swagger]
            builder.Services.AddSwaggerGen(EumSwaggerHelper.ConfigureSwaggerGen);
            #endregion

            #region [Add Eum Module Controller ]
            builder.Services.AddEumController();
            #endregion

            #region [Repository Dependency Injection : Using AutoFac]
            var eumAssemblies = AppDomain.CurrentDomain.GetEumModuleAssemblies();

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
             {
                 builder.RegisterAssemblyTypes(eumAssemblies)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
             });
            #endregion

            #region [Library Dependency Injection : AutoMapper, MediatR]
            builder.Services.AddAutoMapper(eumAssemblies).AddMediatR(eumAssemblies);
            #endregion

            #region [SeriLog]
            builder.Host.UseSerilog(EumSeriLogHelper.ConfigureEumLogger);
            #endregion


            return builder;
        }

        public static WebApplication EumWebApplication(this WebApplication app)
        {
            #region [Swagger]
            EumSwaggerHelper.provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(EumSwaggerHelper.ConfigureSwagger)
                   .UseSwaggerUI(EumSwaggerHelper.ConfigureSwaggerUI);
            }
            #endregion

            #region [Default Web Api]
            app.UseStaticFiles()
               .UseRouting()
               .UseEndpoints(endpoints => { endpoints.MapControllers(); });
            #endregion

            return app;
        }
    }
}

