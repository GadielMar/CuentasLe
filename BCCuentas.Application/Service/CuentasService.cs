using BC.Shared.HandlerException;
using BCCuentas.Application.Contracts;
using BCCuentas.Application.DTOs.Requests;
using BCCuentas.Application.DTOs.Responses;

namespace BCCuentas.Application.Service;
public class CuentasService : ICuentasService
{
    private readonly ICuentasRepository _repository;

    public CuentasService(ICuentasRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PromedioCuentaDTO>> ObtenerSaldosPromediosCuentaSERV(ObtenerSaldosPromediosCommand command)
    {
        //// Validación 401
        //if (string.IsNullOrWhiteSpace(dto.ValorBusqueda))
        //    throw new BusinessException(ErroresConstancias.DatosRequeridosFaltantes); <---

        //return await _repository.ObtenerPromedioCuenta (command.pchcuenta);
        return await _repository.ObtenerPromediosREPO(command.cuenta);
    }

    public async Task<IEnumerable<DetalleCuentaDTO>> ObtenerDetalleCuentaSERV(ObtenerDetalleCuentaCommand command)
    {
        return await _repository.ObtenerDetalleREPO(command.cuenta, command.fechaInicio, command.fechaFin);
    }

    public async Task<IEnumerable<MovimientosCuentaDTO>> ObtenerMovimientosCuentaSERV(ObtenerMovimientosCommand command)
    {
        return await _repository.ObtenerMovimientosREPO(command.cuenta, command.fechaInicio, command.fechaFin, command.saldoDisponible);
    }

    public async Task<IEnumerable<CuentaDTO>> ObtenerCuentaSERV(ObtenerCuentaCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.num_cliente) &&
        string.IsNullOrWhiteSpace(command.num_tarjeta) &&
        string.IsNullOrWhiteSpace(command.rfc) &&
        string.IsNullOrWhiteSpace(command.nombre))
        {
            throw new ValidacionException("Debe proporcionar al menos un criterio de búsqueda (Cliente, Tarjeta, RFC o Nombre).");
        }
        return await _repository.ObtenerCuentaREPO(command.num_cliente, command.num_tarjeta, command.rfc, command.nombre);
    }

    public async Task<IEnumerable<DocumentoCuentaDTO>> ObtenerDocumentosCuentaSERV(ObtenerDocumentosCommand command)
    {
        return await _repository.ObtenerDocumentoREPO(command.cuenta);
    }

    public async Task<IEnumerable<TarjetasCuentaDTO>> ObtenerTarjetasCuentaSERV(ObtenerTarjetasCommand command)
    {
        return await _repository.ObtenerTarjetasREPO(command.cuenta);
    }

    public async Task<IEnumerable<ApartadosCuentaDTO>> ObtenerApartadosSERV(ObtenerApartadosCommand command)
    {
        return await _repository.ObtenerApartadosREPO(command.empresa, command.cuenta);
    }

    public async Task<IEnumerable<DetalleApartadoCuentaDTO>> ObtenerDetalleApartadoSERV(ObtenerDetalleApartadoCommand command)
    {
        return await _repository.ObtenerDetalleApartadoREPO(command.empresa, command.cuenta, command.apartadoID, command.periodo);
    }

    public async Task<IEnumerable<DetalleCertificadoCuentaDTO>> ObtenerDetalleCertificadoSERV(ObtenerDetalleCertificadoCommand command)
    {
        return await _repository.ObtenerDetalleCertificadoREPO(command.empresa, command.cuenta);
    }

}
