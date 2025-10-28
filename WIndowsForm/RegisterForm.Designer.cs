namespace WIndowsForm
{
    partial class RegisterForm
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblUsuarioSection = new System.Windows.Forms.Label();
            this.lblUsuarioNombre = new System.Windows.Forms.Label();
            this.txtUsuarioNombre = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPersonaSection = new System.Windows.Forms.Label();
            this.lblTipoPersona = new System.Windows.Forms.Label();
            this.cmbTipoPersona = new System.Windows.Forms.ComboBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblPlan = new System.Windows.Forms.Label();
            this.cmbPlan = new System.Windows.Forms.ComboBox();
            this.separator = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblNota = new System.Windows.Forms.Label();
            this.lnkVolverLogin = new System.Windows.Forms.LinkLabel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(560, 35);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "REGISTRO - PROFESOR/ALUMNO";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUsuarioSection
            // 
            this.lblUsuarioSection.BackColor = System.Drawing.Color.LightGray;
            this.lblUsuarioSection.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsuarioSection.Location = new System.Drawing.Point(20, 70);
            this.lblUsuarioSection.Name = "lblUsuarioSection";
            this.lblUsuarioSection.Size = new System.Drawing.Size(560, 25);
            this.lblUsuarioSection.TabIndex = 1;
            this.lblUsuarioSection.Text = "DATOS DEL USUARIO";
            // 
            // lblUsuarioNombre
            // 
            this.lblUsuarioNombre.Location = new System.Drawing.Point(20, 105);
            this.lblUsuarioNombre.Name = "lblUsuarioNombre";
            this.lblUsuarioNombre.Size = new System.Drawing.Size(150, 23);
            this.lblUsuarioNombre.TabIndex = 2;
            this.lblUsuarioNombre.Text = "Usuario*:";
            // 
            // txtUsuarioNombre
            // 
            this.txtUsuarioNombre.Location = new System.Drawing.Point(180, 102);
            this.txtUsuarioNombre.Name = "txtUsuarioNombre";
            this.txtUsuarioNombre.Size = new System.Drawing.Size(380, 23);
            this.txtUsuarioNombre.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(20, 135);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(150, 23);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Contraseña*:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(180, 132);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(380, 23);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.Location = new System.Drawing.Point(20, 165);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(150, 23);
            this.lblConfirmPassword.TabIndex = 6;
            this.lblConfirmPassword.Text = "Confirmar Contraseña*:";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(180, 162);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(380, 23);
            this.txtConfirmPassword.TabIndex = 7;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(20, 195);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(150, 23);
            this.lblEmail.TabIndex = 8;
            this.lblEmail.Text = "Email*:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(180, 192);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(380, 23);
            this.txtEmail.TabIndex = 9;
            // 
            // lblPersonaSection
            // 
            this.lblPersonaSection.BackColor = System.Drawing.Color.LightGray;
            this.lblPersonaSection.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPersonaSection.Location = new System.Drawing.Point(20, 235);
            this.lblPersonaSection.Name = "lblPersonaSection";
            this.lblPersonaSection.Size = new System.Drawing.Size(560, 25);
            this.lblPersonaSection.TabIndex = 10;
            this.lblPersonaSection.Text = "DATOS PERSONALES";
            // 
            // lblTipoPersona
            // 
            this.lblTipoPersona.Location = new System.Drawing.Point(20, 270);
            this.lblTipoPersona.Name = "lblTipoPersona";
            this.lblTipoPersona.Size = new System.Drawing.Size(150, 23);
            this.lblTipoPersona.TabIndex = 11;
            this.lblTipoPersona.Text = "Tipo*:";
            // 
            // cmbTipoPersona
            // 
            this.cmbTipoPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPersona.Location = new System.Drawing.Point(180, 267);
            this.cmbTipoPersona.Name = "cmbTipoPersona";
            this.cmbTipoPersona.Size = new System.Drawing.Size(380, 23);
            this.cmbTipoPersona.TabIndex = 12;
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(20, 300);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(150, 23);
            this.lblNombre.TabIndex = 13;
            this.lblNombre.Text = "Nombre*:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(180, 297);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(380, 23);
            this.txtNombre.TabIndex = 14;
            // 
            // lblApellido
            // 
            this.lblApellido.Location = new System.Drawing.Point(20, 330);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(150, 23);
            this.lblApellido.TabIndex = 15;
            this.lblApellido.Text = "Apellido*:";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(180, 327);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(380, 23);
            this.txtApellido.TabIndex = 16;
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.Location = new System.Drawing.Point(20, 360);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(150, 23);
            this.lblFechaNacimiento.TabIndex = 17;
            this.lblFechaNacimiento.Text = "Fecha Nacimiento*:";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(180, 357);
            this.dtpFechaNacimiento.MaxDate = new System.DateTime(2009, 12, 31, 0, 0, 0, 0);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(380, 23);
            this.dtpFechaNacimiento.TabIndex = 18;
            this.dtpFechaNacimiento.Value = new System.DateTime(2004, 12, 31, 0, 0, 0, 0);
            // 
            // lblDireccion
            // 
            this.lblDireccion.Location = new System.Drawing.Point(20, 390);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(150, 23);
            this.lblDireccion.TabIndex = 19;
            this.lblDireccion.Text = "Dirección*:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(180, 387);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(380, 23);
            this.txtDireccion.TabIndex = 20;
            // 
            // lblTelefono
            // 
            this.lblTelefono.Location = new System.Drawing.Point(20, 420);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(150, 23);
            this.lblTelefono.TabIndex = 21;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(180, 417);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(380, 23);
            this.txtTelefono.TabIndex = 22;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTelefono_KeyPress);
            this.txtTelefono.TextChanged += new System.EventHandler(this.TxtTelefono_TextChanged);
            // 
            // lblPlan
            // 
            this.lblPlan.Location = new System.Drawing.Point(20, 450);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(150, 23);
            this.lblPlan.TabIndex = 23;
            this.lblPlan.Text = "Plan de Estudios:";
            // 
            // cmbPlan
            // 
            this.cmbPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlan.Location = new System.Drawing.Point(180, 447);
            this.cmbPlan.Name = "cmbPlan";
            this.cmbPlan.Size = new System.Drawing.Size(380, 23);
            this.cmbPlan.TabIndex = 24;
            // 
            // separator
            // 
            this.separator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.separator.Location = new System.Drawing.Point(20, 490);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(560, 2);
            this.separator.TabIndex = 25;
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblInfo.Location = new System.Drawing.Point(20, 505);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(560, 20);
            this.lblInfo.TabIndex = 26;
            this.lblInfo.Text = "* Campos obligatorios | El legajo se generará automáticamente | Plan es opcional";
            // 
            // lblNota
            // 
            this.lblNota.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblNota.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblNota.Location = new System.Drawing.Point(20, 530);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(560, 30);
            this.lblNota.TabIndex = 27;
            this.lblNota.Text = "Nota: Solo se pueden registrar Profesores y Alumnos.\r\nLos Administradores son cr" +
    "eados por el sistema.";
            // 
            // lnkVolverLogin
            // 
            this.lnkVolverLogin.Location = new System.Drawing.Point(20, 603);
            this.lnkVolverLogin.Name = "lnkVolverLogin";
            this.lnkVolverLogin.Size = new System.Drawing.Size(150, 20);
            this.lnkVolverLogin.TabIndex = 28;
            this.lnkVolverLogin.TabStop = true;
            this.lnkVolverLogin.Text = "¿ Volver al Login";
            this.lnkVolverLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkVolverLogin_LinkClicked);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(300, 595);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 35);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Location = new System.Drawing.Point(440, 595);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(120, 35);
            this.btnRegistrar.TabIndex = 30;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 650);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lnkVolverLogin);
            this.Controls.Add(this.lblNota);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.separator);
            this.Controls.Add(this.cmbPlan);
            this.Controls.Add(this.lblPlan);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.dtpFechaNacimiento);
            this.Controls.Add(this.lblFechaNacimiento);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.cmbTipoPersona);
            this.Controls.Add(this.lblTipoPersona);
            this.Controls.Add(this.lblPersonaSection);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsuarioNombre);
            this.Controls.Add(this.lblUsuarioNombre);
            this.Controls.Add(this.lblUsuarioSection);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Usuario (Profesor/Alumno)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuarioSection;
        private System.Windows.Forms.Label lblUsuarioNombre;
        private System.Windows.Forms.TextBox txtUsuarioNombre;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPersonaSection;
        private System.Windows.Forms.Label lblTipoPersona;
        private System.Windows.Forms.ComboBox cmbTipoPersona;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.ComboBox cmbPlan;
        private System.Windows.Forms.Label separator;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.LinkLabel lnkVolverLogin;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnRegistrar;
    }
}