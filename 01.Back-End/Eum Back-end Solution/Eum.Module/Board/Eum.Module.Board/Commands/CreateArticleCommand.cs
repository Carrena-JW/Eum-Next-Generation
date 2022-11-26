using Eum.Module.Board.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eum.Module.Board.Commands
{
    public class CreateArticleCommand : IRequest<Article>
    {
        public Article NewArticle { get; set; }
    }
}
