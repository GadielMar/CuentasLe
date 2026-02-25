//using BC.Shared.HandlerJsonSerialized;

namespace BCCuentas.Application.DTOs.Requests;
public class ObtenerCuentaCommand
{
    public string num_cliente { get; set; } = string.Empty;
    public string num_tarjeta { get; set; } = string.Empty;
    public string rfc { get; set; } = string.Empty;
    //[JsonConverter(typeof(LiteralStringConverter))]
    public string nombre { get; set; } = string.Empty;
}
