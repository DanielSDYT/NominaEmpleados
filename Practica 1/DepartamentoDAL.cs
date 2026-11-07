using Microsoft.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DepartamentoDAL
    {
        // Trae todos los departamentos
        public DataTable ObtenerTodos()
        {
            DataTable tabla = new DataTable();

            SqlConnection con = ConexionDB.ObtenerConexion();
            SqlCommand cmd = new SqlCommand("SELECT IdDepartamento, NombreDepartamento FROM Departamento", con);
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            adaptador.Fill(tabla);
            con.Close();

            return tabla;
        }

        // Agrega un departamento
        public bool Insertar(string nombre)
        {
            SqlConnection con = ConexionDB.ObtenerConexion();
            SqlCommand cmd = new SqlCommand("INSERT INTO Departamento (NombreDepartamento) VALUES (@Nombre)", con);
            cmd.Parameters.AddWithValue("@Nombre", nombre);

            int filas = cmd.ExecuteNonQuery();
            con.Close();

            return filas > 0;
        }

        // Modifica un departamento
        public bool Actualizar(int idDepartamento, string nombre)
        {
            SqlConnection con = ConexionDB.ObtenerConexion();
            SqlCommand cmd = new SqlCommand("UPDATE Departamento SET NombreDepartamento=@Nombre WHERE IdDepartamento=@Id", con);
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@Id", idDepartamento);

            int filas = cmd.ExecuteNonQuery();
            con.Close();

            return filas > 0;
        }

        // Elimina un departamento
        public bool Eliminar(int idDepartamento)
        {
            SqlConnection con = ConexionDB.ObtenerConexion();
            SqlCommand cmd = new SqlCommand("DELETE FROM Departamento WHERE IdDepartamento=@Id", con);
            cmd.Parameters.AddWithValue("@Id", idDepartamento);

            int filas = cmd.ExecuteNonQuery();
            con.Close();

            return filas > 0;
        }

        // Reporte: total de salarios por departamento
        public DataTable TotalSalariosPorDepartamento()
        {
            DataTable tabla = new DataTable();

            string sql = "SELECT d.NombreDepartamento AS Departamento, " +
                         "ISNULL(SUM(e.Salario), 0) AS TotalSalarios " +
                         "FROM Departamento d " +
                         "LEFT JOIN Empleado e ON e.IdDepartamento = d.IdDepartamento " +
                         "GROUP BY d.NombreDepartamento";

            SqlConnection con = ConexionDB.ObtenerConexion();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            adaptador.Fill(tabla);
            con.Close();

            return tabla;
        }
    }
}