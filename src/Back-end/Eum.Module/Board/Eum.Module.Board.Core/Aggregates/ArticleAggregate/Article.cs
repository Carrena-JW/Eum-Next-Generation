
namespace Eum.Module.Board.Core.Aggregates.ArticleAggregate;

public class Article : EntityBase, IAggregateRoot
{

    public string Contents { get; private set; }
    public string Subject { get; private set; }

    protected Article()
    {

    }
    public Article(string contents, string subject) : this()
    {

        this.Contents = contents;
        this.Subject = subject;
    }


}

