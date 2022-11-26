using Eum.Module.Board.Infrastructure;
using Eum.Module.Board.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eum.Module.Board.Handlers
{
    public class GetArticlesQueryHandler : IRequestHandler<GetArticlesQuery, List<Article>>
    {
        private readonly TestDatabase _repository;
        public GetArticlesQueryHandler(TestDatabase repository)
        {
            _repository = repository;
        }
        public async Task<List<Article>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetArticles();
        }
    }
}
