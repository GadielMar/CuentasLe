using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Shared.Conexion;
public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateConnectionAsync(string databaseName);
}
