using System;
using Eum.Module.Board.Infrastructure.Repositoires;
using Eum.Module.Board.Shared.Entities;
using Eum.Module.Board.Shared.Interface.Repositoires;
using Eum.Shared.Common.Bases;
using Eum.Shared.Common.Extentions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Eum.Module.Board
{
	public class BoardModuleStartup : EumModuleBase
    {
		
        public override void InitiailzeModule(IServiceCollection services)
        {
            //var assemblies = AppDomain.CurrentDomain.GetEumModuleAssemblies();

            services.AddScoped(typeof(IArticleRepository<ArticleEntity>), typeof(ArticleRepository));
            //Reference project dependency injection

            //Eum.Module.Board.Core
            //Eum.Module.Board.Infrastructure
        }
    }
}

