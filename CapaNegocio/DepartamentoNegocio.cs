using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class DepartamentoNegocio
    {
        private readonly DepartamentoDAL dal = new DepartamentoDAL();

        // lista para llenar los ComboBox del formulario
        public DataTable ObtenerTodos()
        {
            return dal.ObtenerTodos();
        }

        // regla: el nombre del departamento es obligatorio
        public string Insertar(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return "El nombre del departamento es obligatorio.";

            bool ok = dal.Insertar(nombre.Trim());
            if (ok)
                return "Departamento guardado correctamente.";
            else
                return "No se pudo guardar el departamento.";
        }

        // regla: el nombre es obligatorio
        public string Actualizar(int idDepartamento, string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return "El nombre del departamento es obligatorio.";

            bool ok = dal.Actualizar(idDepartamento, nombre.Trim());
            if (ok)
                return "Departamento modificado correctamente.";
            else
                return "No se pudo modificar el departamento.";
        }

        public string Eliminar(int idDepartamento)
        {
            bool ok = dal.Eliminar(idDepartamento);
            if (ok)
                return "Departamento eliminado correctamente.";
            else
                return "No se pudo eliminar el departamento.";
        }

        // reporte: total de salarios por departamento
        public DataTable TotalSalariosPorDepartamento()
        {
            return dal.TotalSalariosPorDepartamento();
        }
    }
}