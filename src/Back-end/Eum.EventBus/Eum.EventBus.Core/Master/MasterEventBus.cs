namespace Eum.EventBus.Core.MultiChannel;

public class MasterEventBus : IEventPublisher
{
    //private readonly IServiceProvider _serviceProvider;
    private readonly IEventPublisherProvider _eventPublishers;

    public MasterEventBus(
        IEventPublisherProvider eventPublishers)
    {
        _eventPublishers = eventPublishers;
    }

    public async Task PublishEventAsync<TEvent>(TEvent @event)
    {
        foreach (var publisher in _eventPublishers.GetEventPublishers()) await publisher.PublishEventAsync(@event);
    }
}