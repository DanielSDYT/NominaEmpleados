using System;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class EmpleadoNegocio
    {
        private readonly EmpleadoDAL dal = new EmpleadoDAL();

        // ── Funcionalidad 1: listar ─────────────────────────────────────────
        public DataTable ObtenerTodos()
        {
            return dal.ObtenerTodos();
        }

        // ── Funcionalidad 2: buscar por nombre o cédula ─────────────────────
        public DataTable Buscar(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return dal.ObtenerTodos();   // si no escriben nada, muestra todo

            return dal.Buscar(texto.Trim());
        }

        // ── Funcionalidad 3: filtrar por departamento ───────────────────────
        public DataTable FiltrarPorDepartamento(int idDepartamento)
        {
            return dal.FiltrarPorDepartamento(idDepartamento);
        }

        // ── AGREGAR (valida las 3 reglas de negocio) ────────────────────────
        public string Insertar(Empleado e)
        {
            string error = Validar(e, 0);
            if (error != "")
                return error;

            bool ok = dal.Insertar(e.Cedula.Trim(), e.NombreEmpleado.Trim(), e.Cargo.Trim(),
                                   e.Salario, e.FechaContratacion, e.IdDepartamento);
            return ok ? "Empleado guardado correctamente." : "No se pudo guardar el empleado.";
        }

        // ── MODIFICAR ───────────────────────────────────────────────────────
        public string Actualizar(Empleado e)
        {
            if (e.IdEmpleado <= 0)
                return "Debe seleccionar un empleado de la lista.";

            // idExcluir = e.IdEmpleado, para no chocar con la propia cédula
            string error = Validar(e, e.IdEmpleado);
            if (error != "")
                return error;

            bool ok = dal.Actualizar(e.IdEmpleado, e.Cedula.Trim(), e.NombreEmpleado.Trim(), e.Cargo.Trim(),
                                     e.Salario, e.FechaContratacion, e.IdDepartamento);
            return ok ? "Empleado modificado correctamente." : "No se pudo modificar el empleado.";
        }

        // ── ELIMINAR ────────────────────────────────────────────────────────
        public string Eliminar(int idEmpleado)
        {
            if (idEmpleado <= 0)
                return "Debe seleccionar un empleado de la lista.";

            bool ok = dal.Eliminar(idEmpleado);
            return ok ? "Empleado eliminado correctamente." : "No se pudo eliminar el empleado.";
        }

        // ── Validaciones centralizadas (las 3 reglas del PDF) ───────────────
        private string Validar(Empleado e, int idExcluir)
        {
            // Regla 3: la fecha no puede ser futura
            if (e.FechaContratacion.Date > DateTime.Today)
                return "La fecha de contratación no puede ser futura.";

            // Regla 1: la cédula debe tener 11 dígitos
            if (string.IsNullOrWhiteSpace(e.Cedula))
                return "La cédula es obligatoria.";
            if (e.Cedula.Trim().Length != 11)
                return "La cédula debe tener 11 dígitos.";

            foreach (char c in e.Cedula.Trim())
                if (!char.IsDigit(c))
                    return "La cédula solo debe contener números.";

            // Regla 1 (parte 2): la cédula debe ser única
            if (dal.ContarCedula(e.Cedula.Trim(), idExcluir) > 0)
                return "Ya existe un empleado con esa cédula.";

            // Campos obligatorios
            if (string.IsNullOrWhiteSpace(e.NombreEmpleado))
                return "El nombre es obligatorio.";
            if (string.IsNullOrWhiteSpace(e.Cargo))
                return "El cargo es obligatorio.";

            // Regla 2: el salario debe ser mayor que 0
            if (e.Salario <= 0)
                return "El salario debe ser mayor que 0.";

            // Departamento obligatorio
            if (e.IdDepartamento <= 0)
                return "Debe seleccionar un departamento.";

            return "";   // sin errores → se puede guardar
        }
    }
}