using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class ConexionDB
    {
        // Cadena de conexión centralizada: evita hardcodearla en cada formulario
        private static readonly string _cadena =
           @"Server=(.);Database=Nomina_de_empleados;" +
            "Trusted_Connection=True;TrustServerCertificate=True;";

        // Retorna una conexión abierta lista para usar en cualquier DAL
        public static SqlConnection ObtenerConexion()
        {
            var conexion = new SqlConnection(_cadena);
            conexion.Open();
            return conexion;
        }
    }
}