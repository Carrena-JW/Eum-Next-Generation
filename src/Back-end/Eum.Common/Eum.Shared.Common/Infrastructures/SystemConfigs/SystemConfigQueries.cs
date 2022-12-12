using Dapper;
using Eum.Shared.Common.Bases;
using Microsoft.Data.SqlClient;

namespace Eum.Shared.Common.Infrastructures.SystemConfigs;

//시스템 Config 읽기 전용
// ** - DB CONNECTIONS 
// ** - m365 Tenant , account
// ** - Azure app information (app key, secret key)
// ** - EWS Service account

public class SystemConfigQueries : QueryBase, ISystemConfigQueries
{
    public SystemConfigQueries() : base() { }

    public async Task<IEnumerable<T>> GetConfis<T>() where T : SysmConfigQueryVieModel
    {
        using var connection = new SqlConnection(connectionStrings);
        connection.Open();

        var query = 
@"
SELECT * FROM [EC_SYSTEM_CONFIG]
";
        return await connection.QueryAsync<T>(query);
    }

    public async Task<IEnumerable<T>> FindByCategory<T>(string category) where T : SysmConfigQueryVieModel
    {
        var configs = await this.GetConfis<T>();
        return configs.Where(c => c.Category == category);
    }

    public async Task<T> FindByKey<T>(string key) where T : SysmConfigQueryVieModel
    {
        var configs = await this.GetConfis<T>();
        return configs.Where(c => c.Key == key).FirstOrDefault();
    }
 
}