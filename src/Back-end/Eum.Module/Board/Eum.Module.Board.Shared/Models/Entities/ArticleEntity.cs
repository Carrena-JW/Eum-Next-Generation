namespace Eum.Module.Board.Shared.Models.Entities;

public class ArticleEntity : IEntity
{
    public string Subject { get; set; } = string.Empty;
    public string Contents { get; set; } = string.Empty;
    public int? Id { get; set; }
    public string Identity { get; set; }
    public DateTime CreatedDatetime { get; set; }
    public DateTime UpdatedDatetime { get; set; }
    public string CreatedIdentity { get; set; }
    public string UpdatedIdentity { get; set; }
    
}