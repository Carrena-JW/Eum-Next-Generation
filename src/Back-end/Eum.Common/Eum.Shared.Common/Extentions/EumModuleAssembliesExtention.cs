namespace Eum.Shared.Common.Extentions;

public static class EumModuleAssembliesExtention
{
	public static Assembly[] GetEumModuleAssemblies(this AppDomain appDomain)
	{
		var assemblies = appDomain.GetAssemblies();
            
            return assemblies.Where(a =>  a.FullName.StartsWith("Eum.Module")).ToArray();
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
        var referencedModules = AppDomain.CurrentDomain.GetEumModuleAssemblies();

        container.RegisterAssemblyTypes(referencedModules)
                .Where(t => t.Name.EndsWith("Repository") || t.Name.EndsWith("Queires") || t.Name.EndsWith("AggregateService"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        
        return container;
    }
}

