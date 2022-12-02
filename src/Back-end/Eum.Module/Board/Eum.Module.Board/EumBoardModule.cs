using Eum.Module.Board.Infrastructure.Queries;
using Eum.Module.Board.Infrastructure.Repositoires;
using Eum.Module.Board.Shared.Interface.Repositoires;
using Eum.Shared.Common.Interfaces;
using System.Reflection;

namespace Eum.Module.Board;

public class EumBoardModule : Autofac.Module
{
    public EumBoardModule() { }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterMediatorModule();

        //전부 추가해줘야ㅕ되나?
        builder.RegisterGeneric(typeof(ArticleRepository<>)).As(typeof(IArticleRepository<>)).InstancePerLifetimeScope();
        builder.RegisterType<ArticleQueries>().As<IArticleQueries>().InstancePerLifetimeScope();
 

    }
}
