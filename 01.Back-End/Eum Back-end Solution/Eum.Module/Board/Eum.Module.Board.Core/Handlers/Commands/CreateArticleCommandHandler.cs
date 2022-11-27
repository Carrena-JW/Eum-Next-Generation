using Eum.Common.Interfaces;
using Eum.Module.Board.Shared.Entities;
using Eum.Module.Board.Shared.Interface.Repositoires;
using Eum.Module.Board.Shared.Interfaces;
using MediatR;

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

        public CreateArticleCommandHandler(IArticleRepository<ArticleEntity> repository)
        {
            _repository = repository;
            
        }
        public async Task<int> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var input = request.NewValue;
            var createdId = await _repository.Create(input);
            return createdId;
        }

        
    }
}
