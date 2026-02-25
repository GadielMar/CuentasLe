using BC.Shared.HandlerException;
using Dapper;
using System.Data;

namespace BC.Shared.Conexion;
public abstract class RepositoryBase
{
    private readonly IDbConnectionFactory _connectionFactory;

    protected RepositoryBase(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    protected async Task<IEnumerable<T>> EjecutarProcedimientoAsync<T>(
            string spName,
            string databaseName,
            DynamicParameters parameters = null,
            int? timeout = 60
            )
    {
        using var connection = await _connectionFactory.CreateConnectionAsync(databaseName);

        try
        {
            var result = await connection.QueryAsync<T>(
            spName,
            parameters,
            commandType: CommandType.StoredProcedure
        );

            return result.ToList();
        }
        catch (Exception ex) when (ex is not TimeoutException && ex is not BaseDeDatosConexionException)
        {
            throw new BaseDeDatosEjecucionException(spName, ex);
        }
    }

    protected async Task<IEnumerable<T>> EjecutarProcedimientoAsync<T>(
        string spName,
        string databaseName,
        object parameters = null,
        int? timeout = 60)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync(databaseName);

        try
        {
            return await connection.QueryAsync<T>(
                spName,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
        catch (Exception ex) when (ex is not TimeoutException && ex is not BaseDeDatosConexionException)
        {
            throw new BaseDeDatosEjecucionException(spName, ex);
        }
    }
}
