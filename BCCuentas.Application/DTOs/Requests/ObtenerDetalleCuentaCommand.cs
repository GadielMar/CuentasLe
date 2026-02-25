namespace BCCuentas.Application.DTOs.Requests;
public class ObtenerDetalleCuentaCommand
{
    public string cuenta { get; set; } = string.Empty;
    public DateTime? fechaInicio { get; set; }
    public DateTime? fechaFin { get; set; }
}
