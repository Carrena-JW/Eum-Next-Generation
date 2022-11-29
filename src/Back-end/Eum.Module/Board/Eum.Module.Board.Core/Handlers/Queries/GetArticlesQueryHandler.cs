

namespace Eum.Module.Board.Core.Handlers.Queries
{
    //복잡하게 이렇게 안함

    public record GetArticlesQuery : IRequest<List<ArticleReponseDTO>>
    {
    }

    public class GetArticlesQueryHandler : IRequestHandler<GetArticlesQuery, List<ArticleReponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository<ArticleEntity> _repository;

        public GetArticlesQueryHandler(IArticleRepository<ArticleEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public virtual async Task<List<ArticleReponseDTO>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
        {
            var entities =  await _repository.GetAll();
            return _mapper.Map<List<ArticleReponseDTO>>(entities);
        }
    }
}

 