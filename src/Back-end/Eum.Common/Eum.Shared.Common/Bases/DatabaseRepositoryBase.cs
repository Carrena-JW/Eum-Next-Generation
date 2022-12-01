namespace Eum.Shared.Common.Bases;
public class DatabaseRepositoryBase : IDisposable
{
    private string _connectionStrings;
    protected string connectionStrings { get { return _connectionStrings; } }

    public DatabaseRepositoryBase(string conStr = null)
    {
        var keyValue = "EumCommon";

        if (!string.IsNullOrEmpty(conStr))
        {
            keyValue = conStr;
        }

        _connectionStrings = Static.Configuration.GetConnectionString(keyValue);
    }
    public void Dispose()
    {

    }
}
