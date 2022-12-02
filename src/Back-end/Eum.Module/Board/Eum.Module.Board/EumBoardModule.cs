namespace Eum.Module.Board;

public class EumBoardModule : Autofac.Module
{
    public EumBoardModule() { }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterEumServiceModule();
    }

    public 
}
