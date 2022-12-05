namespace Eum.EventBus.Abstractions;

public interface IEventBusBuilder
{
    IServiceCollection Services { get; }

    IEventBusBuilder UseSerializer<TEventSerializer>()
        where TEventSerializer : class, IEventSerializer;

    IEventBusBuilder AddEventPublisher<TEventPublisher>()
        where TEventPublisher : class, IEventPublisher;
}