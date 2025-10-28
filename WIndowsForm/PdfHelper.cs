using System;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using DTOs;
using System.Linq;

namespace WIndowsForm
{
    public static class PdfHelper
    {
        public static void ExportarCursosPDF(IEnumerable<CursoDto> cursos)
        {
            try
            {
                string fileName = null;
                var thread = new System.Threading.Thread(() =>
                {
                    var saveDialog = new SaveFileDialog
                    {
                        Filter = "Archivos PDF (*.pdf)|*.pdf",
                        Title = "Guardar Reporte de Cursos",
                        FileName = $"ReporteCursos_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
                    };

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        fileName = saveDialog.FileName;
                    }
                });
                thread.SetApartmentState(System.Threading.ApartmentState.STA);
                thread.Start();
                thread.Join();

                if (!string.IsNullOrEmpty(fileName))
                {
                    var document = new Document(PageSize.A4, 50, 50, 50, 50);
                    var writer = PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));
                    
                    document.Open();
                    
                    // Título
                    var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.DARK_GRAY);
                    var title = new Paragraph("REPORTE DE CURSOS E INSCRIPCIONES", titleFont)
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 20
                    };
                    document.Add(title);
                    
                    // Fecha
                    var dateFont = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.GRAY);
                    var date = new Paragraph($"Generado el: {DateTime.Now:dd/MM/yyyy HH:mm}", dateFont)
                    {
                        Alignment = Element.ALIGN_RIGHT,
                        SpacingAfter = 20
                    };
                    document.Add(date);
                    
                    // Tabla de cursos
                    var table = new PdfPTable(8) { WidthPercentage = 100 };
                    table.SetWidths(new float[] { 8, 20, 15, 8, 10, 10, 10, 15 });
                    
                    // Encabezados
                    var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, BaseColor.WHITE);
                    var headers = new[] { "ID", "Materia", "Comisión", "Año", "Cupo", "Inscriptos", "Disponible", "Estado" };
                    
                    foreach (var header in headers)
                    {
                        var cell = new PdfPCell(new Phrase(header, headerFont))
                        {
                            BackgroundColor = BaseColor.DARK_GRAY,
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            Padding = 5
                        };
                        table.AddCell(cell);
                    }
                    
                    // Datos
                    var cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 8);
                    
                    foreach (var curso in cursos)
                    {
                        var disponible = curso.Cupo - (curso.InscriptosActuales ?? 0);
                        var estado = disponible <= 0 ? "Completo" : disponible <= 5 ? "Casi Lleno" : "Disponible";
                        
                        table.AddCell(new PdfPCell(new Phrase(curso.IdCurso.ToString(), cellFont)) { Padding = 3 });
                        table.AddCell(new PdfPCell(new Phrase(curso.NombreMateria ?? "Sin Materia", cellFont)) { Padding = 3 });
                        table.AddCell(new PdfPCell(new Phrase(curso.DescComision ?? "Sin Comisión", cellFont)) { Padding = 3 });
                        table.AddCell(new PdfPCell(new Phrase(curso.AnioCalendario.ToString(), cellFont)) { Padding = 3 });
                        table.AddCell(new PdfPCell(new Phrase(curso.Cupo.ToString(), cellFont)) { Padding = 3, HorizontalAlignment = Element.ALIGN_CENTER });
                        table.AddCell(new PdfPCell(new Phrase((curso.InscriptosActuales ?? 0).ToString(), cellFont)) { Padding = 3, HorizontalAlignment = Element.ALIGN_CENTER });
                        table.AddCell(new PdfPCell(new Phrase(disponible.ToString(), cellFont)) { Padding = 3, HorizontalAlignment = Element.ALIGN_CENTER });
                        table.AddCell(new PdfPCell(new Phrase(estado, cellFont)) { Padding = 3 });
                    }
                    
                    document.Add(table);
                    document.Close();
                    
                    MessageBox.Show($"Reporte exportado exitosamente a:\n{fileName}", 
                        "Exportación Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar PDF: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ExportarPlanesPDF(IEnumerable<PlanDto> planes, IEnumerable<EspecialidadDto> especialidades)
        {
            try
            {
                string fileName = null;
                var thread = new System.Threading.Thread(() =>
                {
                    var saveDialog = new SaveFileDialog
                    {
                        Filter = "Archivos PDF (*.pdf)|*.pdf",
                        Title = "Guardar Reporte de Planes",
                        FileName = $"ReportePlanes_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
                    };

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        fileName = saveDialog.FileName;
                    }
                });
                thread.SetApartmentState(System.Threading.ApartmentState.STA);
                thread.Start();
                thread.Join();

                if (!string.IsNullOrEmpty(fileName))
                {
                    var document = new Document(PageSize.A4.Rotate(), 50, 50, 50, 50);
                    var writer = PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));
                    
                    document.Open();
                    
                    // Título
                    var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.DARK_GRAY);
                    var title = new Paragraph("REPORTE DE PLANES DE ESTUDIO", titleFont)
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 20
                    };
                    document.Add(title);
                    
                    // Fecha
                    var dateFont = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.GRAY);
                    var date = new Paragraph($"Generado el: {DateTime.Now:dd/MM/yyyy HH:mm}", dateFont)
                    {
                        Alignment = Element.ALIGN_RIGHT,
                        SpacingAfter = 20
                    };
                    document.Add(date);
                    
                    // Tabla de planes
                    var table = new PdfPTable(4) { WidthPercentage = 100 };
                    table.SetWidths(new float[] { 10, 40, 30, 20 });
                    
                    // Encabezados
                    var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE);
                    var headers = new[] { "ID", "Plan", "Especialidad", "Estado" };
                    
                    foreach (var header in headers)
                    {
                        var cell = new PdfPCell(new Phrase(header, headerFont))
                        {
                            BackgroundColor = BaseColor.DARK_GRAY,
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            Padding = 5
                        };
                        table.AddCell(cell);
                    }
                    
                    // Datos
                    var cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                    
                    foreach (var plan in planes)
                    {
                        var especialidad = especialidades?.FirstOrDefault(e => e.Id == plan.EspecialidadId);
                        
                        table.AddCell(new PdfPCell(new Phrase(plan.Id.ToString(), cellFont)) { Padding = 5 });
                        table.AddCell(new PdfPCell(new Phrase(plan.Descripcion ?? "Sin Descripción", cellFont)) { Padding = 5 });
                        table.AddCell(new PdfPCell(new Phrase(especialidad?.Descripcion ?? "Sin Especialidad", cellFont)) { Padding = 5 });
                        table.AddCell(new PdfPCell(new Phrase("Activo", cellFont)) { Padding = 5 });
                    }
                    
                    document.Add(table);
                    document.Close();
                    
                    MessageBox.Show($"Reporte exportado exitosamente a:\n{fileName}", 
                        "Exportación Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar PDF: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}