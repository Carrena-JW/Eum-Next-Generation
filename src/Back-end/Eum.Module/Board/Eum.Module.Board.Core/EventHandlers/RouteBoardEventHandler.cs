using Eum.Shared.Common.Events;
using Microsoft.Extensions.Caching.Memory;

namespace Eum.Module.Board.Core.EventHandlers
{
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
                //여기가 성공
                return Task.CompletedTask;
            }
            else
            {
                //트렌잭션 실패 
                return Task.CompletedTask;
            }


           
        }
    }
}
