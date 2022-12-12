namespace Eum.Shared.Common.Infrastructures.SystemConfigs;

//시스템 Config 읽기 전용
// Config 의 추가 수정은 database 에서 직접 수행, 조회기능만 제공됨
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
SELECT * FROM [T_EC_SYSTEM_CONFIG]
";
        return await connection.QueryAsync<T>(query);
    }

    public async Task<IEnumerable<T>> FindByCategory<T>(SystemCategory category) where T : SysmConfigQueryVieModel
    {
        var configs = await this.GetConfis<T>();
        return configs.Where(c => c.Category == (int) category);
    }

    public async Task<T> FindByKey<T>(string key) where T : SysmConfigQueryVieModel
    {
        var configs = await this.GetConfis<T>();
        return configs.Where(c => c.Key == key).FirstOrDefault();
    }
 
}