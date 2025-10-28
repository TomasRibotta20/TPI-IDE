namespace WIndowsForm
{
    partial class FormGestionarDocentesCurso
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
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.filtrosPanel = new System.Windows.Forms.Panel();
            this.lblFiltroCurso = new System.Windows.Forms.Label();
            this.cmbFiltroCurso = new System.Windows.Forms.ComboBox();
            this.btnMostrarTodos = new System.Windows.Forms.Button();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.dataGridViewAsignaciones = new System.Windows.Forms.DataGridView();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            this.filtrosPanel.SuspendLayout();
            this.gridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAsignaciones)).BeginInit();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.headerPanel.Controls.Add(this.lblSubtitulo);
            this.headerPanel.Controls.Add(this.lblTitulo);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(20);
            this.headerPanel.Size = new System.Drawing.Size(1100, 80);
            this.headerPanel.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(310, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gestión de Docentes por Curso";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.White;
            this.lblSubtitulo.Location = new System.Drawing.Point(20, 45);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(280, 15);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Asigne profesores a cursos con diferentes cargos";
            // 
            // filtrosPanel
            // 
            this.filtrosPanel.BackColor = System.Drawing.Color.White;
            this.filtrosPanel.Controls.Add(this.btnMostrarTodos);
            this.filtrosPanel.Controls.Add(this.cmbFiltroCurso);
            this.filtrosPanel.Controls.Add(this.lblFiltroCurso);
            this.filtrosPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filtrosPanel.Location = new System.Drawing.Point(0, 80);
            this.filtrosPanel.Name = "filtrosPanel";
            this.filtrosPanel.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.filtrosPanel.Size = new System.Drawing.Size(1100, 70);
            this.filtrosPanel.TabIndex = 1;
            // 
            // lblFiltroCurso
            // 
            this.lblFiltroCurso.AutoSize = true;
            this.lblFiltroCurso.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFiltroCurso.Location = new System.Drawing.Point(20, 25);
            this.lblFiltroCurso.Name = "lblFiltroCurso";
            this.lblFiltroCurso.Size = new System.Drawing.Size(105, 15);
            this.lblFiltroCurso.TabIndex = 0;
            this.lblFiltroCurso.Text = "Filtrar por Curso:";
            // 
            // cmbFiltroCurso
            // 
            this.cmbFiltroCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroCurso.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFiltroCurso.FormattingEnabled = true;
            this.cmbFiltroCurso.Location = new System.Drawing.Point(145, 22);
            this.cmbFiltroCurso.Name = "cmbFiltroCurso";
            this.cmbFiltroCurso.Size = new System.Drawing.Size(450, 23);
            this.cmbFiltroCurso.TabIndex = 1;
            // 
            // btnMostrarTodos
            // 
            this.btnMostrarTodos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnMostrarTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarTodos.ForeColor = System.Drawing.Color.White;
            this.btnMostrarTodos.Location = new System.Drawing.Point(610, 18);
            this.btnMostrarTodos.Name = "btnMostrarTodos";
            this.btnMostrarTodos.Size = new System.Drawing.Size(140, 35);
            this.btnMostrarTodos.TabIndex = 2;
            this.btnMostrarTodos.Text = "Mostrar Todos";
            this.btnMostrarTodos.UseVisualStyleBackColor = false;
            // 
            // gridPanel
            // 
            this.gridPanel.BackColor = System.Drawing.SystemColors.Control;
            this.gridPanel.Controls.Add(this.dataGridViewAsignaciones);
            this.gridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPanel.Location = new System.Drawing.Point(0, 150);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.gridPanel.Size = new System.Drawing.Size(1100, 420);
            this.gridPanel.TabIndex = 2;
            // 
            // dataGridViewAsignaciones
            // 
            this.dataGridViewAsignaciones.AllowUserToAddRows = false;
            this.dataGridViewAsignaciones.AllowUserToDeleteRows = false;
            this.dataGridViewAsignaciones.AutoGenerateColumns = false;
            this.dataGridViewAsignaciones.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewAsignaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAsignaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAsignaciones.Location = new System.Drawing.Point(20, 10);
            this.dataGridViewAsignaciones.MultiSelect = false;
            this.dataGridViewAsignaciones.Name = "dataGridViewAsignaciones";
            this.dataGridViewAsignaciones.ReadOnly = true;
            this.dataGridViewAsignaciones.RowHeadersVisible = false;
            this.dataGridViewAsignaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAsignaciones.Size = new System.Drawing.Size(1060, 400);
            this.dataGridViewAsignaciones.TabIndex = 0;
            // 
            // buttonPanel
            // 
            this.buttonPanel.BackColor = System.Drawing.SystemColors.Control;
            this.buttonPanel.Controls.Add(this.btnVolver);
            this.buttonPanel.Controls.Add(this.btnEliminar);
            this.buttonPanel.Controls.Add(this.btnEditar);
            this.buttonPanel.Controls.Add(this.btnNuevo);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 570);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Padding = new System.Windows.Forms.Padding(20);
            this.buttonPanel.Size = new System.Drawing.Size(1100, 80);
            this.buttonPanel.TabIndex = 3;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(20, 20);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(160, 40);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Nueva Asignación";
            this.btnNuevo.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(190, 20);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(130, 40);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(330, 20);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(130, 40);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(470, 20);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(160, 40);
            this.btnVolver.TabIndex = 3;
            this.btnVolver.Text = "Volver al Menú";
            this.btnVolver.UseVisualStyleBackColor = false;
            // 
            // FormGestionarDocentesCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.filtrosPanel);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(900, 550);
            this.Name = "FormGestionarDocentesCurso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Docentes por Curso";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.filtrosPanel.ResumeLayout(false);
            this.filtrosPanel.PerformLayout();
            this.gridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAsignaciones)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel filtrosPanel;
        private System.Windows.Forms.Button btnMostrarTodos;
        private System.Windows.Forms.ComboBox cmbFiltroCurso;
        private System.Windows.Forms.Label lblFiltroCurso;
        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.DataGridView dataGridViewAsignaciones;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnNuevo;
    }
}