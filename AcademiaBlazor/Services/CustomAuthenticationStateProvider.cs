using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace AcademiaBlazor.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly AuthenticationService _authService;

        public CustomAuthenticationStateProvider(AuthenticationService authService)
        {
            _authService = authService;
            _authService.OnAuthenticationStateChanged += OnAuthenticationStateChanged;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = await _authService.GetCurrentUserAsync();
            
            if (user != null && !string.IsNullOrEmpty(user.Token))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("UserId", user.UserId.ToString()),
                    new Claim("TipoUsuario", user.TipoUsuario ?? ""),
                };

                if (user.PersonaId.HasValue)
                {
                    claims.Add(new Claim("PersonaId", user.PersonaId.Value.ToString()));
                }

                foreach (var permission in user.Permissions)
                {
                    claims.Add(new Claim("Permission", permission));
                }

                var identity = new ClaimsIdentity(claims, "apiauth");
                var claimsPrincipal = new ClaimsPrincipal(identity);
                
                return new AuthenticationState(claimsPrincipal);
            }

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        private void OnAuthenticationStateChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
