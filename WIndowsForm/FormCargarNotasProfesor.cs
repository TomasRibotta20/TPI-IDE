using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WIndowsForm
{
    public partial class FormCargarNotasProfesor : Form
    {
        private readonly int _personaId;
        private readonly Form _menuAnterior;
        private readonly InscripcionApiClient _inscripcionApiClient;
        private readonly DocenteCursoApiClient _docenteCursoApiClient;
        private List<DocenteCursoDto>? _cursosAsignados;
        private List<AlumnoCursoDto>? _inscripcionesActuales;

        public FormCargarNotasProfesor(int personaId, Form menuAnterior)
        {
            _personaId = personaId;
            _menuAnterior = menuAnterior;
            _inscripcionApiClient = new InscripcionApiClient();
            _docenteCursoApiClient = new DocenteCursoApiClient();
            
            InitializeComponent();
            
            // Configurar eventos
            cmbCurso.SelectedIndexChanged += CmbCurso_SelectedIndexChanged;
            btnGuardar.Click += BtnGuardar_Click;
            btnVolver.Click += BtnVolver_Click;
            dgvAlumnos.CellClick += DgvAlumnos_CellClick;
            dgvAlumnos.CellEndEdit += DgvAlumnos_CellEndEdit;
            
            this.Load += FormCargarNotasProfesor_Load;
        }

        private async void FormCargarNotasProfesor_Load(object? sender, EventArgs e)
        {
            await CargarCursosAsync();
        }

        private async System.Threading.Tasks.Task CargarCursosAsync()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                var asignacionesEnumerable = await _docenteCursoApiClient.GetByDocenteIdAsync(_personaId);
                _cursosAsignados = asignacionesEnumerable.ToList();
                
                if (_cursosAsignados != null && _cursosAsignados.Any())
                {
                    cmbCurso.DisplayMember = "Display";
                    cmbCurso.ValueMember = "Value";
                    cmbCurso.DataSource = _cursosAsignados.Select(a => new CursoComboItem
                    {
                        Value = a.IdCurso,
                        Display = $"{a.NombreMateria} - {a.DescComision} ({a.AnioCalendario}) - Cargo: {a.CargoDescripcion}"
                    }).ToList();
                }
                else
                {
                    MessageBox.Show(
                        "No tienes cursos asignados.\n\n" +
                        "Un administrador debe asignarte cursos desde el menú:\n" +
                        "Profesor → Gestionar Docentes por Curso", 
                        "Sin cursos asignados", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                    _menuAnterior.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar cursos: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _menuAnterior.Show();
                this.Close();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private async void CmbCurso_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbCurso.SelectedValue == null) return;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                int cursoId = (int)cmbCurso.SelectedValue;
                _inscripcionesActuales = await _inscripcionApiClient.GetByCursoIdAsync(cursoId);
                
                if (_inscripcionesActuales != null && _inscripcionesActuales.Any())
                {
                    ConfigurarGridAlumnos();
                }
                else
                {
                    dgvAlumnos.DataSource = null;
                    dgvAlumnos.Rows.Clear();
                    dgvAlumnos.Columns.Clear();
                    MessageBox.Show("No hay alumnos inscriptos en este curso.", 
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar alumnos: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void ConfigurarGridAlumnos()
        {
            dgvAlumnos.Columns.Clear();
            dgvAlumnos.Rows.Clear();
            dgvAlumnos.AutoGenerateColumns = false;

            dgvAlumnos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Alumno",
                HeaderText = "Alumno",
                ReadOnly = true,
                FillWeight = 40
            });

            dgvAlumnos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Legajo",
                HeaderText = "Legajo",
                ReadOnly = true,
                FillWeight = 15
            });

            dgvAlumnos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Condicion",
                HeaderText = "Condición (Click para editar)",
                FillWeight = 20,
                ReadOnly = false
            });

            dgvAlumnos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nota",
                HeaderText = "Nota (1-10)",
                FillWeight = 15,
                ReadOnly = false
            });

            dgvAlumnos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdInscripcion",
                Visible = false
            });

            if (_inscripcionesActuales != null && _inscripcionesActuales.Any())
            {
                foreach (var inscripcion in _inscripcionesActuales)
                {
                    var index = dgvAlumnos.Rows.Add();
                    var row = dgvAlumnos.Rows[index];
                    
                    row.Cells["Alumno"].Value = $"{inscripcion.ApellidoAlumno}, {inscripcion.NombreAlumno}";
                    row.Cells["Legajo"].Value = inscripcion.LegajoAlumno;
                    row.Cells["Condicion"].Value = ObtenerTextoCondicion(inscripcion.Condicion);
                    row.Cells["Nota"].Value = inscripcion.Nota;
                    row.Cells["IdInscripcion"].Value = inscripcion.IdInscripcion;
                    
                    // Solo alumnos promocionales pueden tener nota editable
                    if (inscripcion.Condicion != CondicionAlumnoDto.Promocional)
                    {
                        row.Cells["Nota"].ReadOnly = true;
                        row.Cells["Nota"].Style.BackColor = Color.LightGray;
                        row.Cells["Nota"].Value = "";
                    }
                }
            }
        }

        private void DgvAlumnos_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            
            if (dgvAlumnos.Columns[e.ColumnIndex].Name == "Condicion")
            {
                var currentValue = dgvAlumnos.Rows[e.RowIndex].Cells["Condicion"].Value?.ToString() ?? "Regular";
                
                using (var form = new Form())
                {
                    form.Text = "Seleccionar Condición";
                    form.Size = new Size(300, 200);
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.FormBorderStyle = FormBorderStyle.FixedDialog;
                    form.MaximizeBox = false;
                    form.MinimizeBox = false;

                    var listBox = new ListBox
                    {
                        Location = new Point(20, 20),
                        Size = new Size(240, 80),
                        Font = new Font("Segoe UI", 11)
                    };
                    listBox.Items.Add("Regular");
                    listBox.Items.Add("Promocional");
                    listBox.Items.Add("Libre");
                    listBox.SelectedItem = currentValue;

                    var btnOk = new Button
                    {
                        Text = "Aceptar",
                        Location = new Point(100, 110),
                        Size = new Size(80, 30),
                        DialogResult = DialogResult.OK
                    };

                    form.Controls.Add(listBox);
                    form.Controls.Add(btnOk);
                    form.AcceptButton = btnOk;

                    if (form.ShowDialog() == DialogResult.OK && listBox.SelectedItem != null)
                    {
                        dgvAlumnos.Rows[e.RowIndex].Cells["Condicion"].Value = listBox.SelectedItem.ToString();
                    }
                }
            }
        }

        private void DgvAlumnos_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            if (dgvAlumnos.Columns[e.ColumnIndex].Name == "Condicion")
            {
                var value = dgvAlumnos.Rows[e.RowIndex].Cells["Condicion"].Value?.ToString();
                if (value != null && 
                    value != "Regular" && 
                    value != "Promocional" && 
                    value != "Libre")
                {
                    MessageBox.Show("Condición inválida. Use: Regular, Promocional o Libre", 
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvAlumnos.Rows[e.RowIndex].Cells["Condicion"].Value = "Regular";
                }
            }
        }

        private string ObtenerTextoCondicion(CondicionAlumnoDto condicion)
        {
            return condicion switch
            {
                CondicionAlumnoDto.Promocional => "Promocional",
                CondicionAlumnoDto.Regular => "Regular",
                CondicionAlumnoDto.Libre => "Libre",
                _ => "Regular"
            };
        }

        private CondicionAlumnoDto ObtenerCondicionDto(string texto)
        {
            return texto switch
            {
                "Promocional" => CondicionAlumnoDto.Promocional,
                "Regular" => CondicionAlumnoDto.Regular,
                "Libre" => CondicionAlumnoDto.Libre,
                _ => CondicionAlumnoDto.Regular
            };
        }

        private async void BtnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                var cambios = 0;

                foreach (DataGridViewRow row in dgvAlumnos.Rows)
                {
                    if (row.Cells["IdInscripcion"].Value == null) continue;
                    
                    int idInscripcion = Convert.ToInt32(row.Cells["IdInscripcion"].Value);
                    string condicionTexto = row.Cells["Condicion"].Value?.ToString() ?? "Regular";
                    var condicion = ObtenerCondicionDto(condicionTexto);
                    
                    int? nota = null;
                    // Solo procesar nota si es promocional
                    if (condicion == CondicionAlumnoDto.Promocional)
                    {
                        if (row.Cells["Nota"].Value != null && 
                            int.TryParse(row.Cells["Nota"].Value.ToString(), out int notaInt))
                        {
                            if (notaInt >= 6 && notaInt <= 10)
                                nota = notaInt;
                            else
                            {
                                MessageBox.Show($"La nota debe estar entre 6 y 10 para alumnos promocionales (Fila {row.Index + 1})", 
                                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                continue;
                            }
                        }
                    }

                    await _inscripcionApiClient.ActualizarCondicionYNotaAsync(idInscripcion, condicion, nota);
                    cambios++;
                }

                MessageBox.Show($"Se actualizaron {cambios} registros exitosamente.", 
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (cmbCurso.SelectedValue != null)
                {
                    int cursoId = (int)cmbCurso.SelectedValue;
                    _inscripcionesActuales = await _inscripcionApiClient.GetByCursoIdAsync(cursoId);
                    ConfigurarGridAlumnos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar cambios: {ex.Message}", 
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

        private class CursoComboItem
        {
            public int Value { get; set; }
            public string Display { get; set; } = string.Empty;
        }
    }
}