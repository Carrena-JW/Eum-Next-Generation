// namespace Eum.Module.Common.Controllers.v3_0;
//
// public class ConfigsController : EumControllerBase
// {
//     private readonly IConfigQueries _Queries;
//     private readonly IMediator _mediator;
//     
//     public ConfigsController(IConfigQueries Queries, IMediator mediator)
//     {
//         _mediator = mediator;
//         _Queries = Queries;
//     }
//     
//     [HttpPost]
//     public async Task<IActionResult> CreateArticle([FromBody] CreateArticleCommand message)
//     {
//         return Ok(await _mediator.Send(message));
//     }
// }