using Eum.Shared.Common.Bases;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Eum.Module.Organization.Controllers.v1._0;

[ApiVersion("1.0")]
public class UsersController : EumControllerBase
{
    private readonly IMediator _mediator;
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        return Ok();
    }

}