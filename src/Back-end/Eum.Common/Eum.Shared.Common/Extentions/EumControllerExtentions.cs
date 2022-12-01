namespace Eum.Shared.Common.Extentions;
public static class ControllerExtentions
{
    public static IServiceCollection AddEumController(this IServiceCollection services)
    {
        services.AddControllers().ConfigureApplicationPartManager(manager =>
        {
            manager.FeatureProviders.Add(new ControllerProvier());
        });
        
        return services;
    }
}
