using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WIndowsForm
{
    public partial class FormMisCursosProfesor : Form
    {
        private readonly int _personaId;
        private readonly DocenteCursoApiClient _docenteCursoApiClient;

        public FormMisCursosProfesor(int personaId)
        {
            _personaId = personaId;
            _docenteCursoApiClient = new DocenteCursoApiClient();
            InitializeComponent();
            ConfigurarEventos();
            this.Load += FormMisCursosProfesor_Load;
        }

        private void ConfigurarEventos()
        {
            btnActualizar.Click += async (s, e) => await CargarMisCursosAsync();
            btnVolver.Click += BtnVolver_Click;
        }

        private async void FormMisCursosProfesor_Load(object? sender, EventArgs e)
        {
            await CargarMisCursosAsync();
        }

        private async System.Threading.Tasks.Task CargarMisCursosAsync()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                // Obtener cursos asignados al profesor a través de docentes_cursos
                var asignaciones = await _docenteCursoApiClient.GetByDocenteIdAsync(_personaId);
                
                if (asignaciones == null || !asignaciones.Any())
                {
                    MessageBox.Show("No tienes cursos asignados.\n\nUn administrador debe asignarte cursos desde el menú 'Gestionar Docentes por Curso'.", 
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvMisCursos.DataSource = null;
                    
                    // Regresar al menú de profesor
                    var menuProfesor = new MenuProfesor();
                    menuProfesor.Show();
                    this.Close();
                    return;
                }

                // Preparar datos para mostrar
                var cursosData = asignaciones.Select(a => new
                {
                    IdDictado = a.IdDictado,
                    IdCurso = a.IdCurso,
                    Materia = a.NombreMateria ?? "N/A",
                    Comision = a.DescComision ?? "N/A",
                    Anio = a.AnioCalendario ?? 0,
                    Cargo = a.CargoDescripcion,
                    DescripcionCurso = a.DescripcionCurso
                }).ToList();

                dgvMisCursos.DataSource = cursosData;
                
                dgvMisCursos.Columns["IdDictado"].Visible = false;
                dgvMisCursos.Columns["IdCurso"].Visible = false;
                dgvMisCursos.Columns["Materia"].HeaderText = "Materia";
                dgvMisCursos.Columns["Comision"].HeaderText = "Comisión";
                dgvMisCursos.Columns["Anio"].HeaderText = "Año";
                dgvMisCursos.Columns["Cargo"].HeaderText = "Cargo";
                dgvMisCursos.Columns["DescripcionCurso"].HeaderText = "Descripción Completa";

                // Colorear filas según cargo
                foreach (DataGridViewRow row in dgvMisCursos.Rows)
                {
                    string cargo = row.Cells["Cargo"].Value?.ToString() ?? "";
                    if (cargo == "Jefe de Cátedra")
                        row.DefaultCellStyle.BackColor = Color.FromArgb(200, 230, 255); // Azul claro
                    else if (cargo == "Titular")
                        row.DefaultCellStyle.BackColor = Color.FromArgb(200, 255, 200); // Verde claro
                    else if (cargo == "Auxiliar")
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 200); // Amarillo claro
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

        private void BtnVolver_Click(object? sender, EventArgs e)
        {
            var menuProfesor = new MenuProfesor();
            menuProfesor.Show();
            this.Close();
        }
    }
}