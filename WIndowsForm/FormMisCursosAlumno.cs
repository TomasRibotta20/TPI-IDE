using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WIndowsForm
{
    public partial class FormMisCursosAlumno : Form
    {
        private readonly int _personaId;
        private readonly InscripcionApiClient _inscripcionApiClient;

        public FormMisCursosAlumno(int personaId)
        {
            _personaId = personaId;
            _inscripcionApiClient = new InscripcionApiClient();
            InitializeComponent();
            ConfigurarEventos();
            this.Load += FormMisCursosAlumno_Load;
        }

        private void ConfigurarEventos()
        {
            btnActualizar.Click += async (s, e) => await CargarMisCursosAsync();
            btnVolver.Click += BtnVolver_Click;
        }

        private async void FormMisCursosAlumno_Load(object? sender, EventArgs e)
        {
            await CargarMisCursosAsync();
        }

        private async System.Threading.Tasks.Task CargarMisCursosAsync()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                // Obtener inscripciones del alumno
                var inscripciones = await _inscripcionApiClient.GetByAlumnoIdAsync(_personaId);
                
                if (inscripciones == null || !inscripciones.Any())
                {
                    MessageBox.Show("No tienes inscripciones registradas.", 
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvMisCursos.DataSource = null;
                    return;
                }

                // Preparar datos para el grid
                var cursosData = inscripciones.Select(i => new
                {
                    IdInscripcion = i.IdInscripcion,
                    Curso = i.DescripcionCurso ?? "N/A",
                    Condicion = ObtenerTextoCondicion(i.Condicion),
                    Nota = i.Nota.HasValue ? i.Nota.Value.ToString() : "Sin nota",
                    Estado = DeterminarEstado(i.Condicion, i.Nota)
                }).ToList();

                dgvMisCursos.DataSource = cursosData;
                
                // Configurar columnas
                dgvMisCursos.Columns["IdInscripcion"].Visible = false;
                dgvMisCursos.Columns["Curso"].HeaderText = "Curso";
                dgvMisCursos.Columns["Condicion"].HeaderText = "Condición";
                dgvMisCursos.Columns["Nota"].HeaderText = "Nota";
                dgvMisCursos.Columns["Estado"].HeaderText = "Estado";

                // Colorear filas según condición
                foreach (DataGridViewRow row in dgvMisCursos.Rows)
                {
                    var condicion = row.Cells["Condicion"].Value?.ToString();
                    switch (condicion)
                    {
                        case "Promocional":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(200, 247, 197); // Verde claro
                            break;
                        case "Regular":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 250, 205); // Amarillo claro
                            break;
                        case "Libre":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 224, 224); // Rojo claro
                            break;
                    }
                }
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

        private string ObtenerTextoCondicion(CondicionAlumnoDto condicion)
        {
            return condicion switch
            {
                CondicionAlumnoDto.Promocional => "Promocional",
                CondicionAlumnoDto.Regular => "Regular",
                CondicionAlumnoDto.Libre => "Libre",
                _ => "N/A"
            };
        }

        private string DeterminarEstado(CondicionAlumnoDto condicion, int? nota)
        {
            if (condicion == CondicionAlumnoDto.Promocional)
                return "Aprobado";
            else if (condicion == CondicionAlumnoDto.Regular && nota.HasValue && nota >= 6)
                return "Aprobado";
            else if (condicion == CondicionAlumnoDto.Regular)
                return "Pendiente de examen";
            else if (condicion == CondicionAlumnoDto.Libre)
                return "Debe recursar";
            
            return "En curso";
        }

        private void BtnVolver_Click(object? sender, EventArgs e)
        {
            var menuAlumno = new MenuAlumno();
            menuAlumno.Show();
            this.Close();
        }
    }
}