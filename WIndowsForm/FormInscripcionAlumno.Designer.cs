namespace WIndowsForm
{
    partial class FormInscripcionAlumno
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
            panelPrincipal = new Panel();
            btnVolver = new Button();
            flowPanelCursos = new FlowLayoutPanel();
            panelFiltros = new Panel();
            btnActualizar = new Button();
            lblDisponibilidad = new Label();
            cmbDisponibilidad = new ComboBox();
            lblAnio = new Label();
            cmbAnio = new ComboBox();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            lblTitulo = new Label();
            panelPrincipal.SuspendLayout();
            panelFiltros.SuspendLayout();
            SuspendLayout();
            // 
            // panelPrincipal
            // 
            panelPrincipal.BackColor = Color.FromArgb(240, 244, 248);
            panelPrincipal.Controls.Add(btnVolver);
            panelPrincipal.Controls.Add(flowPanelCursos);
            panelPrincipal.Controls.Add(panelFiltros);
            panelPrincipal.Controls.Add(lblTitulo);
            panelPrincipal.Dock = DockStyle.Fill;
            panelPrincipal.Location = new Point(0, 0);
            panelPrincipal.Name = "panelPrincipal";
            panelPrincipal.Padding = new Padding(20);
            panelPrincipal.Size = new Size(1250, 750);
            panelPrincipal.TabIndex = 0;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.FromArgb(149, 165, 166);
            btnVolver.Cursor = Cursors.Hand;
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Font = new Font("Segoe UI", 11F);
            btnVolver.ForeColor = Color.White;
            btnVolver.Location = new Point(1020, 675);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(180, 40);
            btnVolver.TabIndex = 3;
            btnVolver.Text = "Volver al Dashboard";
            btnVolver.UseVisualStyleBackColor = false;
            // 
            // flowPanelCursos
            // 
            flowPanelCursos.AutoScroll = true;
            flowPanelCursos.BackColor = Color.White;
            flowPanelCursos.BorderStyle = BorderStyle.FixedSingle;
            flowPanelCursos.Location = new Point(30, 165);
            flowPanelCursos.Name = "flowPanelCursos";
            flowPanelCursos.Size = new Size(1170, 500);
            flowPanelCursos.TabIndex = 2;
            // 
            // panelFiltros
            // 
            panelFiltros.BackColor = Color.White;
            panelFiltros.BorderStyle = BorderStyle.FixedSingle;
            panelFiltros.Controls.Add(btnActualizar);
            panelFiltros.Controls.Add(lblDisponibilidad);
            panelFiltros.Controls.Add(cmbDisponibilidad);
            panelFiltros.Controls.Add(lblAnio);
            panelFiltros.Controls.Add(cmbAnio);
            panelFiltros.Controls.Add(lblBuscar);
            panelFiltros.Controls.Add(txtBuscar);
            panelFiltros.Location = new Point(30, 70);
            panelFiltros.Name = "panelFiltros";
            panelFiltros.Size = new Size(1170, 80);
            panelFiltros.TabIndex = 1;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(102, 126, 234);
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(790, 35);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(120, 35);
            btnActualizar.TabIndex = 6;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            // 
            // lblDisponibilidad
            // 
            lblDisponibilidad.AutoSize = true;
            lblDisponibilidad.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDisponibilidad.Location = new Point(565, 15);
            lblDisponibilidad.Name = "lblDisponibilidad";
            lblDisponibilidad.Size = new Size(110, 19);
            lblDisponibilidad.TabIndex = 4;
            lblDisponibilidad.Text = "Disponibilidad:";
            // 
            // cmbDisponibilidad
            // 
            cmbDisponibilidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDisponibilidad.Font = new Font("Segoe UI", 10F);
            cmbDisponibilidad.FormattingEnabled = true;
            cmbDisponibilidad.Items.AddRange(new object[] { "Todos", "Con cupo", "Sin cupo", "Inscripto" });
            cmbDisponibilidad.Location = new Point(565, 40);
            cmbDisponibilidad.Name = "cmbDisponibilidad";
            cmbDisponibilidad.Size = new Size(200, 25);
            cmbDisponibilidad.TabIndex = 5;
            // 
            // lblAnio
            // 
            lblAnio.AutoSize = true;
            lblAnio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAnio.Location = new Point(340, 15);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new Size(40, 19);
            lblAnio.TabIndex = 2;
            lblAnio.Text = "Año:"; // <-- CORREGIDO
            // 
            // cmbAnio
            // 
            cmbAnio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAnio.Font = new Font("Segoe UI", 10F);
            cmbAnio.FormattingEnabled = true;
            cmbAnio.Location = new Point(340, 40);
            cmbAnio.Name = "cmbAnio";
            cmbAnio.Size = new Size(200, 25);
            cmbAnio.TabIndex = 3;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBuscar.Location = new Point(15, 15);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(58, 19);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 10F);
            txtBuscar.Location = new Point(15, 40);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(300, 25);
            txtBuscar.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(52, 73, 94);
            lblTitulo.Location = new Point(30, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(318, 45);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Inscripción a Cursos"; // <-- CORREGIDO
            // 
            // FormInscripcionAlumno
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1250, 750);
            Controls.Add(panelPrincipal);
            Name = "FormInscripcionAlumno";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inscripción a Cursos"; // <-- CORREGIDO
            Load += FormInscripcionAlumno_Load_1;
            panelPrincipal.ResumeLayout(false);
            panelPrincipal.PerformLayout();
            panelFiltros.ResumeLayout(false);
            panelFiltros.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.ComboBox cmbAnio;
        private System.Windows.Forms.Label lblDisponibilidad;
        private System.Windows.Forms.ComboBox cmbDisponibilidad;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.FlowLayoutPanel flowPanelCursos;
        private System.Windows.Forms.Button btnVolver;
    }
}