namespace Eum.Shared.Common.Infrastructures.SystemConfigs;

public interface ISystemConfigQueries
{
    Task<IEnumerable<T>> GetConfis<T>() where T : SysmConfigQueryVieModel;
    Task<IEnumerable<T>> FindByCategory<T>(string category) where T : SysmConfigQueryVieModel;
    Task<T> FindByKey<T>(string key) where T : SysmConfigQueryVieModel;
}