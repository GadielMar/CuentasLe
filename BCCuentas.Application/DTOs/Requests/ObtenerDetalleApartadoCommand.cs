namespace BCCuentas.Application.DTOs.Requests;
public class ObtenerDetalleApartadoCommand
{
    public string empresa {  get; set; }
    public string cuenta { get; set; }
    public string apartadoID { get; set; }
    public int periodo { get; set; }
}
