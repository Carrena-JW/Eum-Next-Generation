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
                    new EumBoardModule().SetSubscriber(subscriber);
                    // EumBoardModule.SetAction(subscriber);
                    //모듈별 EventBus subscribe
                    // subscriber.Subscribe<IBoardEvent,RouteBoardEventHandler>();
                });
            });
        })
        .EumWebApplicationBuilder()
        .AddEumModule(container =>
        {
            container.RegisterModule(new EumBoardModule());
            container.RegisterModule(new EumFeelanetModule());
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