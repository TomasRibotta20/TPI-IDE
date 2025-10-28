namespace WIndowsForm
{
    partial class FormCargarNotasProfesor
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
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSeleccionCurso = new System.Windows.Forms.Label();
            this.cmbCurso = new System.Windows.Forms.ComboBox();
            this.dgvAlumnos = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.panelPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.panelPrincipal.Controls.Add(this.btnVolver);
            this.panelPrincipal.Controls.Add(this.btnGuardar);
            this.panelPrincipal.Controls.Add(this.dgvAlumnos);
            this.panelPrincipal.Controls.Add(this.cmbCurso);
            this.panelPrincipal.Controls.Add(this.lblSeleccionCurso);
            this.panelPrincipal.Controls.Add(this.lblTitulo);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Padding = new System.Windows.Forms.Padding(20);
            this.panelPrincipal.Size = new System.Drawing.Size(1100, 700);
            this.panelPrincipal.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTitulo.Location = new System.Drawing.Point(30, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(434, 45);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "📝 Cargar Notas y Condiciones";
            // 
            // lblSeleccionCurso
            // 
            this.lblSeleccionCurso.AutoSize = true;
            this.lblSeleccionCurso.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSeleccionCurso.Location = new System.Drawing.Point(30, 80);
            this.lblSeleccionCurso.Name = "lblSeleccionCurso";
            this.lblSeleccionCurso.Size = new System.Drawing.Size(140, 21);
            this.lblSeleccionCurso.TabIndex = 1;
            this.lblSeleccionCurso.Text = "Seleccionar Curso:";
            // 
            // cmbCurso
            // 
            this.cmbCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurso.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbCurso.FormattingEnabled = true;
            this.cmbCurso.Location = new System.Drawing.Point(200, 77);
            this.cmbCurso.Name = "cmbCurso";
            this.cmbCurso.Size = new System.Drawing.Size(400, 28);
            this.cmbCurso.TabIndex = 2;
            // 
            // dgvAlumnos
            // 
            this.dgvAlumnos.AllowUserToAddRows = false;
            this.dgvAlumnos.AllowUserToDeleteRows = false;
            this.dgvAlumnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAlumnos.BackgroundColor = System.Drawing.Color.White;
            this.dgvAlumnos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAlumnos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvAlumnos.Location = new System.Drawing.Point(30, 130);
            this.dgvAlumnos.Name = "dgvAlumnos";
            this.dgvAlumnos.RowTemplate.Height = 25;
            this.dgvAlumnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvAlumnos.Size = new System.Drawing.Size(1020, 450);
            this.dgvAlumnos.TabIndex = 3;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(30, 600);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(180, 45);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "💾 Guardar Cambios";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(870, 600);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(150, 45);
            this.btnVolver.TabIndex = 5;
            this.btnVolver.Text = "← Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            // 
            // FormCargarNotasProfesor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.panelPrincipal);
            this.Name = "FormCargarNotasProfesor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargar Notas y Condiciones";
            this.panelPrincipal.ResumeLayout(false);
            this.panelPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSeleccionCurso;
        private System.Windows.Forms.ComboBox cmbCurso;
        private System.Windows.Forms.DataGridView dgvAlumnos;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnVolver;
    }
}