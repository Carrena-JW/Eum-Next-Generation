namespace Eum.Shared.Common.Models.CommonRequestModels;

public class PaginatedRequestModels
{
    public int? PageSize { get; set; }
    public int? PageIndex { get; set; }
    public string Keyword { get; set; } = string.Empty;
}
