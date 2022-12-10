
namespace Eum.Module.EumTemplate;

//if you implement EventBus, you have to add interface as IModuleSubscriber
public class EumEumTemplateModule : Autofac.Module
{
    //public void SetSubscriber(IEventBusSubscriber subscriber)
    //{
    //    //이벤트와 이벤트 핸들러 구현 후 적용 
    //    //subscriber.Subscribe<IBoardModuleEvent, RouteBoardEventHandler>();
    //}

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterMediatorModule();
        
        //생성 프로젝트 내에 Repository, Queries 구현 후 DI 등록
        // builder.RegisterGeneric(typeof(ArticleRepository<>)).As(typeof(IArticleRepository<>))
        //     .InstancePerLifetimeScope();
        // builder.RegisterType<ArticleQueries>().As<IArticleQueries>().InstancePerLifetimeScope();
        // builder.RegisterType<MasterEventBus>().As<IEventPublisher>().SingleInstance();
    }
}