namespace Eum.Module.Board.Shared.Interface.Queries;

public interface IArticleQueries : IQueries
{
    Task<IEnumerable<T>> GetAllArticle<T>() where T : Article;
}

