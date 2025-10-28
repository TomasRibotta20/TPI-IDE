using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WIndowsForm
{
    public partial class FormGestionarDocentesCurso : Form
    {
        private readonly DocenteCursoApiClient _docenteCursoApiClient;
        private readonly CursoApiClient _cursoApiClient;
        private readonly PersonaApiClient _personaApiClient;
        private BindingList<DocenteCursoDto> _asignaciones = new BindingList<DocenteCursoDto>();
        private List<CursoDto> _cursos = new List<CursoDto>();
        private List<PersonaDto> _profesores = new List<PersonaDto>();

        public FormGestionarDocentesCurso()
        {
            InitializeComponent();
            _docenteCursoApiClient = new DocenteCursoApiClient();
            _cursoApiClient = new CursoApiClient();
            _personaApiClient = new PersonaApiClient();

            ConfigurarInterfaz();
            this.Load += FormGestionarDocentesCurso_Load;
        }

        private void ConfigurarInterfaz()
        {
            // Aplicar estilos personalizados
            FormStyles.StyleComboBox(cmbFiltroCurso);
            FormStyles.StyleDataGridView(dataGridViewAsignaciones);
            
            // Configurar eventos
            cmbFiltroCurso.SelectedIndexChanged += CmbFiltroCurso_SelectedIndexChanged;
            btnMostrarTodos.Click += async (s, e) => await CargarAsignacionesAsync();
            btnNuevo.Click += async (s, e) => await CrearNuevaAsignacion();
            btnEditar.Click += async (s, e) => await EditarAsignacionSeleccionada(dataGridViewAsignaciones);
            btnEliminar.Click += async (s, e) => await EliminarAsignacionSeleccionada(dataGridViewAsignaciones);
            btnVolver.Click += BtnVolver_Click;
            
            // Configurar DataGridView
            ConfigurarDataGridView(dataGridViewAsignaciones);
        }

        private void ConfigurarDataGridView(DataGridView dgv)
        {
            dgv.Columns.Clear();

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdDictado",
                HeaderText = "ID",
                Width = 60,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreCompleto",
                HeaderText = "Docente",
                Width = 250
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CargoDescripcion",
                HeaderText = "Cargo",
                Width = 150
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DescripcionCurso",
                HeaderText = "Curso - Comisión (Año)",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                MinimumWidth = 300
            });

            dgv.DataSource = _asignaciones;
        }

        private async void FormGestionarDocentesCurso_Load(object sender, EventArgs e)
        {
            await CargarDatosInicialesAsync();
        }

        private async Task CargarDatosInicialesAsync()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Cargar cursos
                var cursosEnumerable = await _cursoApiClient.GetAllAsync();
                _cursos = cursosEnumerable.ToList();

                var cmbFiltroCurso = this.Controls.Find("cmbFiltroCurso", true).FirstOrDefault() as ComboBox;
                if (cmbFiltroCurso != null)
                {
                    cmbFiltroCurso.DataSource = null;
                    cmbFiltroCurso.Items.Clear();
                    cmbFiltroCurso.Items.Add(new { Display = "-- Todos los cursos --", Value = 0 });
                    
                    foreach (var curso in _cursos.OrderBy(c => c.NombreMateria))
                    {
                        var descripcion = $"{curso.NombreMateria} - {curso.DescComision} ({curso.AnioCalendario})";
                        cmbFiltroCurso.Items.Add(new { Display = descripcion, Value = curso.IdCurso });
                    }
                    
                    cmbFiltroCurso.DisplayMember = "Display";
                    cmbFiltroCurso.ValueMember = "Value";
                    cmbFiltroCurso.SelectedIndex = 0;
                }

                // Cargar profesores
                var personasEnumerable = await _personaApiClient.GetAllAsync();
                _profesores = personasEnumerable
                    .Where(p => p.TipoPersona == TipoPersonaDto.Profesor)
                    .ToList();

                // Cargar asignaciones
                await CargarAsignacionesAsync();
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

        private async Task CargarAsignacionesAsync()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var asignaciones = await _docenteCursoApiClient.GetAllAsync();

                _asignaciones.Clear();
                foreach (var asignacion in asignaciones)
                {
                    _asignaciones.Add(asignacion);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar asignaciones: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private async void CmbFiltroCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = sender as ComboBox;
            if (combo == null || combo.SelectedItem == null) return;

            try
            {
                dynamic selectedItem = combo.SelectedItem;
                int cursoId = selectedItem.Value;

                if (cursoId == 0)
                {
                    await CargarAsignacionesAsync();
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var asignaciones = await _docenteCursoApiClient.GetByCursoIdAsync(cursoId);

                    _asignaciones.Clear();
                    foreach (var asignacion in asignaciones)
                    {
                        _asignaciones.Add(asignacion);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private async Task CrearNuevaAsignacion()
        {
            var formEditar = new FormEditarDocenteCurso(_cursos, _profesores);
            var resultado = formEditar.ShowDialog();

            if (resultado == DialogResult.OK && formEditar.AsignacionCreada != null)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    await _docenteCursoApiClient.CreateAsync(formEditar.AsignacionCreada);
                    await CargarAsignacionesAsync();
                    MessageBox.Show("Asignación creada exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al crear asignación: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private async Task EditarAsignacionSeleccionada(DataGridView dgv)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una asignación para editar.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var asignacionSeleccionada = (DocenteCursoDto)dgv.SelectedRows[0].DataBoundItem;
            var formEditar = new FormEditarDocenteCurso(_cursos, _profesores, asignacionSeleccionada);
            var resultado = formEditar.ShowDialog();

            if (resultado == DialogResult.OK && formEditar.AsignacionCreada != null)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    await _docenteCursoApiClient.UpdateAsync(
                        asignacionSeleccionada.IdDictado,
                        formEditar.AsignacionCreada);
                    await CargarAsignacionesAsync();
                    MessageBox.Show("Asignación actualizada exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar asignación: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private async Task EliminarAsignacionSeleccionada(DataGridView dgv)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una asignación para eliminar.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var asignacionSeleccionada = (DocenteCursoDto)dgv.SelectedRows[0].DataBoundItem;

            var confirmResult = MessageBox.Show(
                $"¿Está seguro de que desea eliminar la asignación de {asignacionSeleccionada.NombreCompleto} " +
                $"como {asignacionSeleccionada.CargoDescripcion} en {asignacionSeleccionada.DescripcionCurso}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    await _docenteCursoApiClient.DeleteAsync(asignacionSeleccionada.IdDictado);
                    await CargarAsignacionesAsync();
                    MessageBox.Show("Asignación eliminada exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar asignación: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            // Mostrar el menú principal y cerrar este formulario
            var menuPrincipal = Application.OpenForms.OfType<MenuPrincipal>().FirstOrDefault();
            
            if (menuPrincipal != null)
            {
                menuPrincipal.Show();
                menuPrincipal.BringToFront();
            }
            else
            {
                // Si no existe, crear uno nuevo
                menuPrincipal = new MenuPrincipal();
                menuPrincipal.Show();
            }
            
            this.Close();
        }
    }
}