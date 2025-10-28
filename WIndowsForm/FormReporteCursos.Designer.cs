namespace WIndowsForm
{
    partial class FormReporteCursos
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
            this.panelEstadisticas = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTotalInscripciones = new System.Windows.Forms.Label();
            this.lblPromocionales = new System.Windows.Forms.Label();
            this.lblRegulares = new System.Windows.Forms.Label();
            this.lblLibres = new System.Windows.Forms.Label();
            this.panelGraficos = new System.Windows.Forms.Panel();
            this.panelGraficoCondiciones = new System.Windows.Forms.Panel();
            this.panelGraficoOcupacion = new System.Windows.Forms.Panel();
            this.dataGridViewCursos = new System.Windows.Forms.DataGridView();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panelEstadisticas.SuspendLayout();
            this.panelGraficos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCursos)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEstadisticas
            // 
            this.panelEstadisticas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.panelEstadisticas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEstadisticas.Controls.Add(this.lblLibres);
            this.panelEstadisticas.Controls.Add(this.lblRegulares);
            this.panelEstadisticas.Controls.Add(this.lblPromocionales);
            this.panelEstadisticas.Controls.Add(this.lblTotalInscripciones);
            this.panelEstadisticas.Controls.Add(this.lblTitulo);
            this.panelEstadisticas.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEstadisticas.Location = new System.Drawing.Point(0, 0);
            this.panelEstadisticas.Name = "panelEstadisticas";
            this.panelEstadisticas.Size = new System.Drawing.Size(1200, 80);
            this.panelEstadisticas.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Padding = new System.Windows.Forms.Padding(10);
            this.lblTitulo.Size = new System.Drawing.Size(1198, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "REPORTE COMPLETO DE CURSOS E INSCRIPCIONES";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalInscripciones
            // 
            this.lblTotalInscripciones.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalInscripciones.Location = new System.Drawing.Point(20, 50);
            this.lblTotalInscripciones.Name = "lblTotalInscripciones";
            this.lblTotalInscripciones.Size = new System.Drawing.Size(200, 25);
            this.lblTotalInscripciones.TabIndex = 1;
            this.lblTotalInscripciones.Text = "Total: 0";
            // 
            // lblPromocionales
            // 
            this.lblPromocionales.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPromocionales.ForeColor = System.Drawing.Color.Green;
            this.lblPromocionales.Location = new System.Drawing.Point(250, 50);
            this.lblPromocionales.Name = "lblPromocionales";
            this.lblPromocionales.Size = new System.Drawing.Size(180, 25);
            this.lblPromocionales.TabIndex = 2;
            this.lblPromocionales.Text = "Promocionales: 0";
            // 
            // lblRegulares
            // 
            this.lblRegulares.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblRegulares.ForeColor = System.Drawing.Color.Blue;
            this.lblRegulares.Location = new System.Drawing.Point(450, 50);
            this.lblRegulares.Name = "lblRegulares";
            this.lblRegulares.Size = new System.Drawing.Size(150, 25);
            this.lblRegulares.TabIndex = 3;
            this.lblRegulares.Text = "Regulares: 0";
            // 
            // lblLibres
            // 
            this.lblLibres.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblLibres.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblLibres.Location = new System.Drawing.Point(620, 50);
            this.lblLibres.Name = "lblLibres";
            this.lblLibres.Size = new System.Drawing.Size(150, 25);
            this.lblLibres.TabIndex = 4;
            this.lblLibres.Text = "Libres: 0";
            // 
            // panelGraficos
            // 
            this.panelGraficos.Controls.Add(this.panelGraficoOcupacion);
            this.panelGraficos.Controls.Add(this.panelGraficoCondiciones);
            this.panelGraficos.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGraficos.Location = new System.Drawing.Point(0, 80);
            this.panelGraficos.Name = "panelGraficos";
            this.panelGraficos.Size = new System.Drawing.Size(1200, 200);
            this.panelGraficos.TabIndex = 1;
            // 
            // panelGraficoCondiciones
            // 
            this.panelGraficoCondiciones.BackColor = System.Drawing.Color.White;
            this.panelGraficoCondiciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGraficoCondiciones.Location = new System.Drawing.Point(12, 12);
            this.panelGraficoCondiciones.Name = "panelGraficoCondiciones";
            this.panelGraficoCondiciones.Size = new System.Drawing.Size(580, 176);
            this.panelGraficoCondiciones.TabIndex = 0;
            // 
            // panelGraficoOcupacion
            // 
            this.panelGraficoOcupacion.BackColor = System.Drawing.Color.White;
            this.panelGraficoOcupacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGraficoOcupacion.Location = new System.Drawing.Point(606, 12);
            this.panelGraficoOcupacion.Name = "panelGraficoOcupacion";
            this.panelGraficoOcupacion.Size = new System.Drawing.Size(580, 176);
            this.panelGraficoOcupacion.TabIndex = 1;
            // 
            // dataGridViewCursos
            // 
            this.dataGridViewCursos.AllowUserToAddRows = false;
            this.dataGridViewCursos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCursos.Location = new System.Drawing.Point(12, 292);
            this.dataGridViewCursos.Name = "dataGridViewCursos";
            this.dataGridViewCursos.ReadOnly = true;
            this.dataGridViewCursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCursos.Size = new System.Drawing.Size(1176, 300);
            this.dataGridViewCursos.TabIndex = 2;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.LightGreen;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportar.Location = new System.Drawing.Point(950, 600);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(120, 35);
            this.btnExportar.TabIndex = 3;
            this.btnExportar.Text = "Exportar PDF";
            this.btnExportar.UseVisualStyleBackColor = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.LightGray;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.Location = new System.Drawing.Point(1080, 600);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 35);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            // 
            // FormReporteCursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dataGridViewCursos);
            this.Controls.Add(this.panelGraficos);
            this.Controls.Add(this.panelEstadisticas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormReporteCursos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reporte Completo de Cursos - Sistema Académico";
            this.panelEstadisticas.ResumeLayout(false);
            this.panelGraficos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCursos)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelEstadisticas;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTotalInscripciones;
        private System.Windows.Forms.Label lblPromocionales;
        private System.Windows.Forms.Label lblRegulares;
        private System.Windows.Forms.Label lblLibres;
        private System.Windows.Forms.Panel panelGraficos;
        private System.Windows.Forms.Panel panelGraficoCondiciones;
        private System.Windows.Forms.Panel panelGraficoOcupacion;
        private System.Windows.Forms.DataGridView dataGridViewCursos;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnCerrar;
    }
}