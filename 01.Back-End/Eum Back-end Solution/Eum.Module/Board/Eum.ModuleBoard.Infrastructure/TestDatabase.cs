using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eum.Module.Board.Infrastructure
{
    public class TestDatabase
    {
        public static List<Article> _list;
        public TestDatabase()
        {
            _list.Add(new Article { Id = 1, Subject = "this is first article" });
            _list.Add(new Article { Id = 2, Subject = "this is 2 article" });
            _list.Add(new Article { Id = 3, Subject = "this is 3 article" });
            _list.Add(new Article { Id = 4, Subject = "this is 4 article" });
        }

        public async Task<List<Article>> GetArticles()
        {
            return _list;
        }

        public async Task<Article> CreateArticle(Article request)
        {
            _list.Add(request);
            return request;
        } 
    }

    public class Article
    {
        public int Id { get; set; }
        public string Subject { get; set; }

    }
}
