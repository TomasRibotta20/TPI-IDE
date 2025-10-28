using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WIndowsForm
{
    public partial class FormEditarDocenteCurso : Form
    {
        private List<CursoDto> _cursos;
        private List<PersonaDto> _profesores;
        private DocenteCursoDto? _asignacionExistente;

        public DocenteCursoCreateDto? AsignacionCreada { get; private set; }

        public FormEditarDocenteCurso(List<CursoDto> cursos, List<PersonaDto> profesores, DocenteCursoDto? asignacionExistente = null)
        {
            _cursos = cursos;
            _profesores = profesores;
            _asignacionExistente = asignacionExistente;

            InitializeComponent();
            ConfigurarFormulario();
            CargarDatos();
        }

        private void ConfigurarFormulario()
        {
            // Configurar título según el modo
            string titulo = _asignacionExistente == null ? "Nueva Asignación" : "Editar Asignación";
            this.Text = titulo;
            lblTitulo.Text = titulo;
            
            // Configurar eventos
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
        }

        private void CargarDatos()
        {
            // Cargar cursos
            cmbCurso.Items.Clear();
            foreach (var curso in _cursos.OrderBy(c => c.NombreMateria))
            {
                var descripcion = $"{curso.NombreMateria} - {curso.DescComision} ({curso.AnioCalendario})";
                cmbCurso.Items.Add(new { Display = descripcion, Value = curso.IdCurso });
            }
            cmbCurso.DisplayMember = "Display";
            cmbCurso.ValueMember = "Value";

            // Cargar profesores
            cmbProfesor.Items.Clear();
            foreach (var profesor in _profesores.OrderBy(p => p.Apellido).ThenBy(p => p.Nombre))
            {
                var descripcion = $"{profesor.Apellido}, {profesor.Nombre} (Legajo: {profesor.Legajo})";
                cmbProfesor.Items.Add(new { Display = descripcion, Value = profesor.Id });
            }
            cmbProfesor.DisplayMember = "Display";
            cmbProfesor.ValueMember = "Value";

            // Cargar cargos
            cmbCargo.Items.Clear();
            cmbCargo.Items.Add(new { Display = "Jefe de Cátedra", Value = TipoCargoDto.JefeDeCatedra });
            cmbCargo.Items.Add(new { Display = "Titular", Value = TipoCargoDto.Titular });
            cmbCargo.Items.Add(new { Display = "Auxiliar", Value = TipoCargoDto.Auxiliar });
            cmbCargo.DisplayMember = "Display";
            cmbCargo.ValueMember = "Value";

            // Si es edición, seleccionar valores existentes
            if (_asignacionExistente != null)
            {
                for (int i = 0; i < cmbCurso.Items.Count; i++)
                {
                    dynamic item = cmbCurso.Items[i];
                    if (item.Value == _asignacionExistente.IdCurso)
                    {
                        cmbCurso.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < cmbProfesor.Items.Count; i++)
                {
                    dynamic item = cmbProfesor.Items[i];
                    if (item.Value == _asignacionExistente.IdDocente)
                    {
                        cmbProfesor.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < cmbCargo.Items.Count; i++)
                {
                    dynamic item = cmbCargo.Items[i];
                    if (item.Value.Equals(_asignacionExistente.Cargo))
                    {
                        cmbCargo.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones
                if (cmbCurso?.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un curso.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbCurso?.Focus();
                    return;
                }

                if (cmbProfesor?.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un profesor.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbProfesor?.Focus();
                    return;
                }

                if (cmbCargo?.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un cargo.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbCargo?.Focus();
                    return;
                }

                // Crear DTO
                dynamic cursoItem = cmbCurso.SelectedItem;
                dynamic profesorItem = cmbProfesor.SelectedItem;
                dynamic cargoItem = cmbCargo.SelectedItem;

                AsignacionCreada = new DocenteCursoCreateDto
                {
                    IdCurso = cursoItem.Value,
                    IdDocente = profesorItem.Value,
                    Cargo = cargoItem.Value
                };

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}