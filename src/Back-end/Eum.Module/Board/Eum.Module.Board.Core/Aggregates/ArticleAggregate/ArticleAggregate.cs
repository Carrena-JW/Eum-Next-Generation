
namespace Eum.Module.Board.Core.Aggregates.ArticleAggregate;

public class ArticleAggregate : EntityBase, IAggregateRoot
{

    public string Contents { get; private set; }
    public string Subject { get; private set; }

    protected ArticleAggregate()
    {

    }

    public ArticleAggregate(string contents, string subject) : this()
    {

        this.Contents = contents;
        this.Subject = subject;
    }
}



