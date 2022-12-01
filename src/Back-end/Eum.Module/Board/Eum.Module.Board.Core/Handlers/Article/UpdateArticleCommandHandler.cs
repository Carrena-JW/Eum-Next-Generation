namespace Eum.Module.Board.Core.Handlers.Commands.Article;

public class UpdateArticleCommandHandler :  IRequestHandler<UpdateArticleCommand, bool>
{
    //private readonly TestDatabase _repository;
    private readonly IArticleRepository<ArticleEntity> _repository;

    public UpdateArticleCommandHandler(IArticleRepository<ArticleEntity> repository)
    {
        _repository = repository;

    }
   
    public async Task<bool> Handle(UpdateArticleCommand message, CancellationToken cancellationToken)
    {
        var entity = new ArticleEntity
        {
            Id = message.Id,
            Subject = message.Subject,
            Content = message.Contents
        };

        await _repository.UpdateArticleAsync(entity);
        return true;
    }
}

