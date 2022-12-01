namespace Eum.Module.Board.Shared.Interface.Queries;

public interface IArticleQueries : IQueries
{
    Task<IEnumerable<T>> GetArticles<T>() where T : AritlceQueryViewModel;
    Task<IEnumerable<T>> GetArticleById<T>(int id) where T : AritlceQueryViewModel;
    Task<PaginatedViewModel<T>> GetPaginatedArticles<T>(int pageSize, int pageIndex, string searchKeyword) where T : AritlceQueryViewModel;
}

