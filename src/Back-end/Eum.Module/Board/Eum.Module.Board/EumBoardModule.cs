namespace Eum.Module.Board;

public class EumBoardModule : Autofac.Module, IModuleSubscriber
{
     
    public EumBoardModule(){ }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterMediatorModule();
        //전부 추가해줘야ㅕ되나?
        builder.RegisterGeneric(typeof(ArticleRepository<>)).As(typeof(IArticleRepository<>)).InstancePerLifetimeScope();
        builder.RegisterType<ArticleQueries>().As<IArticleQueries>().InstancePerLifetimeScope();
        builder.RegisterType<MasterEventBus>().As<IEventPublisher>().SingleInstance();
    }

    public void SetSubscriber(IEventBusSubscriber subscriber)
    {
        subscriber.Subscribe<IBoardEvent,RouteBoardEventHandler>();
    }

}
