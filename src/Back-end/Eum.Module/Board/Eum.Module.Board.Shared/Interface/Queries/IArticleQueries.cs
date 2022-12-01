namespace Eum.Module.Board.Shared.Interface.Queries;

public interface IArticleQueries : IQueries
{
    Task<IEnumerable<T>> GetArticles<T>() where T : ArticleQueryModel;
    Task<IEnumerable<T>> GetArticleById<T>(int id) where T : ArticleQueryModel;
}

