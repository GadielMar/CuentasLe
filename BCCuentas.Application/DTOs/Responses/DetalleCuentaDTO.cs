namespace BCCuentas.Application.DTOs.Responses;
public class DetalleCuentaDTO
{
    public string? num_cliente { get; set; }
    public string? producto { get; set; }
    public int estatus_cuenta { get; set; }
    public string? estatus_cuenta_des { get; set; }
    public int envio_direcc { get; set; }
    public string? envio_direcc_des { get; set; }
    public int direcc_envio { get; set; }
    public string? fecha_alta { get; set; }
    public string? fecha_utlimo_mov { get; set; }
    public decimal saldo_congelado { get; set; }
    public decimal saldo_dis { get; set; }
    public decimal saldo_ret { get; set; }
    public decimal imp_cheq_sbc { get; set; }
    public decimal saldo_actual { get; set; }
    public decimal saldo_dia_ant { get; set; }
    public string? cuenta_cbe { get; set; }
    public string? sucursal { get; set; }
    public string? sucursal_nombre { get; set; }
    public string? num_cel { get; set; }
    public string? nombre_cliente { get; set; }
    public string? num_cte_ref { get; set; }
    public string? cuenta_des { get; set; }
    public decimal saldo_mes_ant_final { get; set; }
    public string? ejecutivo { get; set; }
    public string? email { get; set; }
    public string? divisa { get; set; }
    public decimal sdoApartado { get; set; }
    public string? FechaSistema { get; set; }
    public string? edc { get; set; }
    public string? oCodRet { get; set; }
    public string? oMsg { get; set; }
}
