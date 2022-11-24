using Eum.Api;
using Eum.Api.Swagger;
using Eum.Shared.Infrastructure.Extentions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);




#region [Builder Service Containers]
builder.Services.AddSharedInfrastructure(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
});
builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(descriptions =>
    {
        return descriptions.First();
    });

    c.SwaggerDoc(
           "v1.0",
           new OpenApiInfo
           {
               Title = "Eum API",
               Version = "v1.0"
           });
    c.SwaggerDoc(
        "v2.0",
        new OpenApiInfo
        {
            Title = "Eum API",
            Version = "v2.0"
        });
    c.OperationFilter<RemoveVersionParamterFilter>();
    c.DocumentFilter<ReplaceVersionFilter>();
}
    );

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Eum API v1.0");
        c.SwaggerEndpoint("/swagger/v2.0/swagger.json", "Eum API v2.0");
    });
}
else
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();
