namespace Eum.Module.Board.Shared.Interface.Repositoires;
public interface IArticleRepository<T> :  IRepository<T>  where T : IEntity
{
    Task<int> CreateArticleAsync(T data);
    Task UpdateArticleAsync(T data);
    Task DeleteArticleAsync(int id);
}
