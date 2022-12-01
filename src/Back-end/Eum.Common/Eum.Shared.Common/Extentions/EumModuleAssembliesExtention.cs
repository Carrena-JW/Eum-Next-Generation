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

    public static ContainerBuilder RegisterEumServiceModule(this ContainerBuilder container)
    {
        var calling = Assembly.GetCallingAssembly();
        var rootModuleName = calling.FullName.Split(",")[0] ?? defaultModuleName;
        var referencedModules = AppDomain.CurrentDomain.GetEumModuleAssemblies(rootModuleName);

        container.RegisterAssemblyTypes(referencedModules)
                .Where(t => t.Name.EndsWith("Repository") || t.Name.EndsWith("Queries"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

        return container;
    }
}

