using Module = Autofac.Module;

namespace Eum.Shared.Common.Bases;

public abstract class EumModuleBase : Module
{
    public static void SetSubscriber<TEventSubscriber>(TEventSubscriber subscriber)
    {
    }
}