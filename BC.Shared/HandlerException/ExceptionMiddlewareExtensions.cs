using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BC.Shared.HandlerException;
public static class ExceptionMiddlewareExtensions
{
    // 1. Para agregar los servicios (en builder.Services)
    public static IServiceCollection AddSharedExceptionHandler(this IServiceCollection services)
    {
        services.AddProblemDetails();
        services.AddExceptionHandler<GlobalExceptionHandler>();
        return services;
    }

    // 2. Para usar el middleware (en app)
    public static IApplicationBuilder UseSharedExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(); // Usa la configuración por defecto que inyectamos arriba
        return app;
    }
}
