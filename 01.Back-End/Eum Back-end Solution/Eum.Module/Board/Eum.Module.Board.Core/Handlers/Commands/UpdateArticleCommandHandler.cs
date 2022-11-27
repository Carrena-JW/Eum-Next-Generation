using System;
using Eum.Module.Board.Shared.Entities;
using Eum.Module.Board.Shared.Interface.Repositoires;
using MediatR;

namespace Eum.Module.Board.Core.Handlers.Commands
{
	 
    public record UpdateArticleHandler : IRequest<ArticleEntity>
    {
        public ArticleEntity UpdateValue { get; set; }
    }

    public class UpdateArticleCommandHandler :  IRequestHandler<UpdateArticleHandler, ArticleEntity>
    {
        //private readonly TestDatabase _repository;
        private readonly IArticleRepository<ArticleEntity> _repository;

        public UpdateArticleCommandHandler(IArticleRepository<ArticleEntity> repository)
        {
            _repository = repository;

        }
        public async Task<ArticleEntity> Handle(UpdateArticleHandler request, CancellationToken cancellationToken)
        {
            var input = request.UpdateValue;
            await _repository.Update(input);
            return input;
        }


    }
    
}

