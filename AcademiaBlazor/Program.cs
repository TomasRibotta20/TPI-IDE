using AcademiaBlazor;
using AcademiaBlazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


var apiBaseAddress = builder.Configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7229/";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseAddress) });

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<EspecialidadService>();
builder.Services.AddScoped<AlumnoService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<PlanService>();
builder.Services.AddScoped<InscripcionService>();
builder.Services.AddScoped<CursoService>();
builder.Services.AddScoped<DocenteCursoService>();
builder.Services.AddScoped<MateriaService>();
builder.Services.AddScoped<ComisionService>();
builder.Services.AddScoped<ProfesorService>();
builder.Services.AddScoped<PdfService>();

var host = builder.Build();


var authService = host.Services.GetRequiredService<AuthenticationService>();
await authService.InitializeAsync();

await host.RunAsync();
