using Eum.Shared.Common.Interfaces;

namespace Eum.Shared.Common.Extentions;

public static class EumModuleAssembliesExtention
{
    private static readonly string defaultModuleName = "Eum.Module.";
    public static Assembly[] GetEumModuleAssemblies(this AppDomain appDomain, string specificModuleName = null)
    {
        var assemblies = appDomain.GetAssemblies();
        return assemblies.Where(a => a.FullName.StartsWith(specificModuleName ?? defaultModuleName)).ToArray();
    }

    public static Assembly[] GetEumRelatedAssemblies(this AppDomain appDomain)
    {
        var currentFullName = Assembly.GetCallingAssembly().FullName;
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var relatedModules = assemblies.Where(a => a.FullName.StartsWith(currentFullName));
        return relatedModules.ToArray();
    }

    public static ContainerBuilder RegisterMediatorModule(this ContainerBuilder container)
    {
        var calling = Assembly.GetCallingAssembly();
        var rootModuleName = calling.FullName.Split(",")[0] ?? defaultModuleName;
        var referencedModules = AppDomain.CurrentDomain.GetEumModuleAssemblies(rootModuleName);

        container.RegisterAssemblyTypes(referencedModules)
                 .AsClosedTypesOf(typeof(IRequestHandler<,>));

        container.Register<ServiceFactory>(context =>
        {
            var componentContext = context.Resolve<IComponentContext>();
            return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
        });


        return container;

    }
}

