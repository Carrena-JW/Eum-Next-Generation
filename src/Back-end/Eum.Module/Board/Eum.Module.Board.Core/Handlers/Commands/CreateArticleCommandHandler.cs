

namespace Eum.Module.Board.Core.Handlers.Commands
{
    public record CreateArticleCommand: IRequest<int> 
    {
        public ArticleEntity NewValue { get; set; }
    }

    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, int>
    {
        //private readonly TestDatabase _repository;
        private readonly IArticleRepository<ArticleEntity> _repository;
        private readonly IMediator _mediator;

        public CreateArticleCommandHandler(IMediator mediator, IArticleRepository<ArticleEntity> repository)
        {
            _repository = repository;
            
        }
        
        public async Task<int> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request);
            var input = request.NewValue;
            var createdId = await _repository.Create(input);
            return createdId;
        }
    }
}
