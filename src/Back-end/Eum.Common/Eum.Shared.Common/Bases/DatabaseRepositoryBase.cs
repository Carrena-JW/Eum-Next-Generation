using Microsoft.IdentityModel.Protocols;

namespace Eum.Shared.Common.Bases;
public class DatabaseRepositoryBase : IDisposable
{
    private string _connectionStrings;
    protected string connectionStrings { get { return _connectionStrings; } }
    private readonly string defaultKeyName = "EumCommon";
    public DatabaseRepositoryBase(string conStr = null)
    {
        var keyValue = defaultKeyName;

        if (!string.IsNullOrEmpty(conStr))
        {
            keyValue = conStr;
        }
        //var newCon = Static.Configuration.GetSection().[$"ConnectionStrings:{keyValue}"];
        //Static.Configuration.p
        _connectionStrings = Static.Configuration.GetConnectionString(keyValue);
    }
    public void Dispose()
    {

    }
}
