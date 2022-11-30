namespace Eum.Module.Board.Controllers.v1._0;

[ApiVersion("1.0")]
internal class ArticlesController : EumControllerBase
{
    private readonly IArticleQueries _articleQueries;
   
    public ArticlesController(IArticleQueries articleQueries)
    {
        _articleQueries = articleQueries;
    }

    [HttpGet]
    public async Task<IActionResult> GetArticles()
    {
        return Ok(await _articleQueries.GetArticles<ArticleQueryModel>());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetArticleById(int id)
    {
        return Ok(await _articleQueries.GetArticleById<ArticleQueryModel>(id));
    }

    //[HttpPost]
    //public async Task<IActionResult> CreateArticle([FromBody] ArticleRequestDTO request)
    //{
    //    var result = await _mediator.Send(new CreateArticleCommand() { NewValue = request });
    //    return Ok(result);
    //}

}
