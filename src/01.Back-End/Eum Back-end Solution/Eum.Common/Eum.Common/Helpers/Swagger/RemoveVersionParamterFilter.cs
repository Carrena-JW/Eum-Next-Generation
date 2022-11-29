using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Eum.Shared.Common.Swagger
{
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
