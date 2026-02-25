namespace BCCuentas.Application.DTOs.Responses;
public class DetalleApartadoCuentaDTO
{
    public string codret { get; set; }
    public string mensaje { get; set; }
    public string cuenta { get; set; }
    public string idApartado { get; set; }
    public decimal monto_aparta { get; set; }
    public string concepto { get; set; }
    public DateTime fechaProceso { get; set; }
}
