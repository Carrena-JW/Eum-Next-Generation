

namespace Eum.Shared.Common.Bases;

public class DatabaseRepositoryBase : IDisposable
{
    private readonly string defaultKeyName = "default";
    protected string connectionStrings { get; }

    public DatabaseRepositoryBase(string conStr = null)
    {
        var keyValue = defaultKeyName;

        if (!string.IsNullOrEmpty(conStr)) keyValue = conStr;

        
        if (keyValue != "default")
        {
            var systemQueries = new SystemConfigQueries();
            this.connectionStrings = systemQueries.FindByKey<SysmConfigQueryVieModel>(keyValue).Result.Value;
        }
        else
        {
            connectionStrings = Static.Configuration.GetConnectionString(keyValue);
        }
    }


    public void Dispose()
    {
    }
}