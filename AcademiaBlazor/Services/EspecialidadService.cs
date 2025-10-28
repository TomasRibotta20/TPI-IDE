using DTOs;
using System.Net.Http.Json;

namespace AcademiaBlazor.Services
{
    public class EspecialidadService
    {
        private readonly HttpClient _httpClient;

        public EspecialidadService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<EspecialidadDto>> GetAllAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<EspecialidadDto>>("especialidades");
                return response ?? Enumerable.Empty<EspecialidadDto>();
            }
            catch
            {
                return Enumerable.Empty<EspecialidadDto>();
            }
        }

        public async Task<EspecialidadDto?> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<EspecialidadDto>($"especialidades/{id}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> CreateAsync(EspecialidadDto especialidad)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("especialidades", especialidad);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(EspecialidadDto especialidad)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"especialidades/{especialidad.Id}", especialidad);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"especialidades/{id}");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}
