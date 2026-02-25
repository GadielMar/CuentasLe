using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BC.Shared.HandlerSwagger;
public static class SwaggerExtensions
{
    public static IServiceCollection AddSharedSwagger(this IServiceCollection services, params string[] xmlFileNames)
    {
        services.AddSwaggerGen(options =>
        {
            // 1. CONFIGURACIÓN DE SEGURIDAD (El candadito JWT)
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description = "Ingresa 'Bearer [tu_token_jwt]' aquí.",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                    },
                    Array.Empty<string>()
                }
            });

            // 2. LECTURA DE COMENTARIOS XML (Para documentar tus endpoints)
            foreach (var fileName in xmlFileNames)
            {
                var xmlPath = Path.Combine(AppContext.BaseDirectory, fileName);
                if (File.Exists(xmlPath))
                {
                    options.IncludeXmlComments(xmlPath);
                }
            }
            options.CustomSchemaIds(type => type.FullName);
        });

        return services;
    }

    // Método 2: Para app (Pipeline de la interfaz gráfica)
    public static WebApplication UseSharedSwaggerUI(this WebApplication app)
    {
        var apiTitle = app.Configuration["Swagger:Title"] ?? "API Service";

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.DocumentTitle = $"{apiTitle} - Swagger"; // Título de la pestaña del navegador

                // Lógica del menú desplegable de versiones que ya teníamos
                var descriptions = app.DescribeApiVersions();
                foreach (var description in descriptions)
                {
                    var url = $"./{description.GroupName}/swagger.json";
                    var name = $"{apiTitle} {description.GroupName.ToUpperInvariant()}";
                    options.SwaggerEndpoint(url, name);
                }
            });
        }
        return app;
    }
}
