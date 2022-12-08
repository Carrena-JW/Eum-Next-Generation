namespace Eum.Module.Common.Core.EventHandlers;

public class RouteCommonEventHandler : IEventHandler<ICommonModuleEvent>
{
    private readonly IMemoryCache _cache;

    public RouteCommonEventHandler(IMemoryCache cache)
    {
        _cache = cache;
    }

    public Task HandleEventAsync(ICommonModuleEvent @event)
    {
        if (_cache.TryGetValue(@event.Id, out Guid guid))
        {
            //Type 을찾고 대상 command  를 찾고
            //command 를 만들고
            //마지막 _mediator.Send({COMMAND})
            //여기가 성공
            //    return Task.CompletedTask;
        }

        //트렌잭션 실패 작업 스킵
        return Task.CompletedTask;
    }
}