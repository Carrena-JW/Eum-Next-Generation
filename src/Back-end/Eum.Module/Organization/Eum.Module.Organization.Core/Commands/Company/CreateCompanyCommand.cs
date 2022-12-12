using MediatR;

namespace Eum.Module.Organization.Core.Commands.Company;

public record CreateCompanyCommand :  IRequest<int>
{
    public string Identity { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsShow { get; set; }
    public bool IsActive { get; set; }
    public Dictionary<string,string>? Extentions { get; set; }
    
    public CreateCompanyCommand(string identity, string name, string description, bool isShow, bool isActive)
    {
        Identity = identity;
        Name = name;
        Description = description;
        IsShow = isShow;
        IsActive = isActive;
    }
    
}