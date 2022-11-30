
namespace Eum.Module.Board.Shared.Models.QueryModels;

public record Article  
{
    public string Subject { get; init; }
    public List<Comment> Comments { get; set; }
    public List<Recommand> Recommands { get; set; }
    public string CreatedUserName { get; init; }
    public string CreatedUserTitle { get; init; }
    public string CreatedUserDeptName { get; init; }
}

public record Comment
{
     
}

public record Recommand
{

}
 