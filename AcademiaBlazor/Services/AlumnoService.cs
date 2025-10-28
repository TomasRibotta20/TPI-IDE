using DTOs;
using System.Net.Http.Json;

namespace AcademiaBlazor.Services
{
    public class AlumnoService
    {
        private readonly HttpClient _httpClient;

        public AlumnoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<PersonaDto>> GetAllAsync()
        {
            try
            {
                var alumnos = await _httpClient.GetFromJsonAsync<IEnumerable<PersonaDto>>("personas/alumnos");
                return alumnos ?? new List<PersonaDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener alumnos: {ex.Message}");
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
                Console.WriteLine($"Error al obtener alumno {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> CreateAsync(PersonaDto alumno)
        {
            try
            {
                alumno.TipoPersona = TipoPersonaDto.Alumno;
                var response = await _httpClient.PostAsJsonAsync("personas", alumno);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear alumno: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateAsync(PersonaDto alumno)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"personas/{alumno.Id}", alumno);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar alumno: {ex.Message}");
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
                Console.WriteLine($"Error al eliminar alumno: {ex.Message}");
                return false;
            }
        }
    }
}
