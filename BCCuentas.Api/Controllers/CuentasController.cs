using Asp.Versioning;
using BCCuentas.Application.Contracts;
using BCCuentas.Application.DTOs.Requests;
using BCCuentas.Application.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BCCuentas.Api.Controllers;
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class CuentasController : ControllerBase
{
    private readonly ICuentasService _service;
    public CuentasController(ICuentasService service) {  _service = service; }

    /// <summary>
    /// Obtiene el saldo promedio histórico de una cuenta específica.
    /// </summary>
    /// <remarks>
    /// Este endpoint consulta la base de datos de Informix para calcular el promedio.
    /// </remarks>
    ///  /// <response code="200">Retorna la colección de sucursales encontrada.</response>
    /// <response code="400">Si los parámetros de entrada son inválidos o nulos.</response>
    /// <response code="500">Error interno al conectar con la base de datos o fallo en el SP.</response>
    [HttpPost("obtener-cuenta-promedio")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(typeof(IEnumerable<PromedioCuentaDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ObtenerSaldosPromedioCuenta([FromBody] ObtenerSaldosPromediosCommand cuenta)
    {
        var resultado = await _service.ObtenerSaldosPromediosCuentaSERV(cuenta);
        return Ok(resultado);
    }

    [HttpPost("obtener-cuenta-promedio")]
    [MapToApiVersion("2.0")]
    public IActionResult ObtenerEjemplo()
    {
        return Ok("Respuesta de la versión 2");
    }

    [HttpPost("obtener-cuenta")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> ObtenerCuenta([FromBody] ObtenerCuentaCommand command)
    {
        var resultado = await _service.ObtenerCuentaSERV(command);
        return Ok(resultado);
    }

    [HttpPost("obtener-cuenta-detalle")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> ObtenerDetalleCuenta([FromBody] ObtenerDetalleCuentaCommand command)
    {
        var resultado = await _service.ObtenerDetalleCuentaSERV(command);
        return Ok(resultado);
    }

    [HttpPost("obtener-cuenta-documento")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> ObtenerDocumentoCuenta([FromBody] ObtenerDocumentosCommand cuenta)
    {
        var resultado = await _service.ObtenerDocumentosCuentaSERV(cuenta);
        return Ok(resultado);
    }

    [HttpPost("obtener-cuenta-movimientos")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> ObtenerMovimientosCuenta([FromBody] ObtenerMovimientosCommand command)
    {
        var resultado = await _service.ObtenerMovimientosCuentaSERV(command);
        return Ok(resultado);
    }

    [HttpPost("obtener-cuenta-tarjetas")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> ObtenerTarjetasCuenta([FromBody] ObtenerTarjetasCommand command)
    {
        var resultado = await _service.ObtenerTarjetasCuentaSERV(command);
        return Ok(resultado);
    }

    [HttpPost("obtener-cuenta-apartados")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> ObtenerApartados([FromBody] ObtenerApartadosCommand command)
    {
        var resultado = await _service.ObtenerApartadosSERV(command);
        return Ok(resultado);
    }

    [HttpPost("obtener-cuenta-apartado-detalle")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> ObtenerDetalleApartado([FromBody] ObtenerDetalleApartadoCommand command)
    {
        var resultado = await _service.ObtenerDetalleApartadoSERV(command);
        return Ok(resultado);
    }

    [HttpPost("obtener-cuenta-certificado-detalle")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> ObtenerDetalleCertificado([FromBody] ObtenerDetalleCertificadoCommand command)
    {
        var resultado = await _service.ObtenerDetalleCertificadoSERV(command);
        return Ok(resultado);
    }
}
