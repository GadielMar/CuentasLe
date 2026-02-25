using System.ComponentModel.DataAnnotations;

namespace BCCuentas.Application.DTOs.Requests;
public class ObtenerSaldosPromediosCommand
{
    /// <summary>
    /// Cuenta del cliente.
    /// </summary>
    /// <example>00001</example>
    [Required]
    public string cuenta { get; set; }
}
