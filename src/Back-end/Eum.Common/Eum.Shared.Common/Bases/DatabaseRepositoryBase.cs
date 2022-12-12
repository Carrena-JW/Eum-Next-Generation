using System.IO.Enumeration;
using Eum.Shared.Common.Infrastructures.SystemConfigs;

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
            var allConnectionStrings = systemQueries.GetConfis<SysmConfigQueryVieModel>().Result;
            var finByKey = allConnectionStrings.Where(c => c.Key == keyValue).FirstOrDefault();
            this.connectionStrings = finByKey.Value;
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