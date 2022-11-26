using System;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Eum.Api.Swagger
{
    public class ConfigureSwaggerOptions
        : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(
            IApiVersionDescriptionProvider provider)
        {
            this._provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            // add swagger document for every API version discovered
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(
                    description.GroupName,
                    CreateVersionInfo(description));
            }
        }

        public void Configure(string name, SwaggerGenOptions options)
        {
            Configure(options);

            //Remove version parameter
            options.OperationFilter<RemoveVersionParamterFilter>();

            //if controller not set version, will occur error
            //because trigger one more actions, force select one
            options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
        }

        private OpenApiInfo CreateVersionInfo(
                ApiVersionDescription description)
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
    }

    public class RemoveVersionParamterFilter : IOperationFilter
    {

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var hasVersionProperty = false;

            hasVersionProperty = operation.Parameters.Any(p => p.Name.Equals("api-version"));

            if (hasVersionProperty)
            {
                var versionParameter = operation.Parameters.Single(p => p.Name == "api-version");
                operation.Parameters.Remove(versionParameter);

            }
             

             
        }
    }
}
