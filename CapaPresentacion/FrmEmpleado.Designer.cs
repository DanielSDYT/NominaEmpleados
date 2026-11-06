namespace CapaPresentacion
{
    partial class FrmEmpleado
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gbDatosEmpleado = new GroupBox();
            cboDepartamento = new ComboBox();
            dtpFechaContratacion = new DateTimePicker();
            txtSalario = new TextBox();
            txtNombreEmpleado = new TextBox();
            txtCedula = new TextBox();
            txtIdEmpleado = new TextBox();
            lblDepartamento = new Label();
            lblFechaContratacion = new Label();
            lblSalario = new Label();
            lblCargo = new Label();
            lblNombre = new Label();
            lblCedula = new Label();
            lblIdEmpleado = new Label();
            gbBuscar = new GroupBox();
            btnBuscar = new Button();
            cboFiltrarDepartamento = new ComboBox();
            txtBuscar = new TextBox();
            lblFiltrarDepartamento = new Label();
            lblBuscar = new Label();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            groupBox1 = new GroupBox();
            dgvReporte = new DataGridView();
            groupBox2 = new GroupBox();
            dgvEmpleados = new DataGridView();
            txtCargo = new TextBox();
            gbDatosEmpleado.SuspendLayout();
            gbBuscar.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
            SuspendLayout();
            // 
            // gbDatosEmpleado
            // 
            gbDatosEmpleado.Controls.Add(txtCargo);
            gbDatosEmpleado.Controls.Add(cboDepartamento);
            gbDatosEmpleado.Controls.Add(dtpFechaContratacion);
            gbDatosEmpleado.Controls.Add(txtSalario);
            gbDatosEmpleado.Controls.Add(txtNombreEmpleado);
            gbDatosEmpleado.Controls.Add(txtCedula);
            gbDatosEmpleado.Controls.Add(txtIdEmpleado);
            gbDatosEmpleado.Controls.Add(lblDepartamento);
            gbDatosEmpleado.Controls.Add(lblFechaContratacion);
            gbDatosEmpleado.Controls.Add(lblSalario);
            gbDatosEmpleado.Controls.Add(lblCargo);
            gbDatosEmpleado.Controls.Add(lblNombre);
            gbDatosEmpleado.Controls.Add(lblCedula);
            gbDatosEmpleado.Controls.Add(lblIdEmpleado);
            gbDatosEmpleado.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbDatosEmpleado.Location = new Point(12, 6);
            gbDatosEmpleado.Name = "gbDatosEmpleado";
            gbDatosEmpleado.Size = new Size(348, 255);
            gbDatosEmpleado.TabIndex = 3;
            gbDatosEmpleado.TabStop = false;
            gbDatosEmpleado.Text = "Datos del empleado";
            //gbDatosEmpleado.Enter += groupBox1_Enter;
            // 
            // cboDepartamento
            // 
            cboDepartamento.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDepartamento.FormattingEnabled = true;
            cboDepartamento.Location = new Point(190, 216);
            cboDepartamento.Name = "cboDepartamento";
            cboDepartamento.Size = new Size(128, 28);
            cboDepartamento.TabIndex = 20;
            // 
            // dtpFechaContratacion
            // 
            dtpFechaContratacion.Format = DateTimePickerFormat.Short;
            dtpFechaContratacion.Location = new Point(190, 184);
            dtpFechaContratacion.Name = "dtpFechaContratacion";
            dtpFechaContratacion.Size = new Size(128, 27);
            dtpFechaContratacion.TabIndex = 19;
            // 
            // txtSalario
            // 
            txtSalario.BorderStyle = BorderStyle.FixedSingle;
            txtSalario.Location = new Point(193, 152);
            txtSalario.Name = "txtSalario";
            txtSalario.Size = new Size(125, 27);
            txtSalario.TabIndex = 18;
            // 
            // txtNombreEmpleado
            // 
            txtNombreEmpleado.BorderStyle = BorderStyle.FixedSingle;
            txtNombreEmpleado.Location = new Point(193, 88);
            txtNombreEmpleado.Name = "txtNombreEmpleado";
            txtNombreEmpleado.Size = new Size(125, 27);
            txtNombreEmpleado.TabIndex = 16;
            // 
            // txtCedula
            // 
            txtCedula.BorderStyle = BorderStyle.FixedSingle;
            txtCedula.Location = new Point(193, 56);
            txtCedula.MaxLength = 11;
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(125, 27);
            txtCedula.TabIndex = 15;
            // 
            // txtIdEmpleado
            // 
            txtIdEmpleado.BorderStyle = BorderStyle.FixedSingle;
            txtIdEmpleado.Location = new Point(193, 23);
            txtIdEmpleado.Name = "txtIdEmpleado";
            txtIdEmpleado.ReadOnly = true;
            txtIdEmpleado.Size = new Size(81, 27);
            txtIdEmpleado.TabIndex = 14;
            // 
            // lblDepartamento
            // 
            lblDepartamento.AutoSize = true;
            lblDepartamento.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDepartamento.Location = new Point(6, 216);
            lblDepartamento.Name = "lblDepartamento";
            lblDepartamento.Size = new Size(108, 20);
            lblDepartamento.TabIndex = 13;
            lblDepartamento.Text = "Departamento";
            // 
            // lblFechaContratacion
            // 
            lblFechaContratacion.AutoSize = true;
            lblFechaContratacion.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFechaContratacion.Location = new Point(6, 184);
            lblFechaContratacion.Name = "lblFechaContratacion";
            lblFechaContratacion.Size = new Size(141, 20);
            lblFechaContratacion.TabIndex = 12;
            lblFechaContratacion.Text = "Fecha Contratacion";
            // 
            // lblSalario
            // 
            lblSalario.AutoSize = true;
            lblSalario.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSalario.Location = new Point(6, 152);
            lblSalario.Name = "lblSalario";
            lblSalario.Size = new Size(56, 20);
            lblSalario.TabIndex = 11;
            lblSalario.Text = "Salario";
            // 
            // lblCargo
            // 
            lblCargo.AutoSize = true;
            lblCargo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCargo.Location = new Point(6, 120);
            lblCargo.Name = "lblCargo";
            lblCargo.Size = new Size(50, 20);
            lblCargo.TabIndex = 10;
            lblCargo.Text = "Cargo";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(6, 88);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(66, 20);
            lblNombre.TabIndex = 9;
            lblNombre.Text = "Nombre";
            //lblNombre.Click += label1_Click_1;
            // 
            // lblCedula
            // 
            lblCedula.AutoSize = true;
            lblCedula.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCedula.Location = new Point(6, 56);
            lblCedula.Name = "lblCedula";
            lblCedula.Size = new Size(56, 20);
            lblCedula.TabIndex = 8;
            lblCedula.Text = "Cedula";
            // 
            // lblIdEmpleado
            // 
            lblIdEmpleado.AutoSize = true;
            lblIdEmpleado.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIdEmpleado.Location = new Point(6, 24);
            lblIdEmpleado.Name = "lblIdEmpleado";
            lblIdEmpleado.Size = new Size(90, 20);
            lblIdEmpleado.TabIndex = 7;
            lblIdEmpleado.Text = "IdEmpleado";
            //lblIdEmpleado.Click += label1_Click;
            // 
            // gbBuscar
            // 
            gbBuscar.Controls.Add(btnBuscar);
            gbBuscar.Controls.Add(cboFiltrarDepartamento);
            gbBuscar.Controls.Add(txtBuscar);
            gbBuscar.Controls.Add(lblFiltrarDepartamento);
            gbBuscar.Controls.Add(lblBuscar);
            gbBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbBuscar.Location = new Point(366, 6);
            gbBuscar.Name = "gbBuscar";
            gbBuscar.Size = new Size(551, 84);
            gbBuscar.TabIndex = 4;
            gbBuscar.TabStop = false;
            gbBuscar.Text = "Buscar y Filtrar";
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.RoyalBlue;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBuscar.ForeColor = SystemColors.ButtonFace;
            btnBuscar.Location = new Point(445, 17);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(95, 29);
            btnBuscar.TabIndex = 6;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            //btnBuscar.Click += btnBuscar_Click;
            // 
            // cboFiltrarDepartamento
            // 
            cboFiltrarDepartamento.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFiltrarDepartamento.FormattingEnabled = true;
            cboFiltrarDepartamento.Location = new Point(196, 50);
            cboFiltrarDepartamento.Name = "cboFiltrarDepartamento";
            cboFiltrarDepartamento.Size = new Size(232, 28);
            cboFiltrarDepartamento.TabIndex = 5;
            //cboFiltrarDepartamento.SelectedIndexChanged += comboBox1_SelectedIndexChanged_1;
            // 
            // txtBuscar
            // 
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Location = new Point(196, 17);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(232, 27);
            txtBuscar.TabIndex = 4;
            // 
            // lblFiltrarDepartamento
            // 
            lblFiltrarDepartamento.AutoSize = true;
            lblFiltrarDepartamento.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            lblFiltrarDepartamento.Location = new Point(6, 49);
            lblFiltrarDepartamento.Name = "lblFiltrarDepartamento";
            lblFiltrarDepartamento.Size = new Size(162, 19);
            lblFiltrarDepartamento.TabIndex = 3;
            lblFiltrarDepartamento.Text = "Filtrar por departamento";
            //lblFiltrarDepartamento.Click += label1_Click_2;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            lblBuscar.Location = new Point(6, 23);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(184, 19);
            lblBuscar.TabIndex = 2;
            lblBuscar.Text = "Buscar por nombre o cedula";
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.RoyalBlue;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnAgregar.ForeColor = SystemColors.ButtonFace;
            btnAgregar.Location = new Point(12, 287);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(78, 29);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.RoyalBlue;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnModificar.ForeColor = SystemColors.ButtonFace;
            btnModificar.Location = new Point(96, 287);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(89, 29);
            btnModificar.TabIndex = 6;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.RoyalBlue;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnEliminar.ForeColor = SystemColors.ButtonFace;
            btnEliminar.Location = new Point(191, 287);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(77, 29);
            btnEliminar.TabIndex = 7;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.RoyalBlue;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnLimpiar.ForeColor = SystemColors.ButtonFace;
            btnLimpiar.Location = new Point(274, 287);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(80, 29);
            btnLimpiar.TabIndex = 8;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvReporte);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 340);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(905, 138);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Reporte: Total de salarios por Departamento";
            // 
            // dgvReporte
            // 
            dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporte.Location = new Point(10, 21);
            dgvReporte.Name = "dgvReporte";
            dgvReporte.RowHeadersWidth = 51;
            dgvReporte.Size = new Size(884, 106);
            dgvReporte.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvEmpleados);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(366, 94);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(551, 253);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Lista de Empleados";
            // 
            // dgvEmpleados
            // 
            dgvEmpleados.AllowUserToAddRows = false;
            dgvEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmpleados.Location = new Point(14, 26);
            dgvEmpleados.Name = "dgvEmpleados";
            dgvEmpleados.ReadOnly = true;
            dgvEmpleados.RowHeadersWidth = 51;
            dgvEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmpleados.Size = new Size(526, 214);
            dgvEmpleados.TabIndex = 0;
            // 
            // txtCargo
            // 
            txtCargo.BorderStyle = BorderStyle.FixedSingle;
            txtCargo.Location = new Point(193, 121);
            txtCargo.Name = "txtCargo";
            txtCargo.Size = new Size(125, 27);
            txtCargo.TabIndex = 21;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(924, 492);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(gbBuscar);
            Controls.Add(gbDatosEmpleado);
            ForeColor = SystemColors.ControlText;
            Name = "FrmEmpleado";
            Text = "Nomina De Empleados";
            Load += FrmEmpleado_Load;
            gbDatosEmpleado.ResumeLayout(false);
            gbDatosEmpleado.PerformLayout();
            gbBuscar.ResumeLayout(false);
            gbBuscar.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox gbDatosEmpleado;
        private GroupBox gbBuscar;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label lblIdEmpleado;
        private Label lblCedula;
        private Label lblNombre;
        private Label lblCargo;
        private Label lblDepartamento;
        private Label lblFechaContratacion;
        private Label lblSalario;
        private Label lblFiltrarDepartamento;
        private Label lblBuscar;
        private TextBox txtNombreEmpleado;
        private TextBox txtCedula;
        private TextBox txtIdEmpleado;
        private TextBox txtSalario;
        private ComboBox cboDepartamento;
        private DateTimePicker dtpFechaContratacion;
        private TextBox txtBuscar;
        private ComboBox cboFiltrarDepartamento;
        private DataGridView dgvEmpleados;
        private Button btnBuscar;
        private DataGridView dgvReporte;
        private TextBox txtCargo;
    }
}
