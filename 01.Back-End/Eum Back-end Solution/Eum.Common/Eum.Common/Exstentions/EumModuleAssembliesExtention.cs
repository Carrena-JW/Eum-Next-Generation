using System;
using System.Reflection;

namespace Eum.Shared.Infrastructure.Extentions
{
	public static class EumModuleAssembliesExtention
	{
		public static Assembly[] GetEumModuleAssemblies(this AppDomain appDomain)
		{
			var assemblies = appDomain.GetAssemblies();
            
            return assemblies.Where(a => a.FullName.StartsWith("Eum.Module")).ToArray();
            
		}
	}
}

