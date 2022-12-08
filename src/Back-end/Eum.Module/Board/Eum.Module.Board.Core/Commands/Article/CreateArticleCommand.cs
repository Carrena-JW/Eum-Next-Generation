namespace Eum.Module.Board.Core.Commands.Article;

public record CreateArticleCommand : IRequest<int>
{
    public CreateArticleCommand(string subject, string contents)
    {
        Subject = subject;
        Contents = contents;
    }

    public bool isSendEmail { get; set; }

    public string Subject { get; set; }
    public string Contents { get; set; }
}