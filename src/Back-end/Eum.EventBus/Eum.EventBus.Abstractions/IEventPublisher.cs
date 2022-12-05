namespace Eum.EventBus.Abstractions;

public interface IEventPublisher
{
    Task PublishEventAsync<TEvent>(TEvent @event);
}
