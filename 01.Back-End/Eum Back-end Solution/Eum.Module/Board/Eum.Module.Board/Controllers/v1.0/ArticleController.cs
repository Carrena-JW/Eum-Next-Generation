using Eum.Module.Board.Commands;
using Eum.Module.Board.Infrastructure;
using Eum.Module.Board.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var result= await _mediator.Send(new GetArticlesQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle([FromBody] Article request)
        {
            var result = await _mediator.Send(new CreateArticleCommand() { NewArticle = request });
            return Ok(result);
        }

    }

}
