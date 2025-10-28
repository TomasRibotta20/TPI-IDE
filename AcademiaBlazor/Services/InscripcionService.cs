using DTOs;
using System.Net.Http.Json;

namespace AcademiaBlazor.Services
{
    public class InscripcionService
    {
        private readonly HttpClient _httpClient;

        public InscripcionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<AlumnoCursoDto>> GetAllAsync()
        {
            try
            {
                var inscripciones = await _httpClient.GetFromJsonAsync<IEnumerable<AlumnoCursoDto>>("inscripciones");
                return inscripciones ?? new List<AlumnoCursoDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener inscripciones: {ex.Message}");
                return new List<AlumnoCursoDto>();
            }
        }

        public async Task<IEnumerable<AlumnoCursoDto>> GetByAlumnoAsync(int idAlumno)
        {
            try
            {
                var inscripciones = await _httpClient.GetFromJsonAsync<IEnumerable<AlumnoCursoDto>>($"inscripciones/alumno/{idAlumno}");
                return inscripciones ?? new List<AlumnoCursoDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener inscripciones del alumno: {ex.Message}");
                return new List<AlumnoCursoDto>();
            }
        }

        public async Task<IEnumerable<AlumnoCursoDto>> GetByCursoAsync(int idCurso)
        {
            try
            {
                var inscripciones = await _httpClient.GetFromJsonAsync<IEnumerable<AlumnoCursoDto>>($"inscripciones/curso/{idCurso}");
                return inscripciones ?? new List<AlumnoCursoDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener inscripciones del curso: {ex.Message}");
                return new List<AlumnoCursoDto>();
            }
        }

        public async Task<(bool success, string message)> InscribirAsync(int idAlumno, int idCurso)
        {
            try
            {
                var request = new
                {
                    IdAlumno = idAlumno,
                    IdCurso = idCurso,
                    Condicion = "Regular"
                };

                var response = await _httpClient.PostAsJsonAsync("inscripciones", request);
                
                if (response.IsSuccessStatusCode)
                {
                    return (true, "Inscripci�n exitosa");
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                
                // Extraer mensaje de error del JSON
                try
                {
                    var errorJson = System.Text.Json.JsonDocument.Parse(errorContent);
                    if (errorJson.RootElement.TryGetProperty("title", out var titleElement))
                    {
                        return (false, titleElement.GetString() ?? "Error al inscribir al curso");
                    }
                }
                catch
                {
                    // Si no se puede parsear como JSON, usamos el contenido directo
                }
                
                if (errorContent.Contains("ya est� inscripto"))
                    return (false, "El alumno ya est� inscripto en este curso");
                if (errorContent.Contains("No hay cupo"))
                    return (false, "No hay cupo disponible en este curso");
                if (errorContent.Contains("a�os anteriores"))
                    return (false, "No se puede inscribir a cursos de a�os anteriores");
                if (errorContent.Contains("no existe"))
                    return (false, "El curso o alumno no existe");

                return (false, "Error al inscribir al curso");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al inscribir: {ex.Message}");
                return (false, $"Error: {ex.Message}");
            }
        }

        public async Task<bool> InscribirAlumnoAsync(AlumnoCursoDto inscripcion)
        {
            try
            {
                var request = new
                {
                    IdAlumno = inscripcion.IdAlumno,
                    IdCurso = inscripcion.IdCurso,
                    Condicion = inscripcion.Condicion.ToString(),
                    Nota = inscripcion.Nota
                };

                var response = await _httpClient.PostAsJsonAsync("inscripciones", request);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al inscribir alumno: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DesinscribirAsync(int idInscripcion)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"inscripciones/{idInscripcion}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al desinscribir: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DesinscribirAlumnoAsync(int idInscripcion)
        {
            return await DesinscribirAsync(idInscripcion);
        }

        public async Task<bool> ActualizarCondicionAsync(int idInscripcion, CondicionAlumnoDto condicion, int? nota)
        {
            try
            {
                var request = new
                {
                    Condicion = condicion.ToString(),
                    Nota = nota
                };

                var response = await _httpClient.PutAsJsonAsync($"inscripciones/{idInscripcion}/condicion", request);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar condici�n: {ex.Message}");
                return false;
            }
        }

        public async Task<Dictionary<string, int>> GetEstadisticasAsync()
        {
            try
            {
                var stats = await _httpClient.GetFromJsonAsync<Dictionary<string, int>>("inscripciones/estadisticas");
                return stats ?? new Dictionary<string, int>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener estad�sticas: {ex.Message}");
                return new Dictionary<string, int>();
            }
        }
    }
}
