namespace WIndowsForm
{
    partial class FormEditarDocenteCurso
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.lblCurso = new System.Windows.Forms.Label();
            this.cmbCurso = new System.Windows.Forms.ComboBox();
            this.lblProfesor = new System.Windows.Forms.Label();
            this.cmbProfesor = new System.Windows.Forms.ComboBox();
            this.lblCargo = new System.Windows.Forms.Label();
            this.cmbCargo = new System.Windows.Forms.ComboBox();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.headerPanel.Controls.Add(this.lblTitulo);
            this.headerPanel.Controls.Add(this.lblSubtitulo);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.headerPanel.Size = new System.Drawing.Size(700, 80);
            this.headerPanel.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(150, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Nueva Asignación";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.White;
            this.lblSubtitulo.Location = new System.Drawing.Point(20, 45);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(250, 15);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Complete los datos de la asignación de docente";
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.White;
            this.contentPanel.Controls.Add(this.lblCurso);
            this.contentPanel.Controls.Add(this.cmbCurso);
            this.contentPanel.Controls.Add(this.lblProfesor);
            this.contentPanel.Controls.Add(this.cmbProfesor);
            this.contentPanel.Controls.Add(this.lblCargo);
            this.contentPanel.Controls.Add(this.cmbCargo);
            this.contentPanel.Controls.Add(this.infoPanel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 80);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.contentPanel.Size = new System.Drawing.Size(700, 290);
            this.contentPanel.TabIndex = 1;
            // 
            // lblCurso
            // 
            this.lblCurso.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCurso.Location = new System.Drawing.Point(20, 20);
            this.lblCurso.Name = "lblCurso";
            this.lblCurso.Size = new System.Drawing.Size(100, 25);
            this.lblCurso.TabIndex = 0;
            this.lblCurso.Text = "Curso*:";
            this.lblCurso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbCurso
            // 
            this.cmbCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurso.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCurso.FormattingEnabled = true;
            this.cmbCurso.Location = new System.Drawing.Point(130, 20);
            this.cmbCurso.Name = "cmbCurso";
            this.cmbCurso.Size = new System.Drawing.Size(500, 23);
            this.cmbCurso.TabIndex = 1;
            // 
            // lblProfesor
            // 
            this.lblProfesor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProfesor.Location = new System.Drawing.Point(20, 65);
            this.lblProfesor.Name = "lblProfesor";
            this.lblProfesor.Size = new System.Drawing.Size(100, 25);
            this.lblProfesor.TabIndex = 2;
            this.lblProfesor.Text = "Profesor*:";
            this.lblProfesor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbProfesor
            // 
            this.cmbProfesor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfesor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbProfesor.FormattingEnabled = true;
            this.cmbProfesor.Location = new System.Drawing.Point(130, 65);
            this.cmbProfesor.Name = "cmbProfesor";
            this.cmbProfesor.Size = new System.Drawing.Size(500, 23);
            this.cmbProfesor.TabIndex = 3;
            // 
            // lblCargo
            // 
            this.lblCargo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCargo.Location = new System.Drawing.Point(20, 110);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(100, 25);
            this.lblCargo.TabIndex = 4;
            this.lblCargo.Text = "Cargo*:";
            this.lblCargo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbCargo
            // 
            this.cmbCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCargo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCargo.FormattingEnabled = true;
            this.cmbCargo.Location = new System.Drawing.Point(130, 110);
            this.cmbCargo.Name = "cmbCargo";
            this.cmbCargo.Size = new System.Drawing.Size(300, 23);
            this.cmbCargo.TabIndex = 5;
            // 
            // infoPanel
            // 
            this.infoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.infoPanel.Controls.Add(this.lblInfo);
            this.infoPanel.Location = new System.Drawing.Point(20, 155);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Padding = new System.Windows.Forms.Padding(15);
            this.infoPanel.Size = new System.Drawing.Size(610, 120);
            this.infoPanel.TabIndex = 6;
            // 
            // lblInfo
            // 
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblInfo.Location = new System.Drawing.Point(15, 15);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(580, 90);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Los cargos disponibles son:\r\n\r\n• Jefe de Cátedra: Responsable principal de la ma" +
    "teria\r\n• Titular: Profesor titular del curso\r\n• Auxiliar: Profesor auxiliar o ay" +
    "udante";
            // 
            // buttonPanel
            // 
            this.buttonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.buttonPanel.Controls.Add(this.btnGuardar);
            this.buttonPanel.Controls.Add(this.btnCancelar);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 370);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Padding = new System.Windows.Forms.Padding(20);
            this.buttonPanel.Size = new System.Drawing.Size(700, 80);
            this.buttonPanel.TabIndex = 2;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(20, 15);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(130, 40);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(160, 15);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(130, 40);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // FormEditarDocenteCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditarDocenteCurso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nueva Asignación";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.infoPanel.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Label lblCurso;
        private System.Windows.Forms.ComboBox cmbCurso;
        private System.Windows.Forms.Label lblProfesor;
        private System.Windows.Forms.ComboBox cmbProfesor;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.ComboBox cmbCargo;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}