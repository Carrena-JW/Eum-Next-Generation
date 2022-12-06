

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
        using (IServiceScope scope = _serviceProvider.CreateScope())
        {
            Type eventType = @event.GetType();
            var interfaceTypes = eventType.GetInterfaces();
            Type openHandlerType = typeof(IEventHandler<>);
            Type handlerType = openHandlerType.MakeGenericType(interfaceTypes.FirstOrDefault()); // 첫번 째 상속 interface 
            // IBoardEvent, IWorkflowEvent, IMailEvent etc
            IEnumerable<object> handlers = scope.ServiceProvider.GetServices(handlerType);
            foreach (object handler in handlers)
            {
                object result = handlerType
                    .GetTypeInfo()
                    .GetDeclaredMethod(nameof(IEventHandler<TEvent>.HandleEventAsync))
                    .Invoke(handler, new object[] { @event });
                await (Task)result;
            }
        }
    }
}
