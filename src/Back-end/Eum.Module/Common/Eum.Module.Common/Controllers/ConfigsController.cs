

using Eum.Module.Common.Shared.Interfaces;
using MediatR;

namespace Eum.Module.Common.Controllers;

public class ConfigsController : EumControllerBase
{
    private readonly IConfigQueries _Queries;
    private readonly IMediator _mediator;
    
    public ConfigsController(IConfigQueries Queries, IMediator mediator)
    {
        _mediator = mediator;
        _Queries = Queries;
    }
}