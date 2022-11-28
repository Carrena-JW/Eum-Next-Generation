using System;
using Eum.Shared.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Eum.Shared.Common.Bases
{
	public abstract class EumModuleBase : IEumModule
    {
        public abstract void InitiailzeModule(IServiceCollection services);
		
	}
}

