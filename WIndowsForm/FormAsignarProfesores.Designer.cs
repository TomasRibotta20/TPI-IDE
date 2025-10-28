namespace WIndowsForm
{
    partial class FormAsignarProfesores
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
            this.lblCurso = new System.Windows.Forms.Label();
            this.cmbCurso = new System.Windows.Forms.ComboBox();
            this.lblCursoInfo = new System.Windows.Forms.Label();
            this.lblProfesor = new System.Windows.Forms.Label();
            this.cmbProfesor = new System.Windows.Forms.ComboBox();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.lblAsignados = new System.Windows.Forms.Label();
            this.dgvProfesoresAsignados = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            this.panelPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfesoresAsignados)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.panelPrincipal.Controls.Add(this.btnVolver);
            this.panelPrincipal.Controls.Add(this.dgvProfesoresAsignados);
            this.panelPrincipal.Controls.Add(this.lblAsignados);
            this.panelPrincipal.Controls.Add(this.btnAsignar);
            this.panelPrincipal.Controls.Add(this.cmbProfesor);
            this.panelPrincipal.Controls.Add(this.lblProfesor);
            this.panelPrincipal.Controls.Add(this.lblCursoInfo);
            this.panelPrincipal.Controls.Add(this.cmbCurso);
            this.panelPrincipal.Controls.Add(this.lblCurso);
            this.panelPrincipal.Controls.Add(this.lblTitulo);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Padding = new System.Windows.Forms.Padding(20);
            this.panelPrincipal.Size = new System.Drawing.Size(1000, 650);
            this.panelPrincipal.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTitulo.Location = new System.Drawing.Point(30, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(507, 45);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "📋 Asignar Profesores a Cursos";
            // 
            // lblCurso
            // 
            this.lblCurso.AutoSize = true;
            this.lblCurso.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCurso.Location = new System.Drawing.Point(30, 90);
            this.lblCurso.Name = "lblCurso";
            this.lblCurso.Size = new System.Drawing.Size(55, 21);
            this.lblCurso.TabIndex = 1;
            this.lblCurso.Text = "Curso:";
            // 
            // cmbCurso
            // 
            this.cmbCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurso.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbCurso.FormattingEnabled = true;
            this.cmbCurso.Location = new System.Drawing.Point(120, 87);
            this.cmbCurso.Name = "cmbCurso";
            this.cmbCurso.Size = new System.Drawing.Size(400, 28);
            this.cmbCurso.TabIndex = 2;
            // 
            // lblCursoInfo
            // 
            this.lblCursoInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCursoInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblCursoInfo.Location = new System.Drawing.Point(30, 130);
            this.lblCursoInfo.Name = "lblCursoInfo";
            this.lblCursoInfo.Size = new System.Drawing.Size(800, 40);
            this.lblCursoInfo.TabIndex = 3;
            // 
            // lblProfesor
            // 
            this.lblProfesor.AutoSize = true;
            this.lblProfesor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProfesor.Location = new System.Drawing.Point(30, 190);
            this.lblProfesor.Name = "lblProfesor";
            this.lblProfesor.Size = new System.Drawing.Size(73, 21);
            this.lblProfesor.TabIndex = 4;
            this.lblProfesor.Text = "Profesor:";
            // 
            // cmbProfesor
            // 
            this.cmbProfesor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfesor.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbProfesor.FormattingEnabled = true;
            this.cmbProfesor.Location = new System.Drawing.Point(120, 187);
            this.cmbProfesor.Name = "cmbProfesor";
            this.cmbProfesor.Size = new System.Drawing.Size(400, 28);
            this.cmbProfesor.TabIndex = 5;
            // 
            // btnAsignar
            // 
            this.btnAsignar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAsignar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsignar.FlatAppearance.BorderSize = 0;
            this.btnAsignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAsignar.ForeColor = System.Drawing.Color.White;
            this.btnAsignar.Location = new System.Drawing.Point(540, 185);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(180, 45);
            this.btnAsignar.TabIndex = 6;
            this.btnAsignar.Text = "✓ Asignar Profesor";
            this.btnAsignar.UseVisualStyleBackColor = false;
            // 
            // lblAsignados
            // 
            this.lblAsignados.AutoSize = true;
            this.lblAsignados.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAsignados.Location = new System.Drawing.Point(30, 250);
            this.lblAsignados.Name = "lblAsignados";
            this.lblAsignados.Size = new System.Drawing.Size(177, 21);
            this.lblAsignados.TabIndex = 7;
            this.lblAsignados.Text = "Profesores Asignados:";
            // 
            // dgvProfesoresAsignados
            // 
            this.dgvProfesoresAsignados.AllowUserToAddRows = false;
            this.dgvProfesoresAsignados.AllowUserToDeleteRows = false;
            this.dgvProfesoresAsignados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProfesoresAsignados.BackgroundColor = System.Drawing.Color.White;
            this.dgvProfesoresAsignados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProfesoresAsignados.Location = new System.Drawing.Point(30, 285);
            this.dgvProfesoresAsignados.Name = "dgvProfesoresAsignados";
            this.dgvProfesoresAsignados.ReadOnly = true;
            this.dgvProfesoresAsignados.RowTemplate.Height = 25;
            this.dgvProfesoresAsignados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProfesoresAsignados.Size = new System.Drawing.Size(920, 250);
            this.dgvProfesoresAsignados.TabIndex = 8;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(800, 555);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(150, 45);
            this.btnVolver.TabIndex = 9;
            this.btnVolver.Text = "← Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            // 
            // FormAsignarProfesores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.panelPrincipal);
            this.Name = "FormAsignarProfesores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignar Profesores a Cursos";
            this.panelPrincipal.ResumeLayout(false);
            this.panelPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfesoresAsignados)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCurso;
        private System.Windows.Forms.ComboBox cmbCurso;
        private System.Windows.Forms.Label lblCursoInfo;
        private System.Windows.Forms.Label lblProfesor;
        private System.Windows.Forms.ComboBox cmbProfesor;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Label lblAsignados;
        private System.Windows.Forms.DataGridView dgvProfesoresAsignados;
        private System.Windows.Forms.Button btnVolver;
    }
}