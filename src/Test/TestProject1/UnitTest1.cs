
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var repository = new RepositoryTest("EumCommon");
        }
    }

    public class RepositoryTest : RepositoryBase
    {
        public RepositoryTest(string conStr) : base(conStr)
        {
            var querySet1 = base.CreateQuerySet(Eum.Shared.Common.Enums.QueryCommandType.Create, "vw_article", new
            {
                subject= "asdf",
                contents = "Asdfadsf",
                author = "asdfasdf"
            },123123123);
            Console.WriteLine(querySet1);

            var querySet2 = base.CreateQuerySet(Eum.Shared.Common.Enums.QueryCommandType.Update, "vw_article", new
            {
                subject = "asdf",
                contents = "Asdfadsf",
                author = "asdfasdf"
            }, 123);
            Console.WriteLine(querySet2);

            var querySet3 = base.CreateQuerySet(Eum.Shared.Common.Enums.QueryCommandType.Delete, "vw_article", new
            {
                subject = "asdf",
                contents = "Asdfadsf",
                author = "asdfasdf"
            }, 123);
            Console.WriteLine(querySet3);
        }
    }
}