namespace Eum.Module.Board.Core.Aggregates.ArticleAggregate
{
    public interface IArticleRepository : IRepository<Article>
    {
        Task<int> CreateAsync(Article article);
        Task UpdateAsync(Article article);
        Task DeleteAsync(int id);
        Task<Article> FindByIdAsync(int id);
    }
}

 