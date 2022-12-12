using Eum.Shared.Common.Interfaces;

namespace Eum.Module.Organization.Shared.Models.Entities;

public record CompanyExtentionEntity : IEntity
{
    public int? Id { get; set; }
    public string Identity { get; set; }
    public string CompanyIdentity { get; set; } // 
    public string Key { get; set; }
    public string Value { get; set; }
    
    public DateTime CreatedDatetime { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDatetime { get; set; } = DateTime.UtcNow;
    public string CreatedIdentity { get; set; } = string.Empty;
    public string UpdatedIdentity { get; set; } = string.Empty;
}