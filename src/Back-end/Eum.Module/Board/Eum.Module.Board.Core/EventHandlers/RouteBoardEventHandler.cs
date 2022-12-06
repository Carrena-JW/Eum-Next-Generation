using Eum.Shared.Common.Events;
using Microsoft.Extensions.Caching.Memory;

namespace Eum.Module.Board.Core.EventHandlers
{
    //RouterBase 를 만들어야되네 
    //** route 헬퍼
    //** create command 헬퍼
    // ** 타입찾는거 헬퍼
    public class RouteBoardEventHandler : IEventHandler<IBoardEvent>
    {
        private readonly IMemoryCache _cache;

        public RouteBoardEventHandler(IMemoryCache cache)
        {
            _cache = cache;
        }

        public Task HandleEventAsync(IBoardEvent @event)
        {

            //if (!string.IsNullOrEmpty(@event))
            //{
            //    var obj = JsonConvert.DeserializeObject(@event);
            //    var props = obj.GetType().GetProperties();
            //}

            //여기서 분기 해야되네

            if (_cache.TryGetValue<Guid>(@event.Id, out Guid guid))
            {
                //Type 을찾고 대상 command  를 찾고
                //command 를 만들고
                //마지막 _mediator.Send({COMMAND})
                //여기가 성공
                //    return Task.CompletedTask;
            }
            else
            {
                //트렌잭션 실패 작업 스킵
            }
            
            return Task.CompletedTask;


           
        }
    }
}
