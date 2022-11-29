using Eum.Module.Board.Shared.Interface.Queries;
using Eum.Module.Board.Shared.Models.QueryModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
