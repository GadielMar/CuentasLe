using Dapper;
using System.Data;

namespace BC.Shared.HandlerTrim;
public class TrimHandler : SqlMapper.TypeHandler<string>
{
    public override void SetValue(IDbDataParameter parameter, string value)
    {
        parameter.Value = value?.Trim();
    }

    // Se ejecuta cuando Dapper RECIBE un string DESDE la base de datos
    public override string Parse(object value)
    {
        // Si el valor no es nulo, lo convierte a string y le quita los espacios
        return value?.ToString()?.Trim();
    }
}
