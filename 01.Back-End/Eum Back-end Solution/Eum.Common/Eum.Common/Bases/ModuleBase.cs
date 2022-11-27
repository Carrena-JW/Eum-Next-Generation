using System;
using Microsoft.Extensions.DependencyInjection;

namespace Eum.Common.Bases
{
	public abstract class ModuleStartup
	{
        public abstract void InitiailzeModule(IServiceCollection services);
		
	}
}

