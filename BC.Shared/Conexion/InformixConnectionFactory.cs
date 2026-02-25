using BC.Shared.HandlerException;
using Dapper;
using Informix.Net.Core;
using Microsoft.Extensions.Configuration;
using System.Data;
using BC.Shared.HandlerTrim;

namespace BC.Shared.Conexion;
public class InformixConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;
    static InformixConnectionFactory()
    {
        SqlMapper.AddTypeHandler(new TrimHandler());
    }
    public InformixConnectionFactory(IConfiguration configuration)
    {
        _connectionString = configuration["OLTP"]
            ?? throw new ArgumentNullException("OLTP", "Cadena de conexión no encontrada.");
    }

    public Task<IDbConnection> CreateConnectionAsync(string databaseName)
    {
        var connection = new IfxConnection(_connectionString);
        try
        {
            connection.DatabaseLocale = "en_US.819";
            connection.ClientLocale = "en_US.CP1252";
            connection.Open();
            connection.ChangeDatabase(databaseName);

            return Task.FromResult<IDbConnection>(connection);
        }
        catch (Exception ex)
        {
            connection.Dispose();
            throw new BaseDeDatosConexionException(ex);
        }

    }
}