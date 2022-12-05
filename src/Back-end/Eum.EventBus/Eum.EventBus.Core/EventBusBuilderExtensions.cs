namespace Eum.EventBus.Core;

public static class EventBusBuilderExtensions
{
    public static IEventBusBuilder AddInMemoryEventBus(this IEventBusBuilder builder, Action<IEventBusSubscriber> subscribeAction)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        var subscriber = new InMemoryEventBusSubscriber(builder.Services);
        subscribeAction?.Invoke(subscriber);

        return builder.AddEventPublisher<InMemoryEventBus>();
    }

    public static IEventBusBuilder UseJsonSerializer(this IEventBusBuilder builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        return builder.UseSerializer<JsonEventSerializer>();
    }
}