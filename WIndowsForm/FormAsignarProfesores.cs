using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WIndowsForm
{
    public partial class FormAsignarProfesores : Form
    {
        private readonly Form _menuAnterior;
        private readonly CursoApiClient _cursoApiClient;
        private readonly PersonaApiClient _personaApiClient;

        public FormAsignarProfesores(Form menuAnterior)
        {
            _menuAnterior = menuAnterior;
            _cursoApiClient = new CursoApiClient();
            _personaApiClient = new PersonaApiClient();
            
            InitializeComponent();
            
            // Configurar eventos
            cmbCurso.SelectedIndexChanged += CmbCurso_SelectedIndexChanged;
            btnAsignar.Click += BtnAsignar_Click;
            btnVolver.Click += BtnVolver_Click;
            
            CargarDatosAsync();
        }

        private async System.Threading.Tasks.Task CargarDatosAsync()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                // Cargar cursos
                var cursosEnumerable = await _cursoApiClient.GetAllAsync();
                var cursos = cursosEnumerable.ToList();
                
                if (cursos != null && cursos.Any())
                {
                    cmbCurso.DataSource = cursos.Select(c => new
                    {
                        Value = c.IdCurso,
                        Display = $"{c.Nombre} - {c.Comision} ({c.AnioCalendario})"
                    }).ToList();
                    
                    cmbCurso.DisplayMember = "Display";
                    cmbCurso.ValueMember = "Value";
                }

                // Cargar profesores
                var personas = await _personaApiClient.GetAllAsync();
                var profesores = personas?.Where(p => p.TipoPersona == TipoPersonaDto.Profesor).ToList();
                
                if (profesores != null && profesores.Any())
                {
                    cmbProfesor.DataSource = profesores.Select(p => new
                    {
                        Value = p.Id,
                        Display = $"{p.Apellido}, {p.Nombre} (Leg: {p.Legajo})"
                    }).ToList();
                    
                    cmbProfesor.DisplayMember = "Display";
                    cmbProfesor.ValueMember = "Value";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void CmbCurso_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbCurso.SelectedValue != null)
            {
                lblCursoInfo.Text = "Nota: La funcionalidad de asignar profesores está en preparación.\n" +
                                   "Requiere extender el modelo Curso para incluir profesores.";
                
                dgvProfesoresAsignados.DataSource = null;
            }
        }

        private async void BtnAsignar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (cmbCurso.SelectedValue == null || cmbProfesor.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un curso y un profesor.", 
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show(
                    "Funcionalidad en desarrollo.\n\n" +
                    "Para implementar completamente esta función, es necesario:\n" +
                    "1. Agregar tabla CursosProfesores en la base de datos\n" +
                    "2. Crear endpoints en la API\n" +
                    "3. Implementar lógica de asignación",
                    "En Desarrollo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnVolver_Click(object? sender, EventArgs e)
        {
            _menuAnterior.Show();
            this.Close();
        }
    }
}