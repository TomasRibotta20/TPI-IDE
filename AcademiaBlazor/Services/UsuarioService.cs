using DTOs;
using System.Net.Http.Json;

namespace AcademiaBlazor.Services
{
    public class UsuarioService
    {
        private readonly HttpClient _httpClient;

        public UsuarioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<UsuarioDto>> GetAllAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<UsuarioDto>>("usuarios");
                return response ?? Enumerable.Empty<UsuarioDto>();
            }
            catch
            {
                return Enumerable.Empty<UsuarioDto>();
            }
        }

        public async Task<UsuarioDto?> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<UsuarioDto>($"usuarios/{id}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> CreateAsync(UsuarioDto usuario)
        {
            try
            {
                Console.WriteLine($"[DEBUG] CreateAsync - Usuario: {usuario.UsuarioNombre}, TipoUsuario: {usuario.TipoUsuario}, PersonaId: {usuario.PersonaId}");
                Console.WriteLine($"[DEBUG] Direccion: {usuario.Direccion}, FechaNacimiento: {usuario.FechaNacimiento}");
                
                if (usuario.persona != null)
                {
                    Console.WriteLine($"[DEBUG] Persona: {usuario.persona.Nombre} {usuario.persona.Apellido}");
                    Console.WriteLine($"[DEBUG] Persona.Direccion: {usuario.persona.Direccion}");
                }
                else
                {
                    Console.WriteLine($"[WARNING] persona es NULL para usuario tipo: {usuario.TipoUsuario}");
                }
                
                var response = await _httpClient.PostAsJsonAsync("usuarios", usuario);
                
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"[ERROR] CreateAsync falló: {error}");
                    throw new Exception($"Error al crear usuario. Status: {response.StatusCode}. Detalle: {error}");
                }
                
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[EXCEPTION] CreateAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateAsync(UsuarioDto usuario)
        {
            try
            {
                Console.WriteLine($"[DEBUG] UpdateAsync - Usuario: {usuario.UsuarioNombre}, TipoUsuario: {usuario.TipoUsuario}");
                
                var response = await _httpClient.PutAsJsonAsync($"usuarios/{usuario.Id}", usuario);
                
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"[ERROR] UpdateAsync falló: {error}");
                }
                
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[EXCEPTION] UpdateAsync: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"usuarios/{id}");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}
