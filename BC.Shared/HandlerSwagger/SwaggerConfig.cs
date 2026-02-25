using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BCCuentas.Api.SwaggerHandler;

public class SwaggerConfig : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;
    private readonly IConfiguration _configuration;

    public SwaggerConfig(IApiVersionDescriptionProvider provider, IConfiguration configuration)
    {
        _provider = provider;
        _configuration = configuration;
    }

    public void Configure(SwaggerGenOptions options)
    {
        var apiTitle = _configuration["Swagger:Title"] ?? "API Service";
        // Recorre todas las versiones descubiertas (v1, v2...)
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            if (!options.SwaggerGeneratorOptions.SwaggerDocs.ContainsKey(description.GroupName))
            {
                options.SwaggerDoc(description.GroupName, new OpenApiInfo
                {
                    Title = apiTitle,
                    Version = description.ApiVersion.ToString(),
                    Description = description.IsDeprecated ? "Esta versión está obsoleta." : "Documentación activa."
                });
            }
        }
    }
}
