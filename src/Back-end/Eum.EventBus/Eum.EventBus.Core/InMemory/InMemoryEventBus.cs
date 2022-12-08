namespace Eum.EventBus.Core.InMemory;

public class InMemoryEventBus : IEventPublisher
{
    private readonly IServiceProvider _serviceProvider;

    public InMemoryEventBus(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task PublishEventAsync<TEvent>(TEvent @event)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var eventType = @event.GetType();
            var interfaceTypes = eventType.GetInterfaces();
            var openHandlerType = typeof(IEventHandler<>);
            var handlerType = openHandlerType.MakeGenericType(interfaceTypes.FirstOrDefault()); // 첫번 째 상속 interface 
            // IBoardModuleEvent, IWorkflowEvent, IMailEvent etc
            var handlers = scope.ServiceProvider.GetServices(handlerType);
            foreach (var handler in handlers)
            {
                var result = handlerType
                    .GetTypeInfo()
                    .GetDeclaredMethod(nameof(IEventHandler<TEvent>.HandleEventAsync))
                    .Invoke(handler, new object[] { @event });
                await (Task)result;
            }
        }
    }
}