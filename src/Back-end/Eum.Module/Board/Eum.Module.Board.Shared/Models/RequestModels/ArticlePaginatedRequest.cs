using Eum.Shared.Common.Models.CommonRequestModels;

namespace Eum.Module.Board.Shared.Models.RequestModels;

public class ArticlePaginatedRequest : PaginatedRequestModels
{
    public bool IncludeContents { get; set; } = false;
}