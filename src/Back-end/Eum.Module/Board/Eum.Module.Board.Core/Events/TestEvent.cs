namespace Eum.Module.Board.Core.Events;

public class TestBoardEvent : IBoardModuleEvent
{
    public string Message { get; set; }
    public string TypeName { get; set; }
    public Guid Id { get; set; }
}