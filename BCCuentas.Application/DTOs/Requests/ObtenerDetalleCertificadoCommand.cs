using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCCuentas.Application.DTOs.Requests;
public class ObtenerDetalleCertificadoCommand
{
    public string empresa { get; set; }
    public string cuenta { get; set; }
}
