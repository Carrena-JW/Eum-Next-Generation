﻿namespace Eum.Module.Board.Core.CommandHandlers.Article;

public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, int>
{
    //private readonly TestDatabase _repository;
    private readonly IArticleRepository<ArticleEntity> _repository;
    private readonly IMediator _mediator;

    public CreateArticleCommandHandler(IMediator mediator, IArticleRepository<ArticleEntity> repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateArticleCommand message, CancellationToken cancellationToken)
    {
       
        var entity = new ArticleEntity
        {
            Subject = message.Subject,
            Contents = message.Contents
        };

        return await _repository.CreateArticleAsync(entity);

        // 게시글
        
    }
}