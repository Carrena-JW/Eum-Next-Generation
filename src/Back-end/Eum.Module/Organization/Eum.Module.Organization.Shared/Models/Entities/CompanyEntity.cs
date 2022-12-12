using Eum.Shared.Common.Interfaces;

namespace Eum.Module.Organization.Shared.Models.Entities;

public class CompanyEntity : IEntity
{
    public int? Id { get; set; }
    public string Identity { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsShow { get; set; }
    public bool IsActive { get; set; }
    
    public DateTime CreatedDatetime { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDatetime { get; set; } = DateTime.UtcNow;
    public string CreatedIdentity { get; set; } = string.Empty;
    public string UpdatedIdentity { get; set; } = string.Empty;
}