namespace Eum.Shared.Common.Bases;

public abstract class EntityBase
{
	private List<INotification> _entityEvents;
    public IReadOnlyCollection<INotification> DomainEvents => _entityEvents ?.AsReadOnly();
	 

    public void AddDomainEvent(INotification eventItem)
    {
        _entityEvents = _entityEvents ?? new List<INotification>();
        _entityEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(INotification eventItem)
    {
        _entityEvents?.Remove(eventItem);
    }

    public void ClearDomainEvents()
    {
        _entityEvents?.Clear();
    }
}

