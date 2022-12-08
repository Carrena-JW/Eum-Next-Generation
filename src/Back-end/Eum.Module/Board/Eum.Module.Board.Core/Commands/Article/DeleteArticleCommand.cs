namespace Eum.Module.Board.Core.Commands.Article;

public record DeleteArticleCommand : IRequest<bool>
{
    public DeleteArticleCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}