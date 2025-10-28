using DTOs;
using System.Net.Http.Json;

namespace AcademiaBlazor.Services
{
    public class ProfesorService
    {
        private readonly HttpClient _httpClient;

        public ProfesorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<PersonaDto>> GetAllAsync()
        {
            try
            {
                var profesores = await _httpClient.GetFromJsonAsync<IEnumerable<PersonaDto>>("personas/profesores");
                return profesores ?? new List<PersonaDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener profesores: {ex.Message}");
                return new List<PersonaDto>();
            }
        }

        public async Task<PersonaDto?> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<PersonaDto>($"personas/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener profesor {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> CreateAsync(PersonaDto profesor)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("personas", profesor);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear profesor: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateAsync(PersonaDto profesor)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"personas/{profesor.Id}", profesor);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar profesor: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"personas/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar profesor: {ex.Message}");
                return false;
            }
        }
    }
}
