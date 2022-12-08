using Eum.Shared.Common.Bases;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Eum.Module.Organization.Controllers.v1._0;

[ApiVersion("1.0")]
public class CompaniesController : EumControllerBase
{
    private readonly IMediator _mediator;

    public CompaniesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetCompanies()
    {
        return Ok();
    }
}