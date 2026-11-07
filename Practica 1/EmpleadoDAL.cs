using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class EmpleadoDAL
    {
        // agrega un empleado
        public bool Insertar(string cedula, string nombre, string cargo,
                             decimal salario, DateTime fechaContratacion, int idDepartamento)
        {
            string sql = "INSERT INTO Empleado (Cedula, NombreEmpleado, Cargo, Salario, FechaContratacion, IdDepartamento) " +
                         "VALUES (@Cedula, @Nombre, @Cargo, @Salario, @Fecha, @IdDepartamento)";

            SqlConnection con = ConexionDB.ObtenerConexion();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Cedula", cedula);
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@Cargo", cargo);
            cmd.Parameters.AddWithValue("@Salario", salario);
            cmd.Parameters.AddWithValue("@Fecha", fechaContratacion);
            cmd.Parameters.AddWithValue("@IdDepartamento", idDepartamento);

            int filas = cmd.ExecuteNonQuery();
            con.Close();

            return filas > 0;
        }

        // trae todos los empleados
        public DataTable ObtenerTodos()
        {
            DataTable tabla = new DataTable();

            string sql = "SELECT IdEmpleado, Cedula, NombreEmpleado, Cargo, Salario, FechaContratacion, IdDepartamento FROM Empleado";

            SqlConnection con = ConexionDB.ObtenerConexion();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            adaptador.Fill(tabla);
            con.Close();

            return tabla;
        }

        // busca por nombre o por cédula
        public DataTable Buscar(string texto)
        {
            DataTable tabla = new DataTable();

            string sql = "SELECT IdEmpleado, Cedula, NombreEmpleado, Cargo, Salario, FechaContratacion, IdDepartamento " +
                         "FROM Empleado WHERE NombreEmpleado LIKE @Texto OR Cedula LIKE @Texto";

            SqlConnection con = ConexionDB.ObtenerConexion();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Texto", "%" + texto + "%");
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            adaptador.Fill(tabla);
            con.Close();

            return tabla;
        }

        // filtra por departamento
        public DataTable FiltrarPorDepartamento(int idDepartamento)
        {
            DataTable tabla = new DataTable();

            string sql = "SELECT IdEmpleado, Cedula, NombreEmpleado, Cargo, Salario, FechaContratacion, IdDepartamento " +
                         "FROM Empleado WHERE IdDepartamento = @IdDepartamento";

            SqlConnection con = ConexionDB.ObtenerConexion();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@IdDepartamento", idDepartamento);
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            adaptador.Fill(tabla);
            con.Close();

            return tabla;
        }

        // modifica un empleado
        public bool Actualizar(int idEmpleado, string cedula, string nombre, string cargo,
                               decimal salario, DateTime fechaContratacion, int idDepartamento)
        {
            string sql = "UPDATE Empleado SET Cedula=@Cedula, NombreEmpleado=@Nombre, Cargo=@Cargo, " +
                         "Salario=@Salario, FechaContratacion=@Fecha, IdDepartamento=@IdDepartamento " +
                         "WHERE IdEmpleado=@Id";

            SqlConnection con = ConexionDB.ObtenerConexion();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Cedula", cedula);
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@Cargo", cargo);
            cmd.Parameters.AddWithValue("@Salario", salario);
            cmd.Parameters.AddWithValue("@Fecha", fechaContratacion);
            cmd.Parameters.AddWithValue("@IdDepartamento", idDepartamento);
            cmd.Parameters.AddWithValue("@Id", idEmpleado);

            int filas = cmd.ExecuteNonQuery();
            con.Close();

            return filas > 0;
        }

        // elimina un empleado
        public bool Eliminar(int idEmpleado)
        {
            SqlConnection con = ConexionDB.ObtenerConexion();
            SqlCommand cmd = new SqlCommand("DELETE FROM Empleado WHERE IdEmpleado=@Id", con);
            cmd.Parameters.AddWithValue("@Id", idEmpleado);

            int filas = cmd.ExecuteNonQuery();
            con.Close();

            return filas > 0;
        }

        // Cuenta cuántos empleados ya tienen esa cédula (para no repetirla)
        public int ContarCedula(string cedula, int idExcluir)
        {
            SqlConnection con = ConexionDB.ObtenerConexion();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Empleado WHERE Cedula=@Cedula AND IdEmpleado<>@Id", con);
            cmd.Parameters.AddWithValue("@Cedula", cedula);
            cmd.Parameters.AddWithValue("@Id", idExcluir);

            int cantidad = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            return cantidad;
        }
    }
}