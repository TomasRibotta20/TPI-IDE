using DTOs;
using System.Net.Http.Json;
using System.Text.Json;

namespace AcademiaBlazor.Services
{
    public class MateriaService
    {
        private readonly HttpClient _httpClient;

        public MateriaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<MateriaDto>> GetAllAsync()
        {
            try
            {
                var materias = await _httpClient.GetFromJsonAsync<IEnumerable<MateriaDto>>("materias");
                return materias ?? new List<MateriaDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener materias: {ex.Message}");
                return new List<MateriaDto>();
            }
        }

        public async Task<MateriaDto?> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<MateriaDto>($"materias/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener materia {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> CreateAsync(MateriaDto materia)
        {
            try
            {
                Console.WriteLine($"Intentando crear materia: {JsonSerializer.Serialize(materia)}");
                var response = await _httpClient.PostAsJsonAsync("materias", materia);
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error en CreateAsync - Status: {response.StatusCode}, Content: {errorContent}");
                    throw new Exception($"Error al crear materia: {response.StatusCode} - {errorContent}");
                }
                
                Console.WriteLine("Materia creada exitosamente");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción al crear materia: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                throw; 
            }
        }

        public async Task<bool> UpdateAsync(MateriaDto materia)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"materias/{materia.Id}", materia);
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error en UpdateAsync - Status: {response.StatusCode}, Content: {errorContent}");
                    throw new Exception($"Error al actualizar materia: {response.StatusCode} - {errorContent}");
                }
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción al actualizar materia: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"materias/{id}");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error en DeleteAsync - Status: {response.StatusCode}, Content: {errorContent}");
                    throw new Exception($"Error al eliminar materia: {response.StatusCode} - {errorContent}");
                }
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción al eliminar materia: {ex.Message}");
                throw;
            }
        }
    }
}
