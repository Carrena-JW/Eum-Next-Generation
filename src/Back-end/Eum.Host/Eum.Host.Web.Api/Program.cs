// mark

using Eum.Module.Organization;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

try
{
    WebApplication.CreateBuilder(args)
        .AddEumEventBus(services =>
        {
            services.AddEventBus(builder =>
            {
                builder.AddInMemoryEventBus(subscriber =>
                {
                    //모듈별 EventBus subscribe
                    new EumCommonModule().SetSubscriber((subscriber));
                    new EumBoardModule().SetSubscriber(subscriber);
                    // EumBoardModule.SetAction(subscriber);
                    // subscriber.Subscribe<IBoardModuleEvent,RouteBoardEventHandler>();
                });
            });
        })
        .EumWebApplicationBuilder()
        .AddEumModule(container =>
        {
            container.RegisterModule(new EumCommonModule());
            container.RegisterModule(new EumBoardModule());
            container.RegisterModule(new EumOrganizationModule());
            // container.RegisterModule(new EumFeelanetModule());
        })
        .Build()
        .EumWebApplication()
        .Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}