


namespace Eum.Module.Board.Controllers.v2;


[ApiVersion("2.0")]
internal class BoardAdminController : EumControllerBase
{
    [HttpGet]
    [MapToApiVersion("2.0")]
    public async Task<IActionResult> Get()
    {
        return Ok("this is boardadmin controller v2.0");
    }
}

