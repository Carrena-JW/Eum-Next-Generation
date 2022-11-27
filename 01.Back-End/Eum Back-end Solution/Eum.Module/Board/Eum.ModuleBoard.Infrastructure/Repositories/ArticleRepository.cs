using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eum.Module.Board.Shared.Interfaces;
using Eum.Common.Interfaces;
using Eum.Module.Board.Shared.Interface.Repositoires;

namespace Eum.Module.Board.Infrastructure.Repositoires
{

    public class TestDatabase : IArticleRepository
    {
        public List<Article> _list = new List<Article>
        {
            new Article { Id = 1, Subject = "this is first article" },
            //_list.Add(new Article { Id = 2, Subject = "this is 2 article" });
            //_list.Add(new Article { Id = 3, Subject = "this is 3 article" });
            //_list.Add(new Article { Id = 4, Subject = "this is 4 article" });

        };
        

        public async Task<Article> Create(Article input)
        {
            _list.Add(input);
            return input;
            
        }

        public async Task<Article> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Article> Update(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Article> Read(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Article>> GetAll()
        {
            return _list;
        }


        public void Dispose()
        {
            
        }
    }

    public class Article : IArticle
    {
        public int Id { get; set; }
        public string Subject { get; set; }

    }
}
