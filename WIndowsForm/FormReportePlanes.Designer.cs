namespace WIndowsForm
{
    partial class FormReportePlanes
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
            this.lblFiltro = new System.Windows.Forms.Label();
            this.cboFiltroEspecialidad = new System.Windows.Forms.ComboBox();
            this.lblEstadisticas = new System.Windows.Forms.Label();
            this.panelGrafico = new System.Windows.Forms.Panel();
            this.panelContenedorGrid = new System.Windows.Forms.Panel();
            this.dgvPlanes = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panelPrincipal.SuspendLayout();
            this.panelContenedorGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanes)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.panelPrincipal.Controls.Add(this.btnCerrar);
            this.panelPrincipal.Controls.Add(this.btnExportar);
            this.panelPrincipal.Controls.Add(this.btnActualizar);
            this.panelPrincipal.Controls.Add(this.panelContenedorGrid);
            this.panelPrincipal.Controls.Add(this.panelGrafico);
            this.panelPrincipal.Controls.Add(this.lblEstadisticas);
            this.panelPrincipal.Controls.Add(this.cboFiltroEspecialidad);
            this.panelPrincipal.Controls.Add(this.lblFiltro);
            this.panelPrincipal.Controls.Add(this.lblTitulo);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Padding = new System.Windows.Forms.Padding(25);
            this.panelPrincipal.Size = new System.Drawing.Size(1400, 800);
            this.panelPrincipal.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTitulo.Location = new System.Drawing.Point(30, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(651, 47);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Reporte Detallado de Planes de Estudio";
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFiltro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblFiltro.Location = new System.Drawing.Point(30, 80);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(184, 20);
            this.lblFiltro.TabIndex = 1;
            this.lblFiltro.Text = "Filtrar por Especialidad:";
            // 
            // cboFiltroEspecialidad
            // 
            this.cboFiltroEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltroEspecialidad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboFiltroEspecialidad.Location = new System.Drawing.Point(220, 77);
            this.cboFiltroEspecialidad.Name = "cboFiltroEspecialidad";
            this.cboFiltroEspecialidad.Size = new System.Drawing.Size(300, 25);
            this.cboFiltroEspecialidad.TabIndex = 2;
            // 
            // lblEstadisticas
            // 
            this.lblEstadisticas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEstadisticas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblEstadisticas.Location = new System.Drawing.Point(30, 120);
            this.lblEstadisticas.Name = "lblEstadisticas";
            this.lblEstadisticas.Size = new System.Drawing.Size(400, 140);
            this.lblEstadisticas.TabIndex = 3;
            // 
            // panelGrafico
            // 
            this.panelGrafico.BackColor = System.Drawing.Color.White;
            this.panelGrafico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGrafico.Location = new System.Drawing.Point(450, 120);
            this.panelGrafico.Name = "panelGrafico";
            this.panelGrafico.Size = new System.Drawing.Size(900, 220);
            this.panelGrafico.TabIndex = 4;
            this.panelGrafico.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelGrafico_Paint);
            // 
            // panelContenedorGrid
            // 
            this.panelContenedorGrid.AutoScroll = true;
            this.panelContenedorGrid.BackColor = System.Drawing.Color.White;
            this.panelContenedorGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContenedorGrid.Controls.Add(this.dgvPlanes);
            this.panelContenedorGrid.Location = new System.Drawing.Point(30, 360);
            this.panelContenedorGrid.Name = "panelContenedorGrid";
            this.panelContenedorGrid.Size = new System.Drawing.Size(1320, 300);
            this.panelContenedorGrid.TabIndex = 5;
            // 
            // dgvPlanes
            // 
            this.dgvPlanes.AllowUserToAddRows = false;
            this.dgvPlanes.AllowUserToDeleteRows = false;
            this.dgvPlanes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvPlanes.BackgroundColor = System.Drawing.Color.White;
            this.dgvPlanes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPlanes.ColumnHeadersHeight = 40;
            this.dgvPlanes.Location = new System.Drawing.Point(0, 0);
            this.dgvPlanes.Name = "dgvPlanes";
            this.dgvPlanes.ReadOnly = true;
            this.dgvPlanes.RowHeadersVisible = false;
            this.dgvPlanes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dgvPlanes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlanes.Size = new System.Drawing.Size(1500, 280);
            this.dgvPlanes.TabIndex = 0;
            this.dgvPlanes.SelectionChanged += new System.EventHandler(this.DgvPlanes_SelectionChanged);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(30, 680);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(150, 45);
            this.btnActualizar.TabIndex = 6;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.Enabled = false;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(200, 680);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(280, 45);
            this.btnExportar.TabIndex = 7;
            this.btnExportar.Text = "Exportar a PDF (Próximamente)";
            this.btnExportar.UseVisualStyleBackColor = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1200, 680);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(150, 45);
            this.btnCerrar.TabIndex = 8;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            // 
            // FormReportePlanes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.panelPrincipal);
            this.Name = "FormReportePlanes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Planes de Estudio - Sistema Académico";
            this.panelPrincipal.ResumeLayout(false);
            this.panelPrincipal.PerformLayout();
            this.panelContenedorGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.ComboBox cboFiltroEspecialidad;
        private System.Windows.Forms.Label lblEstadisticas;
        private System.Windows.Forms.Panel panelGrafico;
        private System.Windows.Forms.Panel panelContenedorGrid;
        private System.Windows.Forms.DataGridView dgvPlanes;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnCerrar;
    }
}