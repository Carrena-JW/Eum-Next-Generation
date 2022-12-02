namespace Eum.Module.Board.Shared.Models.Entities;

public class ArticleEntity : IEntity
{
    public int? Id { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Contents { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
    public string CreatedId { get; set; } = string.Empty;
    public string UpdatedId { get; set; } = string.Empty;
}


