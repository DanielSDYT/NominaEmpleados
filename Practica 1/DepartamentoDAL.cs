using Microsoft.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DepartamentoDAL
    {
        public DataTable ObtenerTodos()
        {
            var dt = new DataTable();
            using (var con = ConexionDB.ObtenerConexion())
            using (var cmd = new SqlCommand("SELECT IdDepartamento, NombreDepartamento FROM Departamento", con))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            return dt;
        }

        public bool Insertar(string nombre)
        {
            using (var con = ConexionDB.ObtenerConexion())
            using (var cmd = new SqlCommand("INSERT INTO Departamento (NombreDepartamento) VALUES (@Nombre)", con))
            {
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Actualizar(int idDepartamento, string nombre)
        {
            using (var con = ConexionDB.ObtenerConexion())
            using (var cmd = new SqlCommand("UPDATE Departamento SET NombreDepartamento=@Nombre WHERE IdDepartamento=@Id", con))
            {
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Id", idDepartamento);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int idDepartamento)
        {
            using (var con = ConexionDB.ObtenerConexion())
            using (var cmd = new SqlCommand("DELETE FROM Departamento WHERE IdDepartamento=@Id", con))
            {
                cmd.Parameters.AddWithValue("@Id", idDepartamento);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // TODO Reporte
        public DataTable TotalSalariosPorDepartamento()
        {
            var dt = new DataTable();
            using (var con = ConexionDB.ObtenerConexion())
            using (var cmd = new SqlCommand(@"
                SELECT d.NombreDepartamento AS Departamento,
                       ISNULL(SUM(e.Salario), 0) AS TotalSalarios
                FROM Departamento d
                LEFT JOIN Empleado e ON e.IdDepartamento = d.IdDepartamento
                GROUP BY d.NombreDepartamento", con))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}