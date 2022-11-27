using Eum.Common.Interfaces;
using Eum.Module.Board.Shared.Entities;
using Eum.Module.Board.Shared.Interface.Repositoires;
using MediatR;

namespace Eum.Module.Board.Core.Handlers.Queries
{
    public record GetArticlesQuery : IRequest<List<ArticleEntity>>
    {
    }

    public class GetArticlesQueryHandler : IRequestHandler<GetArticlesQuery, List<ArticleEntity>>
    {
        //private readonly TestDatabase _repository;
        private readonly IArticleRepository<ArticleEntity> _repository;

        public GetArticlesQueryHandler(IArticleRepository<ArticleEntity> repository)
        {
            _repository = repository;
        }
        public async Task<List<ArticleEntity>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
