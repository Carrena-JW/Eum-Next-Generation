namespace Eum.Shared.Common.Bases;

public class RepositoryBase : IDisposable
{
    public RepositoryBase(string connectionStringKey)
    {
        string text = connectionStringKey ?? "EumCommon";
    }
    public void Dispose()
    {
         
    }
}
