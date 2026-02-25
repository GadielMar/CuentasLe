using BCCuentas.Application.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCCuentas.Application.Contracts;
public interface ICuentasRepository
{
    Task<IEnumerable<PromedioCuentaDTO>> ObtenerPromediosREPO(string cuenta);
    Task<IEnumerable<DetalleCuentaDTO>> ObtenerDetalleREPO(string cuenta, DateTime? fechaInicio, DateTime? fechaFin);
    Task<IEnumerable<MovimientosCuentaDTO>> ObtenerMovimientosREPO(string cuenta, DateTime? fechaInicio, DateTime? fechaFin, decimal? saldo);
    Task<IEnumerable<DocumentoCuentaDTO>> ObtenerDocumentoREPO(string cuenta);
    Task<IEnumerable<CuentaDTO>> ObtenerCuentaREPO(string numCliente, string numTarjeta, string rfc, string nombre);
    Task<IEnumerable<TarjetasCuentaDTO>> ObtenerTarjetasREPO(string cuenta);
    Task<IEnumerable<ApartadosCuentaDTO>> ObtenerApartadosREPO(string empresa, string cuenta);
    Task<IEnumerable<DetalleApartadoCuentaDTO>> ObtenerDetalleApartadoREPO(string empresa, string cuenta, string apartadoID, int periodo);
    Task<IEnumerable<DetalleCertificadoCuentaDTO>> ObtenerDetalleCertificadoREPO(string empresa, string cuenta);
}
