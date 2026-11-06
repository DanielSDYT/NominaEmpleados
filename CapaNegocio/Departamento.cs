using System;

namespace CapaNegocio
{
    public class Departamento
    {
        public int IdDepartamento { get; set; }
        public string NombreDepartamento { get; set; } = string.Empty;

        public Departamento() { }
        public Departamento(int IdDepartamento, string NombreDepartamento)
        {
            this.IdDepartamento = IdDepartamento;
            this.NombreDepartamento = NombreDepartamento;

        }
    }
}