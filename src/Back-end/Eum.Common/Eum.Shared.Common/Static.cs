
namespace Eum.Shared.Common;

public static class Static
{
    public static IServiceProvider ServiceProvider { get; set; }
    public static IConfiguration Configuration { get; set; }

    public static T Resolve<T>()
    {
        return ServiceProvider.Resolve<T>();
    }
}

public static class ServiceExtensions
{
    public static T Resolve<T>(this IServiceProvider serviceProvider)
    {
        try
        {
            var service = serviceProvider.GetService(typeof(T));
            if (service != null)
            {
                return (T)service;
            }
            else
            {
                throw new TypeAccessException($"{typeof(T).FullName}");
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Resolve Fail: {typeof(T).FullName}");
            return default(T);
        }
    }
}

