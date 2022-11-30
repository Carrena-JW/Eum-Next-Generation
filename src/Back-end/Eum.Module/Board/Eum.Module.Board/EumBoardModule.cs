using Autofac;
using Eum.Shared.Common.Extentions;
using System.Reflection;

namespace Eum.Module.Board;

public class EumBoardModule : Autofac.Module
{
 
    public EumBoardModule()
	{
	}

    protected override void Load(ContainerBuilder builder)
    {
         


        builder.RegisterEumRepository();
    }
}
