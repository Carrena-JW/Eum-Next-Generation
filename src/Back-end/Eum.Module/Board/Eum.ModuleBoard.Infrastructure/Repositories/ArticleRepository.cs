namespace Eum.Module.Board.Infrastructure.Repositoires;

public class ArticleRepository<T> : RepositoryBase, IArticleRepository<T> where T : ArticleEntity
{
    public ArticleRepository() : base("EumBoard") { }

    public virtual async Task<int> CreateArticleAsync(T data)
    {
        using var connection = new SqlConnection(base.connectionStrings);
        connection.Open();

        var qs = base.CreateQuerySet(QueryCommandType.Create, "TC_ARTICLE", data);

        return (await connection.QueryAsync<int>(qs, data)).FirstOrDefault();
    }

    public virtual async Task UpdateArticleAsync(T data)
    {
        using var connection = new SqlConnection(base.connectionStrings);
        connection.Open();

        var qs = base.CreateQuerySet(QueryCommandType.Update, "TC_ARTICLE", data, data.Id);

        await connection.ExecuteAsync(qs, data);
    }

    public virtual async Task DeleteArticleAsync(int id)
    {
        using var connection = new SqlConnection(base.connectionStrings);
        connection.Open();

        var qs = base.CreateQuerySet(QueryCommandType.Update, "TC_ARTICLE", null, id);

        await connection.ExecuteAsync(qs, id);
    }
}




