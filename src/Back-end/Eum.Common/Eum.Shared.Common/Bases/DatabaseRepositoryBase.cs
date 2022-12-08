namespace Eum.Shared.Common.Bases;

public class DatabaseRepositoryBase : IDisposable
{
    private readonly string defaultKeyName = "EumCommon";

    public DatabaseRepositoryBase(string conStr = null)
    {
        var keyValue = defaultKeyName;

        if (!string.IsNullOrEmpty(conStr)) keyValue = conStr;
        //var newCon = Static.Configuration.GetSection().[$"ConnectionStrings:{keyValue}"];
        //Static.Configuration.p
        connectionStrings = Static.Configuration.GetConnectionString(keyValue);
    }

    protected string connectionStrings { get; }

    public void Dispose()
    {
    }
}