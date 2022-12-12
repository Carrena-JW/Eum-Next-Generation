namespace Eum.Shared.Common.Interfaces;

public interface IEntity
{
    public int? Id { get; set; }
    public string Identity { get; set; }
    public DateTime CreatedDatetime { get; set; }
    public DateTime UpdatedDatetime { get; set; }
    public string CreatedIdentity { get; set; }
    public string UpdatedIdentity { get; set; }
}