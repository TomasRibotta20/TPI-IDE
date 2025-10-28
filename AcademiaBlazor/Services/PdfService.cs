using iTextSharp.text;
using iTextSharp.text.pdf;
using DTOs;
using Microsoft.JSInterop;

namespace AcademiaBlazor.Services
{
    public class PdfService
    {
        private readonly IJSRuntime _jsRuntime;

        public PdfService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task ExportarCursosPDF(IEnumerable<CursoDto> cursos)
        {
            try
            {
                var pdfBytes = GenerarPdfCursos(cursos);
                var fileName = $"ReporteCursos_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                
                await _jsRuntime.InvokeVoidAsync("downloadFile", fileName, Convert.ToBase64String(pdfBytes));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al generar PDF: {ex.Message}");
            }
        }

        public async Task ExportarPlanesPDF(IEnumerable<PlanDto> planes, IEnumerable<EspecialidadDto> especialidades)
        {
            try
            {
                var pdfBytes = GenerarPdfPlanes(planes, especialidades);
                var fileName = $"ReportePlanes_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                
                await _jsRuntime.InvokeVoidAsync("downloadFile", fileName, Convert.ToBase64String(pdfBytes));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al generar PDF: {ex.Message}");
            }
        }

        private byte[] GenerarPdfCursos(IEnumerable<CursoDto> cursos)
        {
            using var memoryStream = new MemoryStream();
            var document = new Document(PageSize.A4, 50, 50, 50, 50);
            var writer = PdfWriter.GetInstance(document, memoryStream);
            
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
            
            return memoryStream.ToArray();
        }

        private byte[] GenerarPdfPlanes(IEnumerable<PlanDto> planes, IEnumerable<EspecialidadDto> especialidades)
        {
            using var memoryStream = new MemoryStream();
            var document = new Document(PageSize.A4.Rotate(), 50, 50, 50, 50);
            var writer = PdfWriter.GetInstance(document, memoryStream);
            
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
            
            return memoryStream.ToArray();
        }
    }
}