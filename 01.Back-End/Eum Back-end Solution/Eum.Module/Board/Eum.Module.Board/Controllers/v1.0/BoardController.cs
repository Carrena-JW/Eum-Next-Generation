using Microsoft.AspNetCore.Mvc;

namespace Eum.Module.Board.Controllers.v1._0
{

    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiController]
    [Route("/api/v{version:apiVersion}/[controller]")]
    internal class BoardController : ControllerBase
    {

        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Get()
        {
            return Ok("this is version v1.0");
        }

        [HttpGet]
        [MapToApiVersion("2.0")]
        public async Task<IActionResult> GetV2()
        {
            return Ok("this is version v2.0");
        }
    }

}
