using DTOs;
using System.Net.Http.Json;

namespace AcademiaBlazor.Services
{
    public class DocenteCursoService
    {
        private readonly HttpClient _httpClient;

        public DocenteCursoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<DocenteCursoDto>> GetAllAsync()
        {
            try
            {
                var asignaciones = await _httpClient.GetFromJsonAsync<IEnumerable<DocenteCursoDto>>("docentes-cursos");
                return asignaciones ?? new List<DocenteCursoDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener asignaciones: {ex.Message}");
                return new List<DocenteCursoDto>();
            }
        }

        public async Task<IEnumerable<DocenteCursoDto>> GetByDocenteAsync(int idDocente)
        {
            try
            {
                var asignaciones = await _httpClient.GetFromJsonAsync<IEnumerable<DocenteCursoDto>>($"docentes-cursos/docente/{idDocente}");
                return asignaciones ?? new List<DocenteCursoDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener cursos del docente: {ex.Message}");
                return new List<DocenteCursoDto>();
            }
        }

        public async Task<IEnumerable<DocenteCursoDto>> GetByCursoAsync(int idCurso)
        {
            try
            {
                var asignaciones = await _httpClient.GetFromJsonAsync<IEnumerable<DocenteCursoDto>>($"docentes-cursos/curso/{idCurso}");
                return asignaciones ?? new List<DocenteCursoDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener docentes del curso: {ex.Message}");
                return new List<DocenteCursoDto>();
            }
        }

        public async Task<(bool success, string message)> CreateAsync(DocenteCursoCreateDto asignacion)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("docentes-cursos", asignacion);
                
                if (response.IsSuccessStatusCode)
                {
                    return (true, "Asignación creada exitosamente");
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                
                // Extraer mensaje de error del JSON
                try
                {
                    var errorJson = System.Text.Json.JsonDocument.Parse(errorContent);
                    
                    if (errorJson.RootElement.TryGetProperty("title", out var titleElement))
                    {
                        var message = titleElement.GetString();
                        if (!string.IsNullOrEmpty(message))
                            return (false, message);
                    }
                    
                    if (errorJson.RootElement.TryGetProperty("detail", out var detailElement))
                    {
                        var message = detailElement.GetString();
                        if (!string.IsNullOrEmpty(message))
                            return (false, message);
                    }
                    
                    if (errorJson.RootElement.TryGetProperty("message", out var messageElement))
                    {
                        var message = messageElement.GetString();
                        if (!string.IsNullOrEmpty(message))
                            return (false, message);
                    }
                }
                catch
                {
                    if (!string.IsNullOrEmpty(errorContent) && !errorContent.Contains("<html"))
                    {
                        return (false, errorContent);
                    }
                }

                return (false, "Error al crear la asignación");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear asignación: {ex.Message}");
                return (false, $"Error: {ex.Message}");
            }
        }

        public async Task<bool> UpdateAsync(int id, DocenteCursoCreateDto asignacion)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"docentes-cursos/{id}", asignacion);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar asignación: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"docentes-cursos/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar asignación: {ex.Message}");
                return false;
            }
        }
    }
}