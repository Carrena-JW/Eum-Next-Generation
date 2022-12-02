
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger(); 

Log.Information("Starting up");

try
{
    WebApplication.CreateBuilder(args)
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


