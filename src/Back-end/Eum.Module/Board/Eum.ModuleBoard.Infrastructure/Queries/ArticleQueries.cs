namespace Eum.Module.Board.Infrastructure.Queries;

public class ArticleQueries : QueryBase, IArticleQueries
{
    //life time scope 
    public ArticleQueries() : base("EumBoard") { }

    public virtual async Task<IEnumerable<T>> GetArticles<T>() where T : AritlceQueryViewModel
    {
        using var connection = new SqlConnection(base.connectionStrings);
        connection.Open();

        var query =
@"
SELECT * FROM [vw_article]
";

        var result = await connection.QueryAsync<dynamic>(query);
        return result.Cast<T>().AsEnumerable();
    }

    public virtual async Task<IEnumerable<T>> GetArticleById<T>(int id) where T : AritlceQueryViewModel
    {
        using var connection = new SqlConnection(base.connectionStrings);
        connection.Open();


        var query =
@"
SELECT * FROM [vw_article]
WHERE [id] = @id
";

        var result = await connection.QueryAsync<dynamic>(query, new { id });
        return result.Cast<T>().AsEnumerable();
    }

    public async Task<PaginatedViewModel<T>> GetPaginatedArticles<T>(int pageSize, int pageIndex, string searchKeyword) where T : AritlceQueryViewModel
    {
        var articles = await this.GetArticles<T>();
        var totalCount = Convert.ToInt32(articles.Count());

        var paginatedData = articles.Where(r => r.Subject.ToLowerInvariant().Equals(searchKeyword))
                                    .OrderBy(r => r.Subject)
                                    .Skip(pageSize * pageIndex)
                                    .Take(pageSize);

        var instance = (PaginatedViewModel<T>)Activator.CreateInstance(typeof(PaginatedViewModel<T>), pageIndex, pageSize, totalCount, paginatedData);

        return instance;
    }
}
