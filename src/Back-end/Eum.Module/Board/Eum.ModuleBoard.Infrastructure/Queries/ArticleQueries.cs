namespace Eum.Module.Board.Infrastructure.Queries;

public class ArticleQueries : QueryBase, IArticleQueries
{
    //life time scope 
    public ArticleQueries() : base("EumBoard")
    {
    }

    public virtual async Task<IEnumerable<T>> GetArticles<T>() where T : AritlceQueryViewModel
    {
        using var connection = new SqlConnection(connectionStrings);
        connection.Open();

        var query =
@"
SELECT * FROM [vw_article]
";

        return await connection.QueryAsync<T>(query);
    }

    public virtual async Task<T> GetArticleById<T>(int id) where T : AritlceQueryViewModel
    {
        using var connection = new SqlConnection(connectionStrings);
        connection.Open();


        var query =
@"
SELECT * FROM [vw_article]
WHERE [id] = @id
";

        return (await connection.QueryAsync<T>(query, new { id })).FirstOrDefault();
    }

    public async Task<PaginatedViewModel<T>> GetPaginatedArticles<T>(ArticlePaginatedRequest parameter)
        where T : AritlceQueryViewModel
    {
        var articles = await GetArticles<T>();
        var totalCount = Convert.ToInt32(articles.Count());

        var contentsSelector = (T r) =>
        {
            if (!parameter.IncludeContents) return r; //ealry return

            r.Contents = null;
            return r;
        };

        var paginatedData = articles.Where(r => r.Subject.ToLowerInvariant().Contains(parameter.Keyword))
            .Select(contentsSelector)
            .OrderBy(r => r.Subject)
            .Skip(parameter.PageSize.Value * parameter.PageIndex.Value)
            .Take(parameter.PageSize.Value);

        var instance = (PaginatedViewModel<T>)Activator.CreateInstance(typeof(PaginatedViewModel<T>),
            parameter.PageIndex.Value, parameter.PageSize.Value, totalCount, paginatedData);

        return instance;
    }
}