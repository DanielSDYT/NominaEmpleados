using System;
using System.Data;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmEmpleado : Form
    {
        // instancias de la capa de negocio
        private EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();
        private DepartamentoNegocio departamentoNegocio = new DepartamentoNegocio();

        public FrmEmpleado()
        {
            InitializeComponent();
        }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDepartamentos();
                CargarEmpleados();
                CargarReporte();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos: " + ex.Message);
            }
        }

        // llena los dos ComboBox de departamento
        private void CargarDepartamentos()
        {
            // combo para registrar el empleado
            DataTable dt1 = departamentoNegocio.ObtenerTodos();
            cboDepartamento.DataSource = dt1;
            cboDepartamento.DisplayMember = "NombreDepartamento";
            cboDepartamento.ValueMember = "IdDepartamento";
            cboDepartamento.SelectedIndex = -1;   // que empiece vacío

            // combo para filtrar, con opción "Todos"
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

        // llena la tabla con todos los empleados
        private void CargarEmpleados()
        {
            dgvEmpleados.DataSource = empleadoNegocio.ObtenerTodos();
        }

        // llena el reporte de total de salarios por departamento
        private void CargarReporte()
        {
            dgvReporte.DataSource = departamentoNegocio.TotalSalariosPorDepartamento();
        }

        // toma lo que el usuario escribió y arma un objeto Empleado
        private Empleado LeerFormulario()
        {
            Empleado e = new Empleado();

            if (txtIdEmpleado.Text != "")
                e.IdEmpleado = Convert.ToInt32(txtIdEmpleado.Text);

            e.Cedula = txtCedula.Text;
            e.NombreEmpleado = txtNombreEmpleado.Text;
            e.Cargo = txtCargo.Text;
            e.FechaContratacion = dtpFechaContratacion.Value;

            // si el salario no es un número válido, lo dejamos en 0
            // y la capa de negocio dirá "el salario debe ser mayor que 0".
            decimal salario;
            if (decimal.TryParse(txtSalario.Text, out salario))
                e.Salario = salario;
            else
                e.Salario = 0;

            // departamento seleccionado en el combo
            if (cboDepartamento.SelectedValue != null)
                e.IdDepartamento = Convert.ToInt32(cboDepartamento.SelectedValue);
            else
                e.IdDepartamento = 0;

            return e;
        }

        // botón agregar
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Empleado emp = new Empleado();
                emp.Cedula = txtCedula.Text;
                emp.NombreEmpleado = txtNombreEmpleado.Text;
                emp.Cargo = txtCargo.Text;
                emp.FechaContratacion = dtpFechaContratacion.Value;

                // salario: si no es un número válido, se queda en 0
                decimal salario;
                if (decimal.TryParse(txtSalario.Text, out salario))
                    emp.Salario = salario;
                else
                    emp.Salario = 0;

                // departamento: si no hay nada seleccionado, queda en 0
                if (cboDepartamento.SelectedValue != null)
                    emp.IdDepartamento = Convert.ToInt32(cboDepartamento.SelectedValue);
                else
                    emp.IdDepartamento = 0;

                string resultado = empleadoNegocio.Insertar(emp);
                MessageBox.Show(resultado);

                CargarEmpleados();
                CargarReporte();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al agregar: " + ex.Message);
            }
        }

        // botón modificar
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Empleado emp = LeerFormulario();
                string resultado = empleadoNegocio.Actualizar(emp);
                MessageBox.Show(resultado);

                CargarEmpleados();
                CargarReporte();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al modificar: " + ex.Message);
            }
        }

        // botón eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al eliminar: " + ex.Message);
            }
        }

        // botón limpiar
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        // deja el formulario en blanco
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

        // al hacer clic en una fila de la tabla, llena los campos
        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al seleccionar la fila: " + ex.Message);
            }
        }

        // buscar por nombre o cédula (mientras escribe)
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvEmpleados.DataSource = empleadoNegocio.Buscar(txtBuscar.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al buscar: " + ex.Message);
            }
        }

        // botón buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvEmpleados.DataSource = empleadoNegocio.Buscar(txtBuscar.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al buscar: " + ex.Message);
            }
        }

        // filtrar por departamento
        private void cboFiltroDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboFiltrarDepartamento.SelectedValue == null)
                    return;

                int idDep = Convert.ToInt32(cboFiltrarDepartamento.SelectedValue);

                if (idDep == 0)   // opción "-- Todos --"
                    dgvEmpleados.DataSource = empleadoNegocio.ObtenerTodos();
                else
                    dgvEmpleados.DataSource = empleadoNegocio.FiltrarPorDepartamento(idDep);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al filtrar: " + ex.Message);
            }
        }
    }
}