namespace Eum.Shared.Common.Events;

public class ICommonModuleEvent : IModuleEvent
{
    public Guid Id { get; set; }
    public string TypeName { get; set; }
}