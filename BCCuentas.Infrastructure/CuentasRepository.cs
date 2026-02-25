using BC.Shared.Conexion;
using BCCuentas.Application.Contracts;
using BCCuentas.Application.DTOs.Responses;

namespace BCCuentas.Infrastructure;
public class CuentasRepository : RepositoryBase, ICuentasRepository
{
    public CuentasRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory) { }

    public async Task<IEnumerable<PromedioCuentaDTO>> ObtenerPromediosREPO(string cuenta)
    {
        return await EjecutarProcedimientoAsync<PromedioCuentaDTO>(
            "sp_se_ultimos_saldos_promedios",
            "bdicheq",
            new { pchcuenta = cuenta }
            );
    }

    public async Task<IEnumerable<DetalleCuentaDTO>> ObtenerDetalleREPO(string cuenta, DateTime? fechaInicio, DateTime? fechaFin)
    {
        return await EjecutarProcedimientoAsync<DetalleCuentaDTO>(
            "sp_se_detalle_cuenta",
            "bdicheq",
            new { pchcuenta = cuenta, pfechaInicio = fechaInicio, pfechaFinal = fechaFin }
            );
    }

    public async Task<IEnumerable<MovimientosCuentaDTO>> ObtenerMovimientosREPO(string cuenta, DateTime? fechaInicio, DateTime? fechaFin, decimal? saldo)
    {
        return await EjecutarProcedimientoAsync<MovimientosCuentaDTO>(
            "sp_se_movimientos_cuenta",
            "bdicheq",
            new { pchcuenta = cuenta, pfechaInicio = fechaInicio, pfechaFinal = fechaFin, pSaldoDisponible = saldo}
            );
    }

    public async Task<IEnumerable<DocumentoCuentaDTO>> ObtenerDocumentoREPO(string cuenta)
    {
        return await EjecutarProcedimientoAsync<DocumentoCuentaDTO>(
            "sp_se_detalle_documentos_cuenta",
            "bdicheq",
            new { pchcuenta = cuenta }
            );
    }

    public async Task<IEnumerable<CuentaDTO>> ObtenerCuentaREPO(string numCliente, string numTarjeta, string rfc, string nombre)
    {
        return await EjecutarProcedimientoAsync<CuentaDTO>(
            "bsc_sp_consula_cuenta",
            "bdicheq",
            new { pnumcte = numCliente, pnum_tarjeta = numTarjeta, prfc = rfc, pnombre = nombre }
            );
    }

    public async Task<IEnumerable<TarjetasCuentaDTO>> ObtenerTarjetasREPO(string cuenta)
    {
        return await EjecutarProcedimientoAsync<TarjetasCuentaDTO>(
            "sp_se_tarjetas_por_cuenta",
            "bditarjeta",
            new { pchcuenta = cuenta }
            );
    }

    public async Task<IEnumerable<ApartadosCuentaDTO>> ObtenerApartadosREPO(string empresa, string cuenta)
    {
        return await EjecutarProcedimientoAsync<ApartadosCuentaDTO>(
            "sp_core_consulta_apartados",
            "bdicheq",
            new { pempresa = empresa, pCuenta = cuenta }
            );
    }

    public async Task<IEnumerable<DetalleApartadoCuentaDTO>> ObtenerDetalleApartadoREPO(string empresa, string cuenta, string apartadoID, int periodo)
    {
        return await EjecutarProcedimientoAsync<DetalleApartadoCuentaDTO>(
            "sp_core_consulta_detalle_apartados",
            "bdicheq",
            new { pempresa = empresa, pCuenta = cuenta, pIdApartado = apartadoID, pPeriodo = periodo }
            );
    }

    public async Task<IEnumerable<DetalleCertificadoCuentaDTO>> ObtenerDetalleCertificadoREPO(string empresa, string cuenta)
    {
        return await EjecutarProcedimientoAsync<DetalleCertificadoCuentaDTO>(
            "sp_core_detalle_certificado",
            "bdicntchq",
            new { pempresa = empresa, pCuenta = cuenta }
            );
    }

}
