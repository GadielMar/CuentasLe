using BCCuentas.Application.DTOs.Requests;
using BCCuentas.Application.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCCuentas.Application.Contracts;
public interface ICuentasService
{
    Task<IEnumerable<PromedioCuentaDTO>> ObtenerSaldosPromediosCuentaSERV(ObtenerSaldosPromediosCommand command);
    Task<IEnumerable<DetalleCuentaDTO>> ObtenerDetalleCuentaSERV(ObtenerDetalleCuentaCommand command);
    Task<IEnumerable<MovimientosCuentaDTO>> ObtenerMovimientosCuentaSERV(ObtenerMovimientosCommand command);
    Task<IEnumerable<DocumentoCuentaDTO>> ObtenerDocumentosCuentaSERV(ObtenerDocumentosCommand command);
    Task<IEnumerable<CuentaDTO>> ObtenerCuentaSERV(ObtenerCuentaCommand command);
    Task<IEnumerable<TarjetasCuentaDTO>> ObtenerTarjetasCuentaSERV(ObtenerTarjetasCommand command);
    Task<IEnumerable<ApartadosCuentaDTO>> ObtenerApartadosSERV(ObtenerApartadosCommand command);
    Task<IEnumerable<DetalleApartadoCuentaDTO>> ObtenerDetalleApartadoSERV(ObtenerDetalleApartadoCommand command);
    Task<IEnumerable<DetalleCertificadoCuentaDTO>> ObtenerDetalleCertificadoSERV(ObtenerDetalleCertificadoCommand command);
}
