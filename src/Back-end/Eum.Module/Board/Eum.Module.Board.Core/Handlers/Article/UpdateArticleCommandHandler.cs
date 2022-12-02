using Eum.Module.Board.Shared.Models.Entities;

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
        //validation 은 핸들러에서 처리한다.

        var entity = new ArticleEntity
        {
            Id = message.Id,
            Subject = message.Subject,
            Contents = message.Contents
        };

        await _repository.UpdateArticleAsync(entity);
        return true;
    }
}

