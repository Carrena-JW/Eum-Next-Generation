namespace Eum.EventBus.Core.DependencyInjections;

internal class EventPublisherProvider : IEventPublisherProvider
{
    private readonly EventPublisherRegister _eventPublishers;
    private readonly IServiceProvider _serviceProvider;

    public EventPublisherProvider(
        IServiceProvider serviceProvider,
        EventPublisherRegister eventPublishers)
    {
        _serviceProvider = serviceProvider;
        _eventPublishers = eventPublishers;
    }

    public IEnumerable<IEventPublisher> GetEventPublishers()
    {
        return _eventPublishers.Types.Select(t => (IEventPublisher)_serviceProvider.GetService(t));
    }
}