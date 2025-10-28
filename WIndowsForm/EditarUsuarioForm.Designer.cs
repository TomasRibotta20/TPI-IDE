namespace WIndowsForm
{
    partial class EditarUsuarioForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainLayout = new TableLayoutPanel();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblContrasenia = new Label();
            txtContrasenia = new TextBox();
            lblConfirmarContrasenia = new Label();
            txtConfirmarContrasenia = new TextBox();
            lblTipoUsuario = new Label();
            cmbTipoUsuario = new ComboBox();
            lblHabilitado = new Label();
            chkHabilitado = new CheckBox();
            panelPersona = new Panel();
            layoutPersona = new TableLayoutPanel();
            lblTituloPersona = new Label();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblDireccion = new Label();
            txtDireccion = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblFechaNacimiento = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            lblPlan = new Label();
            cmbPlan = new ComboBox();
            panelBotones = new FlowLayoutPanel();
            btnGuardar = new Button();
            btnCancelar = new Button();
            lblId = new Label();
            txtId = new TextBox();
            mainLayout.SuspendLayout();
            panelPersona.SuspendLayout();
            layoutPersona.SuspendLayout();
            panelBotones.SuspendLayout();
            SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 2;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.Controls.Add(lblUsuario, 0, 0);
            mainLayout.Controls.Add(txtUsuario, 1, 0);
            mainLayout.Controls.Add(lblEmail, 0, 1);
            mainLayout.Controls.Add(txtEmail, 1, 1);
            mainLayout.Controls.Add(lblContrasenia, 0, 2);
            mainLayout.Controls.Add(txtContrasenia, 1, 2);
            mainLayout.Controls.Add(lblConfirmarContrasenia, 0, 3);
            mainLayout.Controls.Add(txtConfirmarContrasenia, 1, 3);
            mainLayout.Controls.Add(lblTipoUsuario, 0, 4);
            mainLayout.Controls.Add(cmbTipoUsuario, 1, 4);
            mainLayout.Controls.Add(lblHabilitado, 0, 5);
            mainLayout.Controls.Add(chkHabilitado, 1, 5);
            mainLayout.Controls.Add(panelPersona, 0, 6);
            mainLayout.Controls.Add(panelBotones, 0, 7);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.Padding = new Padding(20);
            mainLayout.RowCount = 8;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            mainLayout.Size = new Size(600, 569);
            mainLayout.TabIndex = 0;
            // 
            // lblUsuario
            // 
            lblUsuario.Anchor = AnchorStyles.Right;
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(112, 30);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(55, 15);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario*:";
            // 
            // txtUsuario
            // 
            txtUsuario.Dock = DockStyle.Fill;
            txtUsuario.Location = new Point(173, 23);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(404, 23);
            txtUsuario.TabIndex = 1;
            // 
            // lblEmail
            // 
            lblEmail.Anchor = AnchorStyles.Right;
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(123, 65);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(44, 15);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email*:";
            // 
            // txtEmail
            // 
            txtEmail.Dock = DockStyle.Fill;
            txtEmail.Location = new Point(173, 58);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(404, 23);
            txtEmail.TabIndex = 3;
            // 
            // lblContrasenia
            // 
            lblContrasenia.Anchor = AnchorStyles.Right;
            lblContrasenia.AutoSize = true;
            lblContrasenia.Location = new Point(92, 100);
            lblContrasenia.Name = "lblContrasenia";
            lblContrasenia.Size = new Size(75, 15);
            lblContrasenia.TabIndex = 4;
            lblContrasenia.Text = "Contraseña*:";
            // 
            // txtContrasenia
            // 
            txtContrasenia.Dock = DockStyle.Fill;
            txtContrasenia.Location = new Point(173, 93);
            txtContrasenia.Name = "txtContrasenia";
            txtContrasenia.Size = new Size(404, 23);
            txtContrasenia.TabIndex = 5;
            txtContrasenia.UseSystemPasswordChar = true;
            // 
            // lblConfirmarContrasenia
            // 
            lblConfirmarContrasenia.Anchor = AnchorStyles.Right;
            lblConfirmarContrasenia.AutoSize = true;
            lblConfirmarContrasenia.Location = new Point(58, 135);
            lblConfirmarContrasenia.Name = "lblConfirmarContrasenia";
            lblConfirmarContrasenia.Size = new Size(109, 15);
            lblConfirmarContrasenia.TabIndex = 6;
            lblConfirmarContrasenia.Text = "Confirmar Contraseña*:";
            // 
            // txtConfirmarContrasenia
            // 
            txtConfirmarContrasenia.Dock = DockStyle.Fill;
            txtConfirmarContrasenia.Location = new Point(173, 128);
            txtConfirmarContrasenia.Name = "txtConfirmarContrasenia";
            txtConfirmarContrasenia.Size = new Size(404, 23);
            txtConfirmarContrasenia.TabIndex = 7;
            txtConfirmarContrasenia.UseSystemPasswordChar = true;
            // 
            // lblTipoUsuario
            // 
            lblTipoUsuario.Anchor = AnchorStyles.Right;
            lblTipoUsuario.AutoSize = true;
            lblTipoUsuario.Location = new Point(85, 170);
            lblTipoUsuario.Name = "lblTipoUsuario";
            lblTipoUsuario.Size = new Size(82, 15);
            lblTipoUsuario.TabIndex = 8;
            lblTipoUsuario.Text = "Tipo Usuario*:";
            // 
            // cmbTipoUsuario
            // 
            cmbTipoUsuario.Dock = DockStyle.Fill;
            cmbTipoUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoUsuario.FormattingEnabled = true;
            cmbTipoUsuario.Items.AddRange(new object[] { "Administrador", "Profesor", "Alumno" });
            cmbTipoUsuario.Location = new Point(173, 163);
            cmbTipoUsuario.Name = "cmbTipoUsuario";
            cmbTipoUsuario.Size = new Size(404, 23);
            cmbTipoUsuario.TabIndex = 9;
            // 
            // lblHabilitado
            // 
            lblHabilitado.Anchor = AnchorStyles.Right;
            lblHabilitado.AutoSize = true;
            lblHabilitado.Location = new Point(102, 205);
            lblHabilitado.Name = "lblHabilitado";
            lblHabilitado.Size = new Size(65, 15);
            lblHabilitado.TabIndex = 10;
            lblHabilitado.Text = "Habilitado:";
            // 
            // chkHabilitado
            // 
            chkHabilitado.AutoSize = true;
            chkHabilitado.Checked = true;
            chkHabilitado.CheckState = CheckState.Checked;
            chkHabilitado.Dock = DockStyle.Fill;
            chkHabilitado.Location = new Point(173, 198);
            chkHabilitado.Name = "chkHabilitado";
            chkHabilitado.Size = new Size(404, 29);
            chkHabilitado.TabIndex = 11;
            chkHabilitado.UseVisualStyleBackColor = true;
            // 
            // panelPersona
            // 
            panelPersona.AutoSize = true;
            panelPersona.BorderStyle = BorderStyle.FixedSingle;
            mainLayout.SetColumnSpan(panelPersona, 2);
            panelPersona.Controls.Add(layoutPersona);
            panelPersona.Dock = DockStyle.Fill;
            panelPersona.Location = new Point(23, 233);
            panelPersona.Name = "panelPersona";
            panelPersona.Padding = new Padding(10);
            panelPersona.Size = new Size(554, 272);
            panelPersona.TabIndex = 12;
            panelPersona.Visible = false;
            // 
            // layoutPersona
            // 
            layoutPersona.AutoSize = true;
            layoutPersona.ColumnCount = 2;
            layoutPersona.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            layoutPersona.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutPersona.Controls.Add(lblTituloPersona, 0, 0);
            layoutPersona.Controls.Add(lblNombre, 0, 1);
            layoutPersona.Controls.Add(txtNombre, 1, 1);
            layoutPersona.Controls.Add(lblApellido, 0, 2);
            layoutPersona.Controls.Add(txtApellido, 1, 2);
            layoutPersona.Controls.Add(lblDireccion, 0, 3);
            layoutPersona.Controls.Add(txtDireccion, 1, 3);
            layoutPersona.Controls.Add(lblTelefono, 0, 4);
            layoutPersona.Controls.Add(txtTelefono, 1, 4);
            layoutPersona.Controls.Add(lblFechaNacimiento, 0, 5);
            layoutPersona.Controls.Add(dtpFechaNacimiento, 1, 5);
            layoutPersona.Controls.Add(lblPlan, 0, 6);
            layoutPersona.Controls.Add(cmbPlan, 1, 6);
            layoutPersona.Dock = DockStyle.Fill;
            layoutPersona.Location = new Point(10, 10);
            layoutPersona.Name = "layoutPersona";
            layoutPersona.Padding = new Padding(5);
            layoutPersona.RowCount = 7;
            layoutPersona.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            layoutPersona.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutPersona.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutPersona.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutPersona.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutPersona.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutPersona.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutPersona.Size = new Size(532, 250);
            layoutPersona.TabIndex = 0;
            // 
            // lblTituloPersona
            // 
            lblTituloPersona.AutoSize = true;
            layoutPersona.SetColumnSpan(lblTituloPersona, 2);
            lblTituloPersona.Dock = DockStyle.Top;
            lblTituloPersona.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTituloPersona.Location = new Point(8, 5);
            lblTituloPersona.Name = "lblTituloPersona";
            lblTituloPersona.Padding = new Padding(0, 0, 0, 10);
            lblTituloPersona.Size = new Size(516, 25);
            lblTituloPersona.TabIndex = 0;
            lblTituloPersona.Text = "Datos de Persona";
            // 
            // lblNombre
            // 
            lblNombre.Anchor = AnchorStyles.Right;
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(73, 45);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(59, 15);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre*:";
            // 
            // txtNombre
            // 
            txtNombre.Dock = DockStyle.Fill;
            txtNombre.Location = new Point(138, 38);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(386, 23);
            txtNombre.TabIndex = 2;
            // 
            // lblApellido
            // 
            lblApellido.Anchor = AnchorStyles.Right;
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(73, 80);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(59, 15);
            lblApellido.TabIndex = 3;
            lblApellido.Text = "Apellido*:";
            // 
            // txtApellido
            // 
            txtApellido.Dock = DockStyle.Fill;
            txtApellido.Location = new Point(138, 73);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(386, 23);
            txtApellido.TabIndex = 4;
            // 
            // lblDireccion
            // 
            lblDireccion.Anchor = AnchorStyles.Right;
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(67, 115);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(65, 15);
            lblDireccion.TabIndex = 5;
            lblDireccion.Text = "Dirección*:";
            // 
            // txtDireccion
            // 
            txtDireccion.Dock = DockStyle.Fill;
            txtDireccion.Location = new Point(138, 108);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(386, 23);
            txtDireccion.TabIndex = 6;
            // 
            // lblTelefono
            // 
            lblTelefono.Anchor = AnchorStyles.Right;
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(76, 150);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(56, 15);
            lblTelefono.TabIndex = 7;
            lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            txtTelefono.Dock = DockStyle.Fill;
            txtTelefono.Location = new Point(138, 143);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(386, 23);
            txtTelefono.TabIndex = 8;
            // 
            // lblFechaNacimiento
            // 
            lblFechaNacimiento.Anchor = AnchorStyles.Right;
            lblFechaNacimiento.AutoSize = true;
            lblFechaNacimiento.Location = new Point(59, 185);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Size = new Size(73, 15);
            lblFechaNacimiento.TabIndex = 9;
            lblFechaNacimiento.Text = "Fecha Nac.*:";
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Dock = DockStyle.Fill;
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(138, 178);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(386, 23);
            dtpFechaNacimiento.TabIndex = 10;
            // 
            // lblPlan
            // 
            lblPlan.Anchor = AnchorStyles.Right;
            lblPlan.AutoSize = true;
            lblPlan.Location = new Point(99, 220);
            lblPlan.Name = "lblPlan";
            lblPlan.Size = new Size(33, 15);
            lblPlan.TabIndex = 11;
            lblPlan.Text = "Plan:";
            // 
            // cmbPlan
            // 
            cmbPlan.Dock = DockStyle.Fill;
            cmbPlan.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPlan.FormattingEnabled = true;
            cmbPlan.Location = new Point(138, 213);
            cmbPlan.Name = "cmbPlan";
            cmbPlan.Size = new Size(386, 23);
            cmbPlan.TabIndex = 12;
            // 
            // panelBotones
            // 
            panelBotones.AutoSize = true;
            mainLayout.SetColumnSpan(panelBotones, 2);
            panelBotones.Controls.Add(btnGuardar);
            panelBotones.Controls.Add(btnCancelar);
            panelBotones.Dock = DockStyle.Fill;
            panelBotones.FlowDirection = FlowDirection.RightToLeft;
            panelBotones.Location = new Point(23, 511);
            panelBotones.Name = "panelBotones";
            panelBotones.Padding = new Padding(0, 10, 0, 0);
            panelBotones.Size = new Size(554, 44);
            panelBotones.TabIndex = 13;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(0, 122, 204);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(451, 13);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 35);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(345, 13);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 35);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lblId
            // 
            lblId.Location = new Point(0, 0);
            lblId.Name = "lblId";
            lblId.Size = new Size(100, 23);
            lblId.TabIndex = 0;
            // 
            // txtId
            // 
            txtId.Location = new Point(0, 0);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 0;
            // 
            // EditarUsuarioForm
            // 
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(600, 569);
            Controls.Add(mainLayout);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimumSize = new Size(600, 500);
            Name = "EditarUsuarioForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Editar Usuario";
            mainLayout.ResumeLayout(false);
            mainLayout.PerformLayout();
            panelPersona.ResumeLayout(false);
            panelPersona.PerformLayout();
            layoutPersona.ResumeLayout(false);
            layoutPersona.PerformLayout();
            panelBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblContrasenia;
        private System.Windows.Forms.TextBox txtContrasenia;
        private System.Windows.Forms.Label lblConfirmarContrasenia;
        private System.Windows.Forms.TextBox txtConfirmarContrasenia;
        private System.Windows.Forms.Label lblTipoUsuario;
        private System.Windows.Forms.ComboBox cmbTipoUsuario;
        private System.Windows.Forms.Label lblHabilitado;
        private System.Windows.Forms.CheckBox chkHabilitado;
        private System.Windows.Forms.Panel panelPersona;
        private System.Windows.Forms.TableLayoutPanel layoutPersona;
        private System.Windows.Forms.Label lblTituloPersona;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.ComboBox cmbPlan;
        private System.Windows.Forms.FlowLayoutPanel panelBotones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}