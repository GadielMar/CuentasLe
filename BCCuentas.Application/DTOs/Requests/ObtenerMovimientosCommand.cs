namespace BCCuentas.Application.DTOs.Requests;
public  class ObtenerMovimientosCommand
{
    public string cuenta { get; set; } = string.Empty;
    public DateTime? fechaInicio { get; set; }
    public DateTime? fechaFin { get; set; }
    public decimal? saldoDisponible { get; set; }
}
