namespace Eum.EventBus.Abstractions;

public interface IEventPublisherProvider
{
    IEnumerable<IEventPublisher> GetEventPublishers();
}