

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
            return Ok(await _mediator.Send(new GetArticlesQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle([FromBody] ArticleRequestDTO request)
        {
            var result = await _mediator.Send(new CreateArticleCommand() { NewValue = request });
            return Ok(result);
        }

    }

}
