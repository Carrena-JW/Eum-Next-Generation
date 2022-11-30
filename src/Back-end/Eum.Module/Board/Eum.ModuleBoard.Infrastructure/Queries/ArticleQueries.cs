

namespace Eum.Module.Board.Infrastructure.Queries
{
    public class ArticleQueries : IArticleQueries
    {
        private string _connectionString = string.Empty;

        public ArticleQueries()
        {
            //connection string ?
        }


        public virtual Task<IEnumerable<T>> GetAllArticle<T>() where T : Article
        {
            var queryReresults = new List<dynamic>();


            return Task.FromResult(queryReresults.Cast<T>().AsEnumerable());
        }
    }
}
