namespace WIndowsForm
{
    partial class FormMisCursosProfesor
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
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvMisCursos = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.panelPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisCursos)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.panelPrincipal.Controls.Add(this.btnVolver);
            this.panelPrincipal.Controls.Add(this.btnActualizar);
            this.panelPrincipal.Controls.Add(this.dgvMisCursos);
            this.panelPrincipal.Controls.Add(this.lblTitulo);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Padding = new System.Windows.Forms.Padding(20);
            this.panelPrincipal.Size = new System.Drawing.Size(1000, 600);
            this.panelPrincipal.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTitulo.Location = new System.Drawing.Point(30, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(334, 45);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Mis Cursos Asignados";
            // 
            // dgvMisCursos
            // 
            this.dgvMisCursos.AllowUserToAddRows = false;
            this.dgvMisCursos.AllowUserToDeleteRows = false;
            this.dgvMisCursos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMisCursos.BackgroundColor = System.Drawing.Color.White;
            this.dgvMisCursos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMisCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMisCursos.Location = new System.Drawing.Point(30, 80);
            this.dgvMisCursos.Name = "dgvMisCursos";
            this.dgvMisCursos.ReadOnly = true;
            this.dgvMisCursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMisCursos.Size = new System.Drawing.Size(920, 400);
            this.dgvMisCursos.TabIndex = 1;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(30, 500);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(150, 40);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(800, 500);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(150, 40);
            this.btnVolver.TabIndex = 3;
            this.btnVolver.Text = "Volver al Menú";
            this.btnVolver.UseVisualStyleBackColor = false;
            // 
            // FormMisCursosProfesor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelPrincipal);
            this.Name = "FormMisCursosProfesor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mis Cursos - Profesor";
            this.panelPrincipal.ResumeLayout(false);
            this.panelPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisCursos)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvMisCursos;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnVolver;
    }
}