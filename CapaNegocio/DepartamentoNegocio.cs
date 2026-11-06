using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class DepartamentoNegocio
    {
        private readonly DepartamentoDAL dal = new DepartamentoDAL();

        // Lista para llenar los ComboBox del formulario
        public DataTable ObtenerTodos()
        {
            return dal.ObtenerTodos();
        }

        // Regla: el nombre del departamento es obligatorio
        public string Insertar(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return "El nombre del departamento es obligatorio.";

            bool ok = dal.Insertar(nombre.Trim());
            return ok ? "Departamento guardado correctamente." : "No se pudo guardar el departamento.";
        }

        // Regla: el nombre es obligatorio
        public string Actualizar(int idDepartamento, string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return "El nombre del departamento es obligatorio.";

            bool ok = dal.Actualizar(idDepartamento, nombre.Trim());
            return ok ? "Departamento modificado correctamente." : "No se pudo modificar el departamento.";
        }

        public string Eliminar(int idDepartamento)
        {
            bool ok = dal.Eliminar(idDepartamento);
            return ok ? "Departamento eliminado correctamente." : "No se pudo eliminar el departamento.";
        }

        // Reporte: total de salarios por departamento
        public DataTable TotalSalariosPorDepartamento()
        {
            return dal.TotalSalariosPorDepartamento();
        }
    }
}