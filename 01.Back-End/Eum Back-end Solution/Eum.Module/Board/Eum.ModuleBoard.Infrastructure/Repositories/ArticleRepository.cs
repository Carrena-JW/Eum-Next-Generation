using Eum.Module.Board.Shared.Entities;
using Eum.Module.Board.Shared.Interface.Repositoires;

namespace Eum.Module.Board.Infrastructure.Repositoires
{

    public class ArticleRepository : IArticleRepository<ArticleEntity>
    {
        public List<ArticleEntity> _list = new List<ArticleEntity>
        {
            new ArticleEntity { Id = 1, Subject = "this is first article" },
            //_list.Add(new Article { Id = 2, Subject = "this is 2 article" });
            //_list.Add(new Article { Id = 3, Subject = "this is 3 article" });
            //_list.Add(new Article { Id = 4, Subject = "this is 4 article" });

        };
        

        public async Task<ArticleEntity> Create(ArticleEntity input)
        { 
            _list.Add(input);
            return input;
            
        }

        public async Task<ArticleEntity> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ArticleEntity> Update(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ArticleEntity> Read(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ArticleEntity>> GetAll()
        {
            return _list;
        }


        public void Dispose()
        {
            
        }
    }

 
}
