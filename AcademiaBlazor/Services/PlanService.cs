using DTOs;
using System.Net.Http.Json;

namespace AcademiaBlazor.Services
{
    public class PlanService
    {
        private readonly HttpClient _httpClient;

        public PlanService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<PlanDto>> GetAllAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<PlanDto>>("planes");
                return response ?? Enumerable.Empty<PlanDto>();
            }
            catch
            {
                return Enumerable.Empty<PlanDto>();
            }
        }

        public async Task<PlanDto?> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<PlanDto>($"planes/{id}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> CreateAsync(PlanDto plan)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("planes", plan);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear plan: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateAsync(PlanDto plan)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"planes/{plan.Id}", plan);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar plan: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"planes/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar plan: {ex.Message}");
                return false;
            }
        }
    }
}
