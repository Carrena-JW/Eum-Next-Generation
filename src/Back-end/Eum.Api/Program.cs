Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args)
        .AddEumEventBus(services =>
        {
            services.AddEventBus(builder =>
            {
                builder.AddInMemoryEventBus(subscriber =>
                {

                });
            });
        });
    
    // builder.Services.AddEventBus(builder =>
    // {
    //     builder
    //         .AddInMemoryEventBus(subscriber => { subscriber.Subscribe<IBoardEvent, RouteBoardEventHandler>(); });
    // });

    builder.EumWebApplicationBuilder()
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