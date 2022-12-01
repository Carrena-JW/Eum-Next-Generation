
using Eum.Shared.Common.Bases;
using System.Runtime.CompilerServices;

namespace Eum.Module.Board.Infrastructure.Repositoires;

public class ArticleRepositoryModel
{
    public string Subject { get; set; }
    public string Conteents { get; set; }
}
public class ArticleRepository : RepositoryBase, IArticleRepository<ArticleAggregate>
{
    public List<ArticleRepositoryModel> _list;
    
    

    public ArticleRepository() : base("EumBoard")
    {
        _list = new List<ArticleRepositoryModel>();
    }
 

    public async Task UpdateArticle(ArticleAggregate aggregate)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteArticle(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreateArticle(ArticleAggregate aggregate)
    {
        _list.Add(new ArticleRepositoryModel
        {
            Subject = aggregate.Subject,
            Conteents = aggregate.Contents
        });

        return 0;
    }
}




