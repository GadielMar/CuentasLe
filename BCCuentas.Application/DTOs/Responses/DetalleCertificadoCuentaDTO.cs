namespace BCCuentas.Application.DTOs.Responses;
public class DetalleCertificadoCuentaDTO
{
    public string codret { get; set; }
    public string mensaje { get; set; }
    public string fecha_certifica { get; set; }
    public string cuenta { get; set; }
    public int cheque { get; set; }
    public decimal importe { get; set; }
    public string sucursal { get; set; }
    public string estatus { get; set; }
    public string usuario { get; set; }
}
