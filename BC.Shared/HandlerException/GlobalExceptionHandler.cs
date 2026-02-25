using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BC.Shared.HandlerException;
public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Error Global: {Message}", exception.Message);

        (int statusCode, string title) = exception switch
        {
            // TUS EXCEPCIONES DE SHARED
            ValidacionException => (StatusCodes.Status400BadRequest, "Datos de Entrada Inválidos"),
            NegocioException => (StatusCodes.Status422UnprocessableEntity, "Regla de Negocio No Cumplida"),
            RecursoNoEncontradoException => (StatusCodes.Status404NotFound, "Recurso No Encontrado"),
            BaseDeDatosConexionException => (StatusCodes.Status503ServiceUnavailable, "Servicio No Disponible"),

            BaseDeDatosEjecucionException => (StatusCodes.Status500InternalServerError, "Error Ejecutando Operación de Datos"),

            // EXCEPCIONES DE .NET
            ArgumentException => (StatusCodes.Status400BadRequest, "Error de Validación"),

            

            // DEFAULT
            _ => (StatusCodes.Status500InternalServerError, "Error Interno")
        };

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = exception.Message
        };

        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        return true;
    }
}
