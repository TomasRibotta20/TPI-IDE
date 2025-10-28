using API.Auth.WindowsForms;
using API.Clients;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WIndowsForm
{
    public partial class MenuAlumno : Form
    {
        private readonly int _personaId;
        private readonly string _usuarioNombre;

        public MenuAlumno()
        {
            InitializeComponent();
            
            _personaId = WindowsFormsAuthService.GetCurrentPersonaId() ?? 0;
            _usuarioNombre = WindowsFormsAuthService.GetCurrentUserId().ToString() ?? "Usuario";
            
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            // Actualizar mensaje de bienvenida
            lblBienvenida.Text = $"Bienvenido, {_usuarioNombre}";

            // Botones principales estilo cards
            var btnMisCursos = CrearBotonCard(
                "Mis Cursos",
                "Ver cursos en los que estoy inscripto",
                Color.FromArgb(52, 152, 219),
                new Point(120, 70),
                BtnMisCursos_Click
            );

            var btnInscribirse = CrearBotonCard(
                "Inscribirse",
                "Inscribirse a nuevos cursos",
                Color.FromArgb(46, 204, 113),
                new Point(480, 70),
                BtnInscribirse_Click
            );

            // Boton de cerrar sesion
            var btnCerrarSesion = new Button
            {
                Text = "Cerrar Sesión",
                Size = new Size(200, 45),
                Location = new Point(350, 380),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.Click += BtnCerrarSesion_Click;

            mainPanel.Controls.Add(btnMisCursos);
            mainPanel.Controls.Add(btnInscribirse);
            mainPanel.Controls.Add(btnCerrarSesion);
        }

        private Panel CrearBotonCard(string titulo, string descripcion, Color colorFondo, Point ubicacion, EventHandler clickHandler)
        {
            var card = new Panel
            {
                Size = new Size(280, 180),
                Location = ubicacion,
                BackColor = colorFondo,
                Cursor = Cursors.Hand
            };

            var lblTituloCard = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 50),
                AutoSize = false,
                Size = new Size(240, 35),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblDescripcion = new Label
            {
                Text = descripcion,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(236, 240, 245),
                Location = new Point(20, 95),
                AutoSize = false,
                Size = new Size(240, 50),
                TextAlign = ContentAlignment.MiddleCenter
            };

            card.Controls.Add(lblTituloCard);
            card.Controls.Add(lblDescripcion);
            
            card.MouseEnter += (s, e) =>
            {
                card.BackColor = ControlPaint.Light(colorFondo, 0.2f);
            };
            card.MouseLeave += (s, e) =>
            {
                card.BackColor = colorFondo;
            };
            
            card.Click += clickHandler;
            lblTituloCard.Click += clickHandler;
            lblDescripcion.Click += clickHandler;

            return card;
        }

        private void MenuAlumno_Load(object sender, EventArgs e)
        {
            // Verificar que el alumno tenga PersonaId
            if (_personaId == 0)
            {
                MessageBox.Show("Error: No se pudo obtener la informacion del alumno.", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void BtnMisCursos_Click(object? sender, EventArgs e)
        {
            try
            {
                var formMisCursos = new FormMisCursosAlumno(_personaId);
                formMisCursos.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir Mis Cursos: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnInscribirse_Click(object? sender, EventArgs e)
        {
            try
            {
                var formInscribirse = new FormInscripcionAlumno(_personaId, this);
                formInscribirse.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir inscripcion: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnCerrarSesion_Click(object? sender, EventArgs e)
        {
            var result = MessageBox.Show("�Est� seguro que desea cerrar sesi�n?", 
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                var authService = AuthServiceProvider.Instance;
                await authService.LogoutAsync();
                
                // Cerrar el formulario actual sin cerrar la aplicaci�n
                this.Close();
            }
        }
    }
}
