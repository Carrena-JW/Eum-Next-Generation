using Eum.Module.Organization.Core.Commands.Company;
using Eum.Module.Organization.Shared.Interfaces.Queries;

namespace Eum.Module.Organization.Controllers.v1._0;

[ApiVersion("1.0")]
[ApiVersion("2.0")]
[ApiVersion("3.0")]
public class CompaniesController : EumControllerBase
{
    private readonly IMediator _mediator;
    private readonly ICompanyQueries _queries;
    
    public CompaniesController(ICompanyQueries queries, IMediator mediator)
    {
        _mediator = mediator;
        _queries = queries;
    }
    
    // [HttpGet]
    // public async Task<IActionResult> GetCompanies()
    // {
    //     return Ok();
    // }
    
    // HTTP POST 요청을 비동기적으로 처리하는 액션 메서드
    [HttpPost]
    public async Task<IActionResult> CreateCompanyAsync(CreateCompanyCommand payload)
    {
        // 새로운 기업 정보를 저장하는 코드
        return Ok(await _mediator.Send(payload));
    }
    //
    // // HTTP GET 요청을 비동기적으로 처리하는 액션 메서드
    // [HttpGet]
    // public async Task<IActionResult> GetAllCompaniesAsync()
    // {
    //     // 모든 기업의 정보를 조회하는 코드
    //     var companies = await GetCompaniesAsync();
    //     return Ok(companies);
    // }
    //
    // // HTTP PUT 요청을 비동기적으로 처리하는 액션 메서드
    // [HttpPut]
    // public async Task<IActionResult> UpdateCompanyAsync(Company company)
    // {
    //     // 기존 기업 정보를 수정하는 코드
    //     await UpdateCompanyAsync(company);
    //     return Ok();
    // }
}