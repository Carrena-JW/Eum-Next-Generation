namespace Eum.Module.Workflows.Controllers.v1_0;

public class TemplatesController : EumControllerBase
{
    private readonly IEumTemplateQueries _queries;
    private readonly IMediator _mediator;

    public TemplatesController(IEumTemplateQueries queries, IMediator mediator)
    {
        _mediator = mediator;
        _queries = queries;
    }

    [HttpGet]
    public async Task<IActionResult> GetTemplates()
    {
        _mediator.Send("{COMMAND");
        return Ok();
    }
}