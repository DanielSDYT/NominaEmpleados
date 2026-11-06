using System;

namespace CapaNegocio
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Cedula { get; set; } = string.Empty;
        public string NombreEmpleado { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public decimal Salario { get; set; } = 0;
        public DateTime FechaContratacion { get; set; }
        public int IdDepartamento { get; set; }

        public Empleado() { }
        public Empleado(int IdEmpleado, string Cedula, string NombreEmpleado, string Cargo, decimal Salario, DateTime FechaContratacion, int IdDepartamento)
        {
            this.IdEmpleado = IdEmpleado;
            this.Cedula = Cedula;
            this.NombreEmpleado = NombreEmpleado;
            this.Cargo = Cargo;
            this.Salario = Salario;
            this.FechaContratacion = FechaContratacion;
            this.IdDepartamento = IdDepartamento;
        }
    }
}