namespace Eum.Module.Board.Shared.Models.QueryViewModels;

public record AritlceQueryViewModel
{
    public int Id { get; set; }
    public string Subject { get; init; }
    public string Contents { get; set; }
}

public record CommentQueryModel
{
}

public record RecommandQueryModel
{
}