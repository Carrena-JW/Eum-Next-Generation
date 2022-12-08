namespace Eum.EventBus.Abstractions;

public interface IEventHandler<TEvent>
{
    Task HandleEventAsync(TEvent @event);
}