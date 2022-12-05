using Eum.Shared.Common.Events;

namespace Eum.Module.Board.Core.Events
{
    public class TestBoardEvent : IBoardEvent
    {
        public string Message { get; set; }
        public string TypeName { get ; set; }
        public Guid Id { get ; set; }
    }
}
