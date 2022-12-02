namespace Eum.Module.Board.Shared.Models.Entities;

public class ArticleEntity : EntityBase, IEntity
{
    public int Id { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string CreatedId { get; set; } = string.Empty;
    public string UpdatedId { get; set; } = string.Empty;
}


