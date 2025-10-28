using Aplication.Services;
using DTOs;
using AcademiaAPI;
using Data;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Starting API server...");

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("https://localhost:7229", "http://localhost:5001");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped(provider => new MateriaRepository(connectionString));
builder.Services.AddScoped(provider => new EspecialidadRepository(connectionString));
builder.Services.AddScoped(provider => new PlanRepository(connectionString));

builder.Services.AddScoped<PlanService>(provider => 
{
    var planRepo = provider.GetRequiredService<PlanRepository>();
    var especialidadService = new EspecialidadService(provider.GetRequiredService<EspecialidadRepository>());
    return new PlanService(planRepo, especialidadService);
});

builder.Services.AddScoped<MateriaService>(provider =>
{
    var materiaRepo = provider.GetRequiredService<MateriaRepository>();
    var planService = provider.GetRequiredService<PlanService>();
    return new MateriaService(materiaRepo, planService);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

Console.WriteLine($"Environment: {app.Environment.EnvironmentName}");
Console.WriteLine("Ensuring database is up to date...");

using (var scope = app.Services.CreateScope())
{
    try
    {
        var optionsBuilder = new DbContextOptionsBuilder<AcademiaContext>();
        optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        
        using var context = new AcademiaContext(optionsBuilder.Options);
        context.Database.Migrate();
        Console.WriteLine(">>> Database migrated successfully");
        
        var usuarioService = new UsuarioService();
        await usuarioService.CrearUsuarioAdminAsync();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"!!! Error initializing database: {ex.Message}");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpLogging();
    
    app.MapGet("/health", () => Results.Ok(new { status = "healthy", timestamp = DateTime.UtcNow }))
        .WithName("HealthCheck")
        .WithTags("Health")
        .WithOpenApi();
}

app.UseCors("AllowAll");

app.MapAuthEndpoints();
app.MapEspecialidadEndpoints();
app.MapUsuariosEndpoints();
app.MapPlanEndpoints();
app.MapMateriaEndpoints();
app.MapComisionesEndpoints();
app.MapPersonasEndpoints();
app.MapCursosEndpoints();
app.MapInscripcionesEndpoints();
app.MapDocenteCursoEndpoints();

app.Run();
