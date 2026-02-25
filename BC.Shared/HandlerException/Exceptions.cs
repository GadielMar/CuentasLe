using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Shared.HandlerException;
public class InfraestructuraException : Exception
{
    public InfraestructuraException(string mensaje, Exception inner) : base(mensaje, inner) { }
}

public class BaseDeDatosConexionException : InfraestructuraException
{
    public BaseDeDatosConexionException(Exception ex)
        : base("Servicio de datos no disponible temporalmente.", ex) { }
}

public class BaseDeDatosEjecucionException : InfraestructuraException
{
    public BaseDeDatosEjecucionException(string spName, Exception exOriginal)
        : base($"Error al ejecutar el procedimiento: {spName}", exOriginal)
    {
    }
}

// 1. Para cuando los datos de entrada están mal (Ej: Fecha vacía)
public class ValidacionException : Exception
{
    // Puedes recibir una lista de errores si quieres ser más pro
    public ValidacionException(string mensaje) : base(mensaje) { }
}

// 2. Para reglas de negocio (Ej: "La sucursal está en mantenimiento")
public class NegocioException : Exception
{
    public NegocioException(string mensaje) : base(mensaje) { }
}

// 3. Para cuando no existe lo que buscan
public class RecursoNoEncontradoException : Exception
{
    public RecursoNoEncontradoException(string recurso, object id)
        : base($"No se encontró el recurso '{recurso}' con identificador '{id}'.") { }
}
