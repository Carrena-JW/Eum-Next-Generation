namespace Eum.EventBus.Abstractions;

public interface IEventSerializer
{
    string Serialize<TEvent>(TEvent @event);
}
