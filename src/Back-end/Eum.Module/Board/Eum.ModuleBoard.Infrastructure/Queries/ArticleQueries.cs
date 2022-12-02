using Eum.Module.Board.Shared.Models.RequestModels;
using System.Dynamic;
using System.Text.Json.Serialization;

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

         

        return result.Cast<T>();
    }

    public async Task<PaginatedViewModel<T>> GetPaginatedArticles<T>(ArticlePaginatedRequest parameter) where T : AritlceQueryViewModel
    {
        var articles = await this.GetArticles<T>();
        var totalCount = Convert.ToInt32(articles.Count());

        Func<T, T> contentsSelector = (r) =>
        {
            if(!parameter.IncludeContents) return r; //ealry return

            r.Contents = null;
            return r;
        };

        var paginatedData = articles.Where(r => r.Subject.ToLowerInvariant().Equals(parameter.Keyword))
                                    .Select(contentsSelector)
                                    .OrderBy(r => r.Subject)
                                    .Skip(parameter.PageSize.Value * parameter.PageIndex.Value)
                                    .Take(parameter.PageSize.Value);

        var instance = (PaginatedViewModel<T>)Activator.CreateInstance(typeof(PaginatedViewModel<T>), parameter.PageIndex.Value, parameter.PageSize.Value, totalCount, paginatedData);

        return instance;
    }
}
