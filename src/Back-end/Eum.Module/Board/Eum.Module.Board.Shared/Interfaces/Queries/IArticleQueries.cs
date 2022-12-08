using Eum.Module.Board.Shared.Models.RequestModels;

namespace Eum.Module.Board.Shared.Interface.Queries;

public interface IArticleQueries : IQueries
{
    Task<IEnumerable<T>> GetArticles<T>() where T : AritlceQueryViewModel;
    Task<T> GetArticleById<T>(int id) where T : AritlceQueryViewModel;

    Task<PaginatedViewModel<T>> GetPaginatedArticles<T>(ArticlePaginatedRequest parameter)
        where T : AritlceQueryViewModel;
}