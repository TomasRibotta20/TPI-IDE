using System;
using System.Drawing;
using System.Windows.Forms;
using API.Clients;
using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace WIndowsForm
{
    public partial class FormReporteCursos : Form
    {
        private readonly InscripcionApiClient _inscripcionApiClient;
        private readonly CursoApiClient _cursoApiClient;
        private CursoDto? _cursoSeleccionado;
        private List<AlumnoCursoDto> _inscripcionesCursoSeleccionado = new List<AlumnoCursoDto>();
        
        public FormReporteCursos()
        {
            InitializeComponent();
            _inscripcionApiClient = new InscripcionApiClient();
            _cursoApiClient = new CursoApiClient();
            
            ConfigurarEventos();
            this.Load += FormReporteCursos_Load;
        }

        private void ConfigurarEventos()
        {
            btnExportar.Click += BtnExportar_Click;
            btnCerrar.Click += (s, e) => this.Close();
            panelGraficoCondiciones.Paint += (s, e) => DibujarGraficoCondicionesPorCurso();
            panelGraficoOcupacion.Paint += (s, e) => {
                if (_cursoSeleccionado != null)
                    DibujarGraficoOcupacionCurso(_cursoSeleccionado);
            };
        }

        private async void BtnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var cursos = await _cursoApiClient.GetAllAsync();
                PdfHelper.ExportarCursosPDF(cursos);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private async void FormReporteCursos_Load(object sender, EventArgs e)
        {
            await CargarReporteAsync();
        }

        private async Task CargarReporteAsync()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                var cursos = await _cursoApiClient.GetAllAsync();
                
                if (cursos == null || !cursos.Any())
                {
                    MessageBox.Show("No hay cursos disponibles para generar el reporte.\n\nUn administrador debe crear cursos desde el menú principal.", 
                        "Sin Cursos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }
                
                var cursosList = new List<object>();
                foreach (var curso in cursos)
                {
                    var disponible = curso.Cupo - (curso.InscriptosActuales ?? 0);
                    var porcentajeOcupacion = curso.Cupo > 0 ? ((curso.InscriptosActuales ?? 0) * 100.0 / curso.Cupo) : 0;
                    
                    cursosList.Add(new
                    {
                        IdCurso = curso.IdCurso,
                        Materia = curso.NombreMateria ?? "Sin Materia",
                        Comision = curso.DescComision ?? "Sin Comisión",
                        Anio = curso.AnioCalendario,
                        Cupo = curso.Cupo,
                        Inscriptos = curso.InscriptosActuales ?? 0,
                        Disponible = disponible,
                        PorcentajeOcupacion = $"{porcentajeOcupacion:F1}%",
                        Estado = disponible <= 0 ? "Completo" : disponible <= 5 ? "Casi Lleno" : "Disponible"
                    });
                }
                
                dataGridViewCursos.DataSource = cursosList;
                dataGridViewCursos.SelectionChanged += DataGridViewCursos_SelectionChanged;
                ConfigurarColoresGrid();
                
                if (cursos.Any())
                {
                    _cursoSeleccionado = cursos.First();
                    await ActualizarInformacionCursoSeleccionado();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar reporte: {ex.Message}");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private async void DataGridViewCursos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCursos.SelectedRows.Count > 0)
            {
                var row = dataGridViewCursos.SelectedRows[0];
                var idCurso = (int)row.Cells["IdCurso"].Value;
                
                try
                {
                    var cursos = await _cursoApiClient.GetAllAsync();
                    _cursoSeleccionado = cursos.FirstOrDefault(c => c.IdCurso == idCurso);
                    
                    if (_cursoSeleccionado != null)
                    {
                        await ActualizarInformacionCursoSeleccionado();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar datos del curso: {ex.Message}");
                }
            }
        }

        private async Task ActualizarInformacionCursoSeleccionado()
        {
            if (_cursoSeleccionado == null) return;

            try
            {
                _inscripcionesCursoSeleccionado = (await _inscripcionApiClient.GetInscripcionesByCursoAsync(_cursoSeleccionado.IdCurso)).ToList();
                
                var totalInscriptos = _inscripcionesCursoSeleccionado.Count;
                var disponibles = _cursoSeleccionado.Cupo - totalInscriptos;
                var promocionales = _inscripcionesCursoSeleccionado.Count(i => i.Condicion == CondicionAlumnoDto.Promocional);
                var regulares = _inscripcionesCursoSeleccionado.Count(i => i.Condicion == CondicionAlumnoDto.Regular);
                var libres = _inscripcionesCursoSeleccionado.Count(i => i.Condicion == CondicionAlumnoDto.Libre);

                lblTotalInscripciones.Text = $"Inscriptos en este curso: {totalInscriptos}";
                lblPromocionales.Text = $"Promocionales: {promocionales}";
                lblRegulares.Text = $"Regulares: {regulares}";
                lblLibres.Text = $"Libres: {libres}";
                lblTitulo.Text = $"REPORTE DEL CURSO: {_cursoSeleccionado.NombreMateria ?? "Sin Materia"} - {_cursoSeleccionado.DescComision ?? "Sin Comisión"}";
                
                DibujarGraficoCondicionesPorCurso();
                DibujarGraficoOcupacionCurso(_cursoSeleccionado);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar información del curso: {ex.Message}");
            }
        }

        private void ConfigurarColoresGrid()
        {
            dataGridViewCursos.CellFormatting += (sender, e) => {
                if (e.ColumnIndex == dataGridViewCursos.Columns["Estado"].Index && e.Value != null)
                {
                    var estado = e.Value.ToString();
                    switch (estado)
                    {
                        case "Completo":
                            e.CellStyle.BackColor = Color.LightCoral;
                            e.CellStyle.ForeColor = Color.DarkRed;
                            break;
                        case "Casi Lleno":
                            e.CellStyle.BackColor = Color.LightYellow;
                            e.CellStyle.ForeColor = Color.DarkOrange;
                            break;
                        case "Disponible":
                            e.CellStyle.BackColor = Color.LightGreen;
                            e.CellStyle.ForeColor = Color.DarkGreen;
                            break;
                    }
                }
            };
        }

        private void DibujarGraficoCondicionesPorCurso()
        {
            if (_inscripcionesCursoSeleccionado == null || !_inscripcionesCursoSeleccionado.Any())
            {
                using (var g = panelGraficoCondiciones.CreateGraphics())
                {
                    g.Clear(Color.White);
                    g.DrawString("No hay inscriptos en este curso", new Font("Segoe UI", 12), Brushes.Gray, 
                        panelGraficoCondiciones.Width / 2 - 100, panelGraficoCondiciones.Height / 2);
                }
                return;
            }

            var promocionales = _inscripcionesCursoSeleccionado.Count(i => i.Condicion == CondicionAlumnoDto.Promocional);
            var regulares = _inscripcionesCursoSeleccionado.Count(i => i.Condicion == CondicionAlumnoDto.Regular);
            var libres = _inscripcionesCursoSeleccionado.Count(i => i.Condicion == CondicionAlumnoDto.Libre);

            using (var g = panelGraficoCondiciones.CreateGraphics())
            {
                g.Clear(Color.White);
                g.DrawString("Distribución de Condiciones", new Font("Segoe UI", 10, FontStyle.Bold), Brushes.Black, 10, 5);
                
                int y = 30;
                g.DrawString($"Promocionales: {promocionales}", new Font("Segoe UI", 9), Brushes.Green, 10, y);
                y += 20;
                g.DrawString($"Regulares: {regulares}", new Font("Segoe UI", 9), Brushes.Blue, 10, y);
                y += 20;
                g.DrawString($"Libres: {libres}", new Font("Segoe UI", 9), Brushes.Orange, 10, y);
            }
        }

        private void DibujarGraficoOcupacionCurso(CursoDto curso)
        {
            using (var g = panelGraficoOcupacion.CreateGraphics())
            {
                g.Clear(Color.White);
                
                if (curso == null)
                {
                    g.DrawString("Seleccione un curso", new Font("Segoe UI", 12), Brushes.Gray, 50, 50);
                    return;
                }
                
                var inscriptos = curso.InscriptosActuales ?? 0;
                var cupoTotal = curso.Cupo;
                var disponible = cupoTotal - inscriptos;
                var porcentaje = cupoTotal > 0 ? (inscriptos * 100.0 / cupoTotal) : 0;
                
                g.DrawString("Ocupación de Cupos", new Font("Segoe UI", 10, FontStyle.Bold), Brushes.Black, 10, 5);
                
                int y = 30;
                g.DrawString($"Inscriptos: {inscriptos}", new Font("Segoe UI", 9), Brushes.Blue, 10, y);
                y += 20;
                g.DrawString($"Disponible: {disponible}", new Font("Segoe UI", 9), Brushes.Green, 10, y);
                y += 20;
                g.DrawString($"Cupo Total: {cupoTotal}", new Font("Segoe UI", 9, FontStyle.Bold), Brushes.Black, 10, y);
                y += 20;
                g.DrawString($"Ocupación: {porcentaje:F1}%", new Font("Segoe UI", 9, FontStyle.Bold), 
                    porcentaje >= 80 ? Brushes.Red : Brushes.Green, 10, y);
            }
        }
    }
}