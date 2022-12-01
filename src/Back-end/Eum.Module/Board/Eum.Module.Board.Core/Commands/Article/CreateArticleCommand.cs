namespace Eum.Module.Board.Core.Commands.Article;

public record CreateArticleCommand : IRequest<int>
{

    public string Subject { get; set; }
    public string Contents { get; set; }

    public CreateArticleCommand(string subject, string contents)
    {
        Subject = subject;
        Contents = contents;
    }
}

