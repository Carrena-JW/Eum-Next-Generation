namespace Eum.Module.Board.Controllers.v1._0;

[ApiVersion("1.0")]
internal class ArticlesController : EumControllerBase
{
    private readonly IArticleQueries _articleQueries;
    private readonly IMediator _mediator;
    public ArticlesController(IArticleQueries articleQueries, IMediator mediator)
    {
        _articleQueries = articleQueries;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetArticles()
    {
        return Ok(await _articleQueries.GetArticles<AritlceQueryViewModel>());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetArticleById(int id)
    {
        return Ok(await _articleQueries.GetArticleById<AritlceQueryViewModel>(id));
    }

    [HttpGet("paginated")]
    public async Task<IActionResult> GetPaginatedArticles([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0, [FromQuery] string searchWord = "")
    {
        return Ok(await _articleQueries.GetPaginatedArticles<AritlceQueryViewModel>(pageSize, pageIndex, searchWord));
    }

    [HttpPost]
    public async Task<IActionResult> CreateArticle([FromBody] CreateArticleCommand message)
    {
        var result = await _mediator.Send(message);
        return CreatedAtAction("CreatedArticle", result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateArticle([FromBody] UpdateArticleCommand message)
    {
        return Ok(await _mediator.Send(message));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArticle([FromBody] UpdateArticleCommand message)
    {
        return Ok(await _mediator.Send(message));
    }

}
