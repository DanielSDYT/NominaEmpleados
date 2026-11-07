using System;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class EmpleadoNegocio
    {
        private readonly EmpleadoDAL dal = new EmpleadoDAL();

        // listar
        public DataTable ObtenerTodos()
        {
            return dal.ObtenerTodos();
        }

        // buscar por nombre o cédula
        public DataTable Buscar(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return dal.ObtenerTodos();   // si no escriben nada, muestra todo

            return dal.Buscar(texto.Trim());
        }

        // filtrar por departamento
        public DataTable FiltrarPorDepartamento(int idDepartamento)
        {
            return dal.FiltrarPorDepartamento(idDepartamento);
        }

        // agregar
        public string Insertar(Empleado e)
        {
            string error = Validar(e, 0);
            if (error != "")
                return error;

            bool ok = dal.Insertar(e.Cedula.Trim(), e.NombreEmpleado.Trim(), e.Cargo.Trim(),
                                   e.Salario, e.FechaContratacion, e.IdDepartamento);
            if (ok)
                return "Empleado guardado correctamente.";
            else
                return "No se pudo guardar el empleado.";
        }

        // modificar
        public string Actualizar(Empleado e)
        {
            if (e.IdEmpleado <= 0)
                return "Debe seleccionar un empleado de la lista.";

            string error = Validar(e, e.IdEmpleado);
            if (error != "")
                return error;

            bool ok = dal.Actualizar(e.IdEmpleado, e.Cedula.Trim(), e.NombreEmpleado.Trim(), e.Cargo.Trim(),
                                     e.Salario, e.FechaContratacion, e.IdDepartamento);
            if (ok)
                return "Empleado modificado correctamente.";
            else
                return "No se pudo modificar el empleado.";
        }

        // eliminar
        public string Eliminar(int idEmpleado)
        {
            if (idEmpleado <= 0)
                return "Debe seleccionar un empleado de la lista.";

            bool ok = dal.Eliminar(idEmpleado);
            if (ok)
                return "Empleado eliminado correctamente.";
            else
                return "No se pudo eliminar el empleado.";
        }

        // validaciones
        private string Validar(Empleado e, int idExcluir)
        {
            if (e.FechaContratacion.Date > DateTime.Today)
                return "La fecha de contratación no puede ser futura.";

            if (string.IsNullOrWhiteSpace(e.Cedula))
                return "La cédula es obligatoria.";
            if (e.Cedula.Trim().Length != 11)
                return "La cédula debe tener 11 dígitos.";

            long numero;
            if (!long.TryParse(e.Cedula.Trim(), out numero))
                return "La cédula solo debe contener números.";

            if (dal.ContarCedula(e.Cedula.Trim(), idExcluir) > 0)
                return "Ya existe un empleado con esa cédula.";

            if (string.IsNullOrWhiteSpace(e.NombreEmpleado))
                return "El nombre es obligatorio.";
            if (string.IsNullOrWhiteSpace(e.Cargo))
                return "El cargo es obligatorio.";

            if (e.Salario <= 0)
                return "El salario debe ser mayor que 0.";

            if (e.IdDepartamento <= 0)
                return "Debe seleccionar un departamento.";

            return "";   
        }
    }
}