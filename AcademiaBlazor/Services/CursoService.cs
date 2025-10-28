using DTOs;
using System.Net.Http.Json;

namespace AcademiaBlazor.Services
{
    public class CursoService
    {
        private readonly HttpClient _httpClient;

        public CursoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CursoDto>> GetAllAsync()
        {
            try
            {
                var cursos = await _httpClient.GetFromJsonAsync<IEnumerable<CursoDto>>("cursos");
                return cursos ?? new List<CursoDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener cursos: {ex.Message}");
                return new List<CursoDto>();
            }
        }

        public async Task<CursoDto?> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<CursoDto>($"cursos/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener curso {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<CursoDto>> GetByAnioAsync(int anio)
        {
            try
            {
                var cursos = await _httpClient.GetFromJsonAsync<IEnumerable<CursoDto>>($"cursos/anio/{anio}");
                return cursos ?? new List<CursoDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener cursos del a�o {anio}: {ex.Message}");
                return new List<CursoDto>();
            }
        }

        public async Task<IEnumerable<CursoDto>> GetByComisionAsync(int idComision)
        {
            try
            {
                var cursos = await _httpClient.GetFromJsonAsync<IEnumerable<CursoDto>>($"cursos/comision/{idComision}");
                return cursos ?? new List<CursoDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener cursos de la comisi�n {idComision}: {ex.Message}");
                return new List<CursoDto>();
            }
        }

        public async Task<(bool success, string error)> CreateAsync(CursoDto curso)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("cursos", curso);
                if (response.IsSuccessStatusCode)
                    return (true, string.Empty);
                
                var errorContent = await response.Content.ReadAsStringAsync();
                return (false, errorContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear curso: {ex.Message}");
                return (false, ex.Message);
            }
        }

        public async Task<(bool success, string error)> UpdateAsync(CursoDto curso)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"cursos/{curso.IdCurso}", curso);
                if (response.IsSuccessStatusCode)
                    return (true, string.Empty);
                
                var errorContent = await response.Content.ReadAsStringAsync();
                return (false, errorContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar curso: {ex.Message}");
                return (false, ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"cursos/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar curso: {ex.Message}");
                return false;
            }
        }
    }
}
