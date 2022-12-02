
using Eum.Module.Board.Infrastructure.Queries;
using Eum.Module.Board.Shared.Models.QueryViewModels;
using Eum.Shared.Common;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Dynamic;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {


            Static.Configuration = new ConfigurationBuilder()
             .AddJsonFile(@"D:\01.Repository\Eum_Architecture\Eum-New-Generation\src\Back-end\Eum.Api\appsettings.Development.json")
              .AddEnvironmentVariables()
              .Build();

            var queries = new ArticleQueries();
            var rseult = await queries.GetArticleById<AritlceQueryViewModel>(12);
        }
    }

    //public class RepositoryTest : RepositoryBase
    //{
    //    public RepositoryTest(string conStr) : base(conStr)
    //    {
    //        var querySet1 = base.CreateQuerySet(Eum.Shared.Common.Enums.QueryCommandType.Create, "vw_article", new
    //        {
    //            subject= "asdf",
    //            contents = "Asdfadsf",
    //            author = "asdfasdf"
    //        },123123123);
    //        Console.WriteLine(querySet1);

    //        var querySet2 = base.CreateQuerySet(Eum.Shared.Common.Enums.QueryCommandType.Update, "vw_article", new
    //        {
    //            subject = "asdf",
    //            contents = "Asdfadsf",
    //            author = "asdfasdf"
    //        }, 123);
    //        Console.WriteLine(querySet2);

    //        var querySet3 = base.CreateQuerySet(Eum.Shared.Common.Enums.QueryCommandType.Delete, "vw_article", new
    //        {
    //            subject = "asdf",
    //            contents = "Asdfadsf",
    //            author = "asdfasdf"
    //        }, 123);
    //        Console.WriteLine(querySet3);
    //    }
    //}
}