namespace BCCuentas.Application.DTOs.Responses;
public class DocumentoCuentaDTO
{
    public DateTime fecha_alta { get; set; }
    public string sucursal { get; set; }
    public decimal monto { get; set; }
    public string cancelado { get; set; }
    public string code { get; set; }
    public string mensaje { get; set; }
}
