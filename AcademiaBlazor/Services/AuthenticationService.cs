using Blazored.LocalStorage;
using DTOs;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace AcademiaBlazor.Services
{
    public class AuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private const string TOKEN_KEY = "authToken";
        private const string USER_KEY = "currentUser";

        public event Action? OnAuthenticationStateChanged;

        public AuthenticationService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            try
            {
                var loginRequest = new { Username = username, Password = password };
                var response = await _httpClient.PostAsJsonAsync("auth/login", loginRequest);

                if (response.IsSuccessStatusCode)
                {
                    var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
                    if (loginResponse != null)
                    {
                        await _localStorage.SetItemAsync(TOKEN_KEY, loginResponse.Token);
                        await _localStorage.SetItemAsync(USER_KEY, loginResponse);
                        
                        _httpClient.DefaultRequestHeaders.Authorization = 
                            new AuthenticationHeaderValue("Bearer", loginResponse.Token);
                        
                        OnAuthenticationStateChanged?.Invoke();
                        return true;
                    }
                }
                
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> RegisterAsync(RegisterRequestDto registerRequest)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("auth/register", registerRequest);
                
                if (response.IsSuccessStatusCode)
                {
                    var registerResponse = await response.Content.ReadFromJsonAsync<RegisterResponseDto>();
                    return registerResponse?.Success ?? false;
                }
                
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en registro: {ex.Message}");
                return false;
            }
        }

        public async Task LogoutAsync()
        {
            await _localStorage.RemoveItemAsync(TOKEN_KEY);
            await _localStorage.RemoveItemAsync(USER_KEY);
            _httpClient.DefaultRequestHeaders.Authorization = null;
            OnAuthenticationStateChanged?.Invoke();
        }

        public async Task<bool> IsAuthenticatedAsync()
        {
            var token = await _localStorage.GetItemAsync<string>(TOKEN_KEY);
            return !string.IsNullOrEmpty(token);
        }

        public async Task<string?> GetTokenAsync()
        {
            return await _localStorage.GetItemAsync<string>(TOKEN_KEY);
        }

        public async Task<LoginResponse?> GetCurrentUserAsync()
        {
            return await _localStorage.GetItemAsync<LoginResponse>(USER_KEY);
        }

        public async Task InitializeAsync()
        {
            var token = await GetTokenAsync();
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}
