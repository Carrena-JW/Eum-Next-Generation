namespace Eum.Shared.Common.Helpers.SeriLog;

public class EumSeriLogHelper
{
    public static void ConfigureEumLogger(HostBuilderContext context, LoggerConfiguration config)
    {
        //appsetting ? or hard-coding
        config.WriteTo.Console().ReadFrom.Configuration(context.Configuration);
    }
}