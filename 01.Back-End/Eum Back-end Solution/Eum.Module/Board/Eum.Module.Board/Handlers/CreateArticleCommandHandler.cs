using Eum.Module.Board.Commands;
using Eum.Module.Board.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eum.Module.Board.Handlers
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, Article>
    {
        private readonly TestDatabase _repository;
        public CreateArticleCommandHandler(TestDatabase repository)
        {
            _repository = repository;
        }
        public async Task<Article> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var input = request.NewArticle;
            await _repository.CreateArticle(input);
            return input;
        }
    }
}
