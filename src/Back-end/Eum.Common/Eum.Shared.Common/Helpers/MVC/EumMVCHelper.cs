

namespace Eum.Shared.Common.Helpers.MVC
{
    public class EumMVCHelper
    {
        public static void ConfigureApiVersoning(ApiVersioningOptions options)
        {
            options.DefaultApiVersion = new ApiVersion(0, 0);
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
        }

        public static void ConfigureApiExplorer(ApiExplorerOptions options)
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        }
    }
}
