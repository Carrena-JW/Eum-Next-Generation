namespace Eum.Module.Board.Shared.Models.QueryViewModels;

public record AritlceQueryViewModel
{
    public string Subject { get; init; }
    public List<CommentQueryModel> Comments { get; set; }
    public List<RecommandQueryModel> Recommands { get; set; }
    public string CreatedUserName { get; init; }
    public string CreatedUserTitle { get; init; }
    public string CreatedUserDeptName { get; init; }
}

public record CommentQueryModel
{
     
}

public record RecommandQueryModel
{

}
 