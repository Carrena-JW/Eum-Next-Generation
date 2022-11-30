using Eum.Shared.Common.Bases;

namespace Eum.Module.Board.Shared.Interface.Repositoires;
public interface IArticleRepository<T> :  IRepository<T> where T : class, IAggregateRoot
{
    Task<int> CreateArticle(T aggregate);
    Task UpdateArticle(T aggregate);
    Task DeleteArticle(int id);
}
