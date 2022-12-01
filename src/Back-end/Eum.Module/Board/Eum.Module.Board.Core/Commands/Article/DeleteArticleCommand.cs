namespace Eum.Module.Board.Core.Commands.Article;
public record DeleteArticleCommand : IRequest<bool>
{
    public int Id { get; set; }
    

    public DeleteArticleCommand(int id)
    {
        Id = id;
    }
}

