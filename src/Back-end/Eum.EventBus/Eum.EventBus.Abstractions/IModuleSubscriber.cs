namespace Eum.EventBus.Abstractions;

public interface IModuleSubscriber
{
    void SetSubscriber(IEventBusSubscriber subscriber);
}