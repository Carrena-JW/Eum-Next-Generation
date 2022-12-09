namespace Eum.Module.Board.Controllers.v1._0;

[ApiVersion("1.0")]
public class ArticlesController : EumControllerBase
{
    private readonly IArticleQueries _Queries;
    private readonly IMediator _mediator;

    public ArticlesController(IArticleQueries articleQueries, IMediator mediator)
    {
        _Queries = articleQueries;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetArticles()
    {
        return Ok(await _Queries.GetArticles<AritlceQueryViewModel>());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetArticleById(int id)
    {
        return Ok(await _Queries.GetArticleById<AritlceQueryViewModel>(id));
    }

    [HttpGet("paginated")]
    public async Task<IActionResult> GetPaginatedArticles([FromQuery] ArticlePaginatedRequest parameter)
    {
        this.Required(() => parameter.PageSize);
        this.Required(() => parameter.PageIndex);
        //this.Required(() => parameter.Keyword);

        return Ok(await _Queries.GetPaginatedArticles<AritlceQueryViewModel>(parameter));
    }

    [HttpPost]
    public async Task<IActionResult> CreateArticle([FromBody] CreateArticleCommand message)
    {
        
        return Ok(await _mediator.Send(message));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateArticle([FromBody] UpdateArticleCommand message)
    {
        await _mediator.Send(message);
        return Ok();
    }

    [HttpDelete("{message.Id}")]
    public async Task<IActionResult> DeleteArticle(DeleteArticleCommand message)
    {
        await _mediator.Send(message);
        return Ok();
    }
}