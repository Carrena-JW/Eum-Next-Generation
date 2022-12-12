using Autofac;
using Eum.Module.Organization.Infrastructure.Queries;
using Eum.Module.Organization.Infrastructure.Repositories;
using Eum.Module.Organization.Shared.Interfaces.Queries;
using Eum.Module.Organization.Shared.Interfaces.Repositories;
using Eum.Shared.Common.Extentions;

namespace Eum.Module.Organization;
public class EumOrganizationModule : Autofac.Module
// public class EumOrganizationModule : Autofac.Module, IModuleSubscriber
{
    // public void SetSubscriber(IEventBusSubscriber subscriber)
    // {
    //     subscriber.Subscribe<IOrganizationEvent, RouteOrganizationEventHandler>();
    // }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterMediatorModule();
        // //전부 추가해줘야ㅕ되나?
        builder.RegisterGeneric(typeof(CompanyRepository<>)).As(typeof(ICompanyRepository<>)).InstancePerLifetimeScope();
        builder.RegisterGeneric(typeof(CompanyExtentionRepository<>)).As(typeof(ICompanyExtentionRepository<>)).InstancePerLifetimeScope();
        builder.RegisterType<CompanyQueries>().As<ICompanyQueries>().InstancePerLifetimeScope();
        // builder.RegisterType<MasterEventBus>().As<IEventPublisher>().SingleInstance();
    }
}