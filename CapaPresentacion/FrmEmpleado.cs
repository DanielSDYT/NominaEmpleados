using System;
using System.Data;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmEmpleado : Form
    {
        // Instancias de la capa de negocio
        private EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();
        private DepartamentoNegocio departamentoNegocio = new DepartamentoNegocio();

        public FrmEmpleado()
        {
            InitializeComponent();
        }

        // ── Se ejecuta al abrir el formulario ───────────────────────────────
        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            CargarDepartamentos();
            CargarEmpleados();
            CargarReporte();
            Limpiar();
        }

        // ── Llena los dos ComboBox de departamento ──────────────────────────
        private void CargarDepartamentos()
        {
            // Combo para registrar el empleado
            DataTable dt1 = departamentoNegocio.ObtenerTodos();
            cboDepartamento.DataSource = dt1;
            cboDepartamento.DisplayMember = "NombreDepartamento";
            cboDepartamento.ValueMember = "IdDepartamento";
            cboDepartamento.SelectedIndex = -1;   // que empiece vacío

            // Combo para filtrar, con opción "Todos"
            DataTable dt2 = departamentoNegocio.ObtenerTodos();
            DataRow fila = dt2.NewRow();
            fila["IdDepartamento"] = 0;
            fila["NombreDepartamento"] = "-- Todos --";
            dt2.Rows.InsertAt(fila, 0);

            cboFiltrarDepartamento.DataSource = dt2;
            cboFiltrarDepartamento.DisplayMember = "NombreDepartamento";
            cboFiltrarDepartamento.ValueMember = "IdDepartamento";
            cboFiltrarDepartamento.SelectedIndex = 0;   // "Todos"
        }

        // ── Llena la tabla con todos los empleados ──────────────────────────
        private void CargarEmpleados()
        {
            dgvEmpleados.DataSource = empleadoNegocio.ObtenerTodos();
        }

        // ── Llena el reporte de total de salarios por departamento ──────────
        private void CargarReporte()
        {
            dgvReporte.DataSource = departamentoNegocio.TotalSalariosPorDepartamento();
        }

        // ── Toma lo que el usuario escribió y arma un objeto Empleado ───────
        private Empleado LeerFormulario()
        {
            Empleado e = new Empleado();

            if (txtIdEmpleado.Text != "")
                e.IdEmpleado = Convert.ToInt32(txtIdEmpleado.Text);

            e.Cedula = txtCedula.Text;
            e.NombreEmpleado = txtNombreEmpleado.Text;
            e.Cargo = txtCargo.Text;
            e.FechaContratacion = dtpFechaContratacion.Value;

            // Si el salario no es un número válido, lo dejamos en 0
            // y la capa de negocio dirá "el salario debe ser mayor que 0".
            decimal salario;
            if (decimal.TryParse(txtSalario.Text, out salario))
                e.Salario = salario;
            else
                e.Salario = 0;

            // Departamento seleccionado en el combo
            if (cboDepartamento.SelectedValue != null)
                e.IdDepartamento = Convert.ToInt32(cboDepartamento.SelectedValue);
            else
                e.IdDepartamento = 0;

            return e;
        }

        // ── Botón AGREGAR ───────────────────────────────────────────────────
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Empleado emp = LeerFormulario();
            string resultado = empleadoNegocio.Insertar(emp);
            MessageBox.Show(resultado);

            CargarEmpleados();
            CargarReporte();
            Limpiar();
        }

        // ── Botón MODIFICAR ─────────────────────────────────────────────────
        private void btnModificar_Click(object sender, EventArgs e)
        {
            Empleado emp = LeerFormulario();
            string resultado = empleadoNegocio.Actualizar(emp);
            MessageBox.Show(resultado);

            CargarEmpleados();
            CargarReporte();
            Limpiar();
        }

        // ── Botón ELIMINAR ──────────────────────────────────────────────────
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtIdEmpleado.Text == "")
            {
                MessageBox.Show("Debe seleccionar un empleado de la lista.");
                return;
            }

            int id = Convert.ToInt32(txtIdEmpleado.Text);
            string resultado = empleadoNegocio.Eliminar(id);
            MessageBox.Show(resultado);

            CargarEmpleados();
            CargarReporte();
            Limpiar();
        }

        // ── Botón LIMPIAR ───────────────────────────────────────────────────
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        // ── Deja el formulario en blanco ────────────────────────────────────
        private void Limpiar()
        {
            txtIdEmpleado.Text = "";
            txtCedula.Text = "";
            txtNombreEmpleado.Text = "";
            txtCargo.Text = "";
            txtSalario.Text = "";
            dtpFechaContratacion.Value = DateTime.Today;
            cboDepartamento.SelectedIndex = -1;
            txtCedula.Focus();
        }

        // ── Al hacer clic en una fila de la tabla, llena los campos ─────────
        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvEmpleados.Rows[e.RowIndex];

            txtIdEmpleado.Text = fila.Cells["IdEmpleado"].Value.ToString();
            txtCedula.Text = fila.Cells["Cedula"].Value.ToString();
            txtNombreEmpleado.Text = fila.Cells["NombreEmpleado"].Value.ToString();
            txtCargo.Text = fila.Cells["Cargo"].Value.ToString();
            txtSalario.Text = fila.Cells["Salario"].Value.ToString();
            dtpFechaContratacion.Value = Convert.ToDateTime(fila.Cells["FechaContratacion"].Value);
            cboDepartamento.SelectedValue = fila.Cells["IdDepartamento"].Value;
        }

        // ── Buscar por nombre o cédula (mientras escribe) ───────────────────
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgvEmpleados.DataSource = empleadoNegocio.Buscar(txtBuscar.Text);
        }

        // ── Filtrar por departamento ────────────────────────────────────────
        private void cboFiltroDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFiltrarDepartamento.SelectedValue == null)
                return;

            int idDep = Convert.ToInt32(cboFiltrarDepartamento.SelectedValue);

            if (idDep == 0)   // opción "-- Todos --"
                dgvEmpleados.DataSource = empleadoNegocio.ObtenerTodos();
            else
                dgvEmpleados.DataSource = empleadoNegocio.FiltrarPorDepartamento(idDep);
        }
    }
}