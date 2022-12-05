namespace Eum.Module.Board.Core.CommandHandlers.Article;

public class DeleteArticleCommandHandler :  IRequestHandler<DeleteArticleCommand, bool>
{
    //private readonly TestDatabase _repository;
    private readonly IArticleRepository<ArticleEntity> _repository;

    public DeleteArticleCommandHandler(IArticleRepository<ArticleEntity> repository)
    {
        _repository = repository;

    }
    public async Task<bool> Handle(DeleteArticleCommand message, CancellationToken cancellationToken)
    {
        await _repository.DeleteArticleAsync(message.Id);
        return true;
    }
}

