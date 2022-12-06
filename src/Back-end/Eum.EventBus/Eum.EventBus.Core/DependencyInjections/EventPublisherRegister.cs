namespace Eum.EventBus.Core.DependencyInjections;

public class EventPublisherRegister
{
    private readonly HashSet<Type> _types = new HashSet<Type>();

    public IEnumerable<Type> Types => _types.ToList().AsReadOnly();

    internal void Add<TEventPublisher>()
        where TEventPublisher : class, IEventPublisher
    {
        _types.Add(typeof(TEventPublisher));
    }
}

