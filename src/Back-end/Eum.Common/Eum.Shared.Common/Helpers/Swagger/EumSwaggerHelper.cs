

namespace Eum.Shared.Common.Swagger
{
    public class EumSwaggerHelper
    {
        public static IApiVersionDescriptionProvider provider { get; set; } 
        private static OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = $"Eum Api v{description.ApiVersion.ToString()}",
                Version = description.ApiVersion.ToString()
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }

        public static void ConfigureSwaggerGen(SwaggerGenOptions options)
        {
            //var provi
            //문서설정
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName,CreateVersionInfo(description));
            }

            //버전 파라메터 삭제
            options.OperationFilter<RemoveVersionParamterFilter>();
            options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
        }

        public static void ConfigureSwagger(SwaggerOptions options )
        {

        }

        public static void ConfigureSwaggerUI(SwaggerUIOptions options)
        {
            //var provider = getProvider();
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"Eum Api {description.GroupName}");
            }
        }
    }
}
