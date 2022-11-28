using AutoMapper;
using Eum.Module.Board.Shared.DTO;
using Eum.Module.Board.Shared.Entities;
using Eum.Module.Board.Shared.Interface.Repositoires;
using MediatR;

namespace Eum.Module.Board.Core.Handlers.Queries
{
    public record GetArticlesQuery : IRequest<List<ArticleDTO>>
    {
    }

    public class GetArticlesQueryHandler : IRequestHandler<GetArticlesQuery, List<ArticleDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository<ArticleEntity> _repository;

        public GetArticlesQueryHandler(IArticleRepository<ArticleEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public virtual async Task<List<ArticleDTO>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
        {
            var entities =  await _repository.GetAll();
            return _mapper.Map<List<ArticleDTO>>(entities);
        }
    }
}

 