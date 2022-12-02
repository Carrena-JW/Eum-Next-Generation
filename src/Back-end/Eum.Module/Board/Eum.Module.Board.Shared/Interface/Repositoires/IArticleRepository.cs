namespace Eum.Module.Board.Shared.Interface.Repositoires;
public interface IArticleRepository<T> :  IRepository<T>  where T : IEntity
{
    Task<int> CreateArticleAsync(T payload);
    Task UpdateArticleAsync(T payload);
    Task DeleteArticleAsync(int id);
}
