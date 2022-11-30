

using Eum.Module.Board.Shared.Interface.Queries;
using Eum.Module.Board.Shared.Models.QueryModels;
using Eum.Shared.Common.Bases;

namespace Eum.Module.Board.Controllers.v1._0
{

    [ApiVersion("1.0")]
    internal class ArticleController : EumControllerBase
    {
        private readonly IArticleQueries _articleQueries;
        private readonly IMediator _mediator;
        public ArticleController(IMediator mediator, IArticleQueries articleQueries)
        {
            _mediator = mediator;
            _articleQueries = articleQueries;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = _articleQueries.GetAllArticle<Article>();
            return Ok(result);
            //return Ok(await _mediator.Send(new GetArticlesQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle([FromBody] ArticleRequestDTO request)
        {
            var result = await _mediator.Send(new CreateArticleCommand() { NewValue = request });
            return Ok(result);
        }

    }

}
