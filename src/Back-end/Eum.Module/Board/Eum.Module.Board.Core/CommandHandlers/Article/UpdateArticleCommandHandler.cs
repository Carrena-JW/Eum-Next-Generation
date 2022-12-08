namespace Eum.Module.Board.Core.CommandHandlers.Article;

public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, bool>
{
    private readonly IMemoryCache _cache;

    private readonly IEventPublisher _eventPublisher;

    //private readonly TestDatabase _repository;
    private readonly IArticleRepository<ArticleEntity> _repository;

    public UpdateArticleCommandHandler(IArticleRepository<ArticleEntity> repository, IEventPublisher eventPublisher,
            IMemoryCache cache)
        //public UpdateArticleCommandHandler(IArticleRepository<ArticleEntity> repository)
    {
        _repository = repository;
        _eventPublisher = eventPublisher;
        _cache = cache;
    }

    public async Task<bool> Handle(UpdateArticleCommand message, CancellationToken cancellationToken)
    {
        var transactionId = Guid.NewGuid();
        //validation 은 핸들러에서 처리한다.
        //using (var scope = new transactionscope)
        try
        {
            var entity = new ArticleEntity
            {
                Id = message.Id,
                Subject = message.Subject,
                Contents = message.Contents
            };
            await _repository.UpdateArticleAsync(entity);

            //throw new Exception();

            // transaction 보장
            _cache.Set(transactionId, transactionId);
        }
        catch (Exception ex)
        {
            _cache.Remove(transactionId); //실장 없어도 되네?
            throw;
        }

        // 다른 모듈로 이동
        var @event = new TestBoardEvent { Id = transactionId, TypeName = "adfasdfasdf" };
        await _eventPublisher.PublishEventAsync(@event);

        return true;
    }
}