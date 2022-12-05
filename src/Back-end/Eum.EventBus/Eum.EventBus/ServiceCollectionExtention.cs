namespace Eum.EventBus;

public static class ServiceCollectionExtention
{
    public static IServiceCollection AddEventBus(this IServiceCollection services,Action<IEventBusBuilder> setupAction)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        IEventBusBuilder builder = new EventBusBuilder(services)
            .UseJsonSerializer();

        setupAction?.Invoke(builder);

        return services;
    }
}
