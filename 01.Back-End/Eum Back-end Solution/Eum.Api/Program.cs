using Eum.Shared.Common.Extentions;
using Eum.Shared.Common.Helpers.MVC;
using Eum.Shared.Common.Swagger;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);

#region [Builder Service Containers]
builder.Services.AddSharedInfrastructure(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning(EumMVCHelper.ConfigureApiVersoning);
builder.Services.AddVersionedApiExplorer(EumMVCHelper.ConfigureApiExplorer);
builder.Services.AddSwaggerGen(EumSwaggerHelper.ConfigureSwaggerGen);
builder.EumDIContainerBuilder();
#endregion

var app = builder.Build();
EumSwaggerHelper.provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(EumSwaggerHelper.ConfigureSwagger);
    app.UseSwaggerUI(EumSwaggerHelper.ConfigureSwaggerUI);
}

app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.Run();
