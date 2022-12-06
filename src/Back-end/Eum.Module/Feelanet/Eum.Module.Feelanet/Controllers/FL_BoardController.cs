using System;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;

namespace Eum.Module.Feelanet.Controllers
{
    [ApiController]
    [Route("/api/fl/board")]
    internal class FL_BoardsController : ControllerBase
    {

        [HttpGet]
      
        public async Task<IActionResult> Get()
        {
            //  throw new Exception();
            return Ok("this is version feelanet");
        }

    }
}

