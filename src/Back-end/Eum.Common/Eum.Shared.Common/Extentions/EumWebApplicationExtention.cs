namespace Eum.Shared.Common.Extentions;
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
        //각 모듈 하위로 이동
        //var eumAssemblies = AppDomain.CurrentDomain.GetEumModuleAssemblies();
        //builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
        // {
        //     //builder.RegisterGeneric(typeof(IRepository<>)).InstancePerLifetimeScope();
        //     //builder.(typeof(IQueries<>)).InstancePerLifetimeScope();

        //     builder.RegisterAssemblyTypes(eumAssemblies)
        //    .Where(t => t.Name.EndsWith("Repository") || t.Name.EndsWith("Queries"))
        //    .AsImplementedInterfaces()
        //    .InstancePerLifetimeScope();
        // });
        #endregion

        #region [Library Dependency Injection : AutoMapper, MediatR]
        //mapper 는 사용 보류(안해도 될 거같은데) 
        var eumAssemblies = AppDomain.CurrentDomain.GetEumModuleAssemblies();
        builder.Services.AddMediatR(eumAssemblies);
        #endregion

        #region [SeriLog]
        builder.Host.UseSerilog(EumSeriLogHelper.ConfigureEumLogger);
        #endregion

        return builder;
    }

    public static WebApplication EumWebApplication(this WebApplication app)
    {
        var isDevelment = app.Environment.IsDevelopment();
        EumSwaggerHelper.provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();


        #region [ServiceProvider]
        Static.ServiceProvider = app.Services;
        #endregion

        #region [Appsettings]

        Static.Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

        #endregion

        #region [Swagger]

        if (isDevelment)
        {
            app.UseSwagger(EumSwaggerHelper.ConfigureSwagger)
               .UseSwaggerUI(EumSwaggerHelper.ConfigureSwaggerUI);
 
        }

        #endregion

        #region [Default Web Api]
        app.UseStaticFiles()
           .UseRouting()
           .UseEndpoints(endpoints =>
           {
               //[Root path redirect]
               if (isDevelment)
               {
                   endpoints.MapGet("/", async context =>
                   {
                       context.Response.Redirect("/swagger");
                       await Task.CompletedTask;
                   });
               }

               endpoints.MapControllers();
           });
        #endregion

        return app;
    }

    public static WebApplicationBuilder AddEumModule(this WebApplicationBuilder builder, Action<ContainerBuilder> container)
    {
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(container);
        return builder;
    }
}

