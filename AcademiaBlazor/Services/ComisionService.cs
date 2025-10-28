using DTOs;
using System.Net.Http.Json;

namespace AcademiaBlazor.Services
{
    public class ComisionService
    {
        private readonly HttpClient _httpClient;

        public ComisionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ComisionDto>> GetAllAsync()
        {
            try
            {
                var comisiones = await _httpClient.GetFromJsonAsync<IEnumerable<ComisionDto>>("comisiones");
                return comisiones ?? new List<ComisionDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener comisiones: {ex.Message}");
                return new List<ComisionDto>();
            }
        }

        public async Task<ComisionDto?> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ComisionDto>($"comisiones/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener comisión {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> CreateAsync(ComisionDto comision)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("comisiones", comision);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear comisión: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateAsync(ComisionDto comision)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"comisiones/{comision.IdComision}", comision);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar comisión: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"comisiones/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar comisión: {ex.Message}");
                return false;
            }
        }
    }
}
