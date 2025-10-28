using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WIndowsForm
{
    public partial class FormInscripcionAlumno : Form
    {
        private readonly int _personaId;
        private readonly Form _menuAnterior;
        private readonly CursoApiClient _cursoApiClient;
        private readonly InscripcionApiClient _inscripcionApiClient;
        private readonly PersonaApiClient _personaApiClient;

        private List<CursoDto>? _todosCursos;
        private List<int> _cursosInscriptos = new List<int>();

        public FormInscripcionAlumno(int personaId, Form menuAnterior)
        {
            _personaId = personaId;
            _menuAnterior = menuAnterior;
            _cursoApiClient = new CursoApiClient();
            _inscripcionApiClient = new InscripcionApiClient();
            _personaApiClient = new PersonaApiClient();

            InitializeComponent();
            ConfigurarEventos();
            this.Load += FormInscripcionAlumno_Load;
        }

        private void ConfigurarEventos()
        {
            txtBuscar.TextChanged += (s, e) => FiltrarCursos();
            cmbAnio.SelectedIndexChanged += (s, e) => FiltrarCursos();
            cmbDisponibilidad.SelectedIndex = 0;
            cmbDisponibilidad.SelectedIndexChanged += (s, e) => FiltrarCursos();
            btnActualizar.Click += async (s, e) => await CargarCursosDisponiblesAsync();
            btnVolver.Click += BtnVolver_Click;
        }

        private async void FormInscripcionAlumno_Load(object? sender, EventArgs e)
        {
            await CargarCursosDisponiblesAsync();
        }

        private async System.Threading.Tasks.Task CargarCursosDisponiblesAsync()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Obtener todos los cursos
                var cursosEnumerable = await _cursoApiClient.GetAllAsync();
                _todosCursos = cursosEnumerable.ToList();

                // Obtener inscripciones del alumno
                var misInscripciones = await _inscripcionApiClient.GetByAlumnoIdAsync(_personaId);
                _cursosInscriptos = misInscripciones?.Select(i => i.IdCurso).ToList() ?? new List<int>();

                // Cargar años en el combobox
                CargarAniosDisponibles();

                // Mostrar todos los cursos (ahora incluye los inscriptos con badge)
                FiltrarCursos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar cursos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void CargarAniosDisponibles()
        {
            if (_todosCursos == null || !_todosCursos.Any()) return;

            cmbAnio.Items.Clear();
            cmbAnio.Items.Add("Todos los años"); // <-- Corregido (en caso de que 'años' estuviera mal)

            var anios = _todosCursos.Select(c => c.AnioCalendario).Distinct().OrderBy(a => a);
            foreach (var anio in anios)
            {
                cmbAnio.Items.Add(anio);
            }

            cmbAnio.SelectedIndex = 0;
        }

        private void FiltrarCursos()
        {
            if (_todosCursos == null) return;

            var cursosFiltrados = _todosCursos.AsEnumerable();

            // Filtro de búsqueda
            var busqueda = txtBuscar.Text.ToLower().Trim();
            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                cursosFiltrados = cursosFiltrados.Where(c =>
                    c.Nombre.ToLower().Contains(busqueda) ||
                    c.Comision.ToLower().Contains(busqueda) ||
                    c.AnioCalendario.ToString().Contains(busqueda));
            }

            // Filtro de año
            if (cmbAnio.SelectedIndex > 0 && cmbAnio.SelectedItem != null)
            {
                var anioSeleccionado = (int)cmbAnio.SelectedItem;
                cursosFiltrados = cursosFiltrados.Where(c => c.AnioCalendario == anioSeleccionado);
            }

            // Filtro de disponibilidad
            if (cmbDisponibilidad.SelectedIndex > 0)
            {
                var filtro = cmbDisponibilidad.SelectedItem?.ToString();
                switch (filtro)
                {
                    case "Con cupo":
                        // Muestra cursos con cupo (inscriptos o no)
                        cursosFiltrados = cursosFiltrados.Where(c =>
                            (c.Cupo - c.InscriptosCount) > 0);
                        break;
                    case "Sin cupo":
                        // Muestra cursos sin cupo (inscriptos o no)
                        cursosFiltrados = cursosFiltrados.Where(c =>
                            (c.Cupo - c.InscriptosCount) <= 0);
                        break;
                    case "Inscripto":
                        // Solo muestra cursos donde ya estás inscripto
                        cursosFiltrados = cursosFiltrados.Where(c => _cursosInscriptos.Contains(c.IdCurso));
                        break;
                }
            }

            MostrarCursos(cursosFiltrados.ToList());
        }

        private void MostrarCursos(List<CursoDto> cursos)
        {
            flowPanelCursos.Controls.Clear();

            if (!cursos.Any())
            {
                var lblSinCursos = new Label
                {
                    Text = "No se encontraron cursos con los filtros seleccionados.", // <-- Corregido
                    Font = new Font("Segoe UI", 14),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Location = new Point(20, 20)
                };
                flowPanelCursos.Controls.Add(lblSinCursos);
                return;
            }

            foreach (var curso in cursos.OrderBy(c => c.Nombre).ThenBy(c => c.Comision))
            {
                var card = CrearCardCurso(curso);
                flowPanelCursos.Controls.Add(card);
            }
        }

        private Panel CrearCardCurso(CursoDto curso)
        {
            bool yaInscripto = _cursosInscriptos.Contains(curso.IdCurso);
            int inscriptos = curso.InscriptosCount;
            int cupo = curso.Cupo;
            int disponibles = cupo - inscriptos;

            var card = new Panel
            {
                Size = new Size(360, 190),
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand
            };

            // Determinar color según estado
            Color colorFondo;
            Color colorBorde = Color.Gray;

            if (yaInscripto)
            {
                colorFondo = Color.FromArgb(220, 237, 253); // Azul claro
                colorBorde = Color.FromArgb(52, 152, 219); // Azul
            }
            else if (disponibles > 5)
            {
                colorFondo = Color.FromArgb(200, 247, 197); // Verde claro
                colorBorde = Color.FromArgb(46, 204, 113); // Verde
            }
            else if (disponibles > 0)
            {
                colorFondo = Color.FromArgb(255, 250, 205); // Amarillo claro
                colorBorde = Color.FromArgb(243, 156, 18); // Amarillo
            }
            else
            {
                colorFondo = Color.FromArgb(255, 224, 224); // Rojo claro
                colorBorde = Color.FromArgb(231, 76, 60); // Rojo
            }

            card.BackColor = colorFondo;
            card.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(colorBorde, 3))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
                }
            };

            // Badge de estado (superior derecho)
            var lblBadge = new Label
            {
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(card.Width - 90, 10),
                Padding = new Padding(8, 4, 8, 4),
                TextAlign = ContentAlignment.MiddleCenter
            };

            if (yaInscripto)
            {
                lblBadge.Text = "INSCRIPTO";
                lblBadge.BackColor = Color.FromArgb(52, 152, 219);
                lblBadge.ForeColor = Color.White;
            }
            else if (disponibles <= 0)
            {
                lblBadge.Text = "SIN CUPO";
                lblBadge.BackColor = Color.FromArgb(231, 76, 60);
                lblBadge.ForeColor = Color.White;
            }
            else
            {
                lblBadge.Text = "DISPONIBLE";
                lblBadge.BackColor = Color.FromArgb(46, 204, 113);
                lblBadge.ForeColor = Color.White;
            }

            // Titulo del curso
            var lblNombre = new Label
            {
                Text = curso.Nombre,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 10),
                Size = new Size(250, 50),
                ForeColor = Color.FromArgb(52, 73, 94)
            };

            // Comisión
            var lblComision = new Label
            {
                Text = $"Comisión: {curso.Comision}", // <-- Corregido
                Font = new Font("Segoe UI", 10),
                Location = new Point(10, 65),
                Size = new Size(320, 20),
                ForeColor = Color.FromArgb(44, 62, 80)
            };

            // Información adicional
            var lblInfo = new Label
            {
                Text = $"Año: {curso.AnioCalendario}\n" + // <-- Corregido
                       $"Cupo: {inscriptos}/{cupo}\n" +
                       $"Disponibles: {disponibles}",
                Font = new Font("Segoe UI", 9),
                Location = new Point(10, 90),
                Size = new Size(320, 60),
                ForeColor = Color.FromArgb(44, 62, 80)
            };

            // Botón inscribirse o estado
            Button btnAccion;

            if (yaInscripto)
            {
                btnAccion = new Button
                {
                    Text = "Ya Inscripto",
                    Size = new Size(150, 35),
                    Location = new Point(10, 145),
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    BackColor = Color.FromArgb(52, 152, 219),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Enabled = false
                };
            }
            else if (disponibles > 0)
            {
                btnAccion = new Button
                {
                    Text = "Inscribirse",
                    Size = new Size(150, 35),
                    Location = new Point(10, 145),
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    BackColor = Color.FromArgb(46, 204, 113),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand
                };
                btnAccion.Click += async (s, e) => await InscribirseACurso(curso);
            }
            else
            {
                btnAccion = new Button
                {
                    Text = "Sin Cupo",
                    Size = new Size(150, 35),
                    Location = new Point(10, 145),
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    BackColor = Color.Gray,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Enabled = false
                };
            }

            btnAccion.FlatAppearance.BorderSize = 0;

            card.Controls.Add(lblBadge);
            card.Controls.Add(lblNombre);
            card.Controls.Add(lblComision);
            card.Controls.Add(lblInfo);
            card.Controls.Add(btnAccion);

            return card;
        }

        private async System.Threading.Tasks.Task InscribirseACurso(CursoDto curso)
        {
            try
            {
                var result = MessageBox.Show(
                    $"¿Confirma que desea inscribirse al curso?\n\n" + // <-- Corregido
                    $"Curso: {curso.Nombre}\n" +
                    $"Comisión: {curso.Comision}\n" + // <-- Corregido
                    $"Año: {curso.AnioCalendario}", // <-- Corregido
                    "Confirmar Inscripción", // <-- Corregido
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    var inscripcionDto = new AlumnoCursoDto
                    {
                        IdAlumno = _personaId,
                        IdCurso = curso.IdCurso
                        // Sin condición ni nota por defecto
                    };

                    await _inscripcionApiClient.CreateAsync(inscripcionDto);

                    MessageBox.Show("¡Inscripción exitosa!", // <-- Corregido
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information); // <-- Corregido

                    await CargarCursosDisponiblesAsync();
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                if (mensaje.Contains("already enrolled", StringComparison.OrdinalIgnoreCase))
                    mensaje = "Ya estás inscripto en este curso."; // <-- Corregido
                else if (mensaje.Contains("no capacity", StringComparison.OrdinalIgnoreCase))
                    mensaje = "No hay cupo disponible en este curso.";

                MessageBox.Show($"Error al inscribirse: {mensaje}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void BtnVolver_Click(object? sender, EventArgs e)
        {
            _menuAnterior.Show();
            this.Close();
        }

        private void FormInscripcionAlumno_Load_1(object sender, EventArgs e)
        {

        }
    }
}