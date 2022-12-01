namespace Eum.Module.Board.Core.Commands.Article;
public record UpdateArticleCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public string Contents { get; set; }

    public UpdateArticleCommand(int id, string subject, string contents)
    {
        Id = id;
        Subject = subject;
        Contents = contents;
    }
}
 