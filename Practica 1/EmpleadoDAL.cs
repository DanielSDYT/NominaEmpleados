using System.Data;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class EmpleadoDAL
    {
        // TODO Crear
        public bool Insertar(string cedula, string nombre, string cargo,
                             decimal salario, DateTime fechaContratacion, int idDepartamento)
        {
            using (var con = ConexionDB.ObtenerConexion())
            using (var cmd = new SqlCommand(@"
                INSERT INTO Empleado (Cedula, NombreEmpleado, Cargo, Salario, FechaContratacion, IdDepartamento)
                VALUES (@Cedula, @Nombre, @Cargo, @Salario, @Fecha, @IdDepartamento)", con))
            {
                cmd.Parameters.AddWithValue("@Cedula", cedula);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Cargo", cargo);
                cmd.Parameters.AddWithValue("@Salario", salario);
                cmd.Parameters.AddWithValue("@Fecha", fechaContratacion);
                cmd.Parameters.AddWithValue("@IdDepartamento", idDepartamento);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // TODO Listar
        public DataTable ObtenerTodos()
        {
            return Llenar("SELECT IdEmpleado, Cedula, NombreEmpleado, Cargo, Salario, FechaContratacion, IdDepartamento FROM Empleado");
        }

        // TODO Buscar
        public DataTable Buscar(string texto)
        {
            var dt = new DataTable();
            using (var con = ConexionDB.ObtenerConexion())
            using (var cmd = new SqlCommand(@"
                SELECT IdEmpleado, Cedula, NombreEmpleado, Cargo, Salario, FechaContratacion, IdDepartamento
                FROM Empleado
                WHERE NombreEmpleado LIKE @Texto OR Cedula LIKE @Texto", con))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@Texto", "%" + texto + "%");
                adapter.Fill(dt);
            }
            return dt;
        }

        // TODO Filtrar
        public DataTable FiltrarPorDepartamento(int idDepartamento)
        {
            var dt = new DataTable();
            using (var con = ConexionDB.ObtenerConexion())
            using (var cmd = new SqlCommand(@"
                SELECT IdEmpleado, Cedula, NombreEmpleado, Cargo, Salario, FechaContratacion, IdDepartamento
                FROM Empleado
                WHERE IdDepartamento = @IdDepartamento", con))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@IdDepartamento", idDepartamento);
                adapter.Fill(dt);
            }
            return dt;
        }

        // TODO Modificar
        public bool Actualizar(int idEmpleado, string cedula, string nombre, string cargo,
                               decimal salario, DateTime fechaContratacion, int idDepartamento)
        {
            using (var con = ConexionDB.ObtenerConexion())
            using (var cmd = new SqlCommand(@"
                UPDATE Empleado
                SET Cedula=@Cedula, NombreEmpleado=@Nombre, Cargo=@Cargo,
                    Salario=@Salario, FechaContratacion=@Fecha, IdDepartamento=@IdDepartamento
                WHERE IdEmpleado=@Id", con))
            {
                cmd.Parameters.AddWithValue("@Cedula", cedula);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Cargo", cargo);
                cmd.Parameters.AddWithValue("@Salario", salario);
                cmd.Parameters.AddWithValue("@Fecha", fechaContratacion);
                cmd.Parameters.AddWithValue("@IdDepartamento", idDepartamento);
                cmd.Parameters.AddWithValue("@Id", idEmpleado);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // TODO Eliminar1
        public bool Eliminar(int idEmpleado)
        {
            using (var con = ConexionDB.ObtenerConexion())
            using (var cmd = new SqlCommand("DELETE FROM Empleado WHERE IdEmpleado=@Id", con))
            {
                cmd.Parameters.AddWithValue("@Id", idEmpleado);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // TODO Cuenta cédulas repetidas (esto solo consulta)
        public int ContarCedula(string cedula, int idExcluir)
        {
            using (var con = ConexionDB.ObtenerConexion())
            using (var cmd = new SqlCommand(
                "SELECT COUNT(*) FROM Empleado WHERE Cedula=@Cedula AND IdEmpleado<>@Id", con))
            {
                cmd.Parameters.AddWithValue("@Cedula", cedula);
                cmd.Parameters.AddWithValue("@Id", idExcluir);
                return (int)cmd.ExecuteScalar();   // valor simple
            }
        }

        // ── Helper privado para no repetir el SELECT + Fill
        private DataTable Llenar(string sql)
        {
            var dt = new DataTable();
            using (var con = ConexionDB.ObtenerConexion())
            using (var cmd = new SqlCommand(sql, con))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}