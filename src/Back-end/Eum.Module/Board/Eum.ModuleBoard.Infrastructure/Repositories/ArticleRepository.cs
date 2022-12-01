using Eum.Module.Board.Shared.Models.Entities;

namespace Eum.Module.Board.Infrastructure.Repositoires;

public class ArticleRepository : RepositoryBase, IArticleRepository<ArticleEntity>
{
    public ArticleRepository() : base("EumBoard") { }

    public async Task<int> CreateArticleAsync(ArticleEntity data)
    {
        using var connection = new SqlConnection(base.connectionStrings);
        connection.Open();

        var qs = base.CreateQuerySet(QueryCommandType.Create, "TC_ARTICLE", data);

        return (await connection.QueryAsync<int>(qs, data)).FirstOrDefault();
    }

    public async Task UpdateArticleAsync(ArticleEntity data)
    {
        using var connection = new SqlConnection(base.connectionStrings);
        connection.Open();

        var qs = base.CreateQuerySet(QueryCommandType.Update, "TC_ARTICLE", data, data.Id);

        await connection.ExecuteAsync(qs, data);
    }

    public async Task DeleteArticleAsync(int id)
    {
        using var connection = new SqlConnection(base.connectionStrings);
        connection.Open();

        var qs = base.CreateQuerySet(QueryCommandType.Update, "TC_ARTICLE", null, id);

        await connection.ExecuteAsync(qs, id);
    }
}




