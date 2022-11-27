using Eum.Module.Board.Core.Handlers.Commands;
using Eum.Module.Board.Core.Handlers.Queries;
using Eum.Module.Board.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Eum.Module.Board.Controllers.v1._0
{

    [ApiController]
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/[controller]")]
    internal class ArticleController : ControllerBase
    {

        private readonly IMediator _mediator;
        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result= await _mediator.Send(new GetArticlesQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle([FromBody] Article request)
        {
            var result = await _mediator.Send(new CreateArticleCommand<Article>() { NewArticle = request });
            return Ok(result);
        }

    }

}
