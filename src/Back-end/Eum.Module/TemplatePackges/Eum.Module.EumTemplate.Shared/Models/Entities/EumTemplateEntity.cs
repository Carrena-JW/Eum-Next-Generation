
namespace Eum.Module.EumTemplate.Shared.Models.Entities;

public class EumTemplateEntity : IEntity
{
    public int? Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string CreatedId { get; set; }
    public string UpdatedId { get; set; }
}