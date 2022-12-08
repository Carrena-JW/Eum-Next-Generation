namespace Eum.Module.Board.Infrastructure.Repositoires;

public class ArticleRepository<T> : RepositoryBase, IArticleRepository<T> where T : ArticleEntity
{
    private const string targetTable = "T_BB_ARTICLE_V2";

    public ArticleRepository() : base("EumBoard")
    {
    }

    public virtual async Task<int> CreateArticleAsync(T payload)
    {
        using var connection = new SqlConnection(connectionStrings);
        connection.Open();

        var qs = CreateQuerySet(QueryCommandType.Create, targetTable, payload);

        return (await connection.QueryAsync<int>(qs, ExceptNullValueProperty(payload))).FirstOrDefault();
    }

    public virtual async Task UpdateArticleAsync(T payload)
    {
        using var connection = new SqlConnection(connectionStrings);
        connection.Open();

        var qs = CreateQuerySet(QueryCommandType.Update, targetTable, payload, payload.Id);

        await connection.ExecuteAsync(qs, ExceptNullValueProperty(payload));
    }

    public virtual async Task DeleteArticleAsync(int id)
    {
        using var connection = new SqlConnection(connectionStrings);
        connection.Open();

        var qs = CreateQuerySet(QueryCommandType.Update, targetTable, null, id);

        await connection.ExecuteAsync(qs, id);
    }
}