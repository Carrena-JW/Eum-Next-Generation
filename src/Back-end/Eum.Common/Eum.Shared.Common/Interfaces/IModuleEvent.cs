namespace Eum.Shared.Common.Interfaces;

public interface IModuleEvent
{
    public Guid Id { get; set; }
    public string TypeName { get; set; }
}