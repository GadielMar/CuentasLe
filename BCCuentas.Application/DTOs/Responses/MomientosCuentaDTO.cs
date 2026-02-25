namespace BCCuentas.Application.DTOs.Responses;
public class MovimientosCuentaDTO
{
    public DateTime fecha_alt { get; set; }
    public string transacc_descripcion { get; set; } = "";
    public string referencia { get; set; } = "";
    public decimal cargo { get; set; }
    public decimal abono { get; set; }
    public decimal saldo { get; set; }
    public string usuario { get; set; } = "";
    public DateTime hora { get; set; }
    public string instrucciones_especiales { get; set; } = "";
    public string code { get; set; } = "";
    public string msj { get; set; } = "";
}
