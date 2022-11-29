
namespace Eum.Shared.Common.Extentions
{
    public static class EumWebApplicationExtention
    {

        public static WebApplicationBuilder EumWebApplicationBuilder(this WebApplicationBuilder builder)
        {
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

