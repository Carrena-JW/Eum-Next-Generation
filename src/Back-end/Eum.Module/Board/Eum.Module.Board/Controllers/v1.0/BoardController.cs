
using Eum.Shared.Common.Bases;

namespace Eum.Module.Board.Controllers.v1._0
{

    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    internal class BoardController : EumControllerBase
    {

        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Get()
        {
           //  throw new Exception();
            return Ok(await Task.FromResult("this is version v1.0"));
        }

        [HttpGet]
        [MapToApiVersion("2.0")]
        public async Task<IActionResult> GetV2()
        {
            return Ok(await Task.FromResult( "this is version v2.0"));
        }
    }

}
