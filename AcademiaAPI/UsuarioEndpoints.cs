namespace AcademiaAPI
{
    public static class UsuarioEndpoints
    {
        public static void MapUsuariosEndpoints(this WebApplication app) 
        { 
            app.MapGet("/usuarios", () =>
            {
                var usuariosService = new Aplication.Services.UsuarioService();
                var usuarios = usuariosService.GetAll();
                return Results.Ok(usuarios);
            });
            
            app.MapGet("/usuarios/{id:int}", (int id) =>
            {
                var usuariosService = new Aplication.Services.UsuarioService();
                var usuario = usuariosService.GetById(id);
                return usuario == null ? Results.NotFound() : Results.Ok(usuario);
            });

            
            app.MapGet("/usuarios/modulos", async () =>
            {
                var usuariosService = new Aplication.Services.UsuarioService();
                var modulos = await usuariosService.GetModulosAsync();
                return Results.Ok(modulos);
            });

            
            app.MapGet("/usuarios/tipos", () =>
            {
                var usuariosService = new Aplication.Services.UsuarioService();
                var tipos = usuariosService.GetTiposUsuario();
                return Results.Ok(tipos);
            });
            
            app.MapPost("/usuarios", (DTOs.UsuarioDto usuarioDto) =>
            {
                // Validaciones comunes para todos los tipos de usuario
                if (string.IsNullOrWhiteSpace(usuarioDto.UsuarioNombre))
                {
                    return Results.BadRequest("El nombre de usuario es obligatorio.");
                }

                if (string.IsNullOrWhiteSpace(usuarioDto.Email))
                {
                    return Results.BadRequest("El email es obligatorio.");
                }

                if (string.IsNullOrWhiteSpace(usuarioDto.Contrasenia))
                {
                    return Results.BadRequest("La contraseña es obligatoria.");
                }

                // Validaciones específicas según el tipo de usuario
                if (usuarioDto.TipoUsuario != "Administrador")
                {
                    // Para Profesor/Alumno se validan datos de persona
                    if (usuarioDto.persona == null)
                    {
                        return Results.BadRequest("Los datos de persona son obligatorios para Profesores y Alumnos.");
                    }

                    if (string.IsNullOrWhiteSpace(usuarioDto.persona.Nombre))
                    {
                        return Results.BadRequest("El nombre es obligatorio para Profesores y Alumnos.");
                    }

                    if (string.IsNullOrWhiteSpace(usuarioDto.persona.Apellido))
                    {
                        return Results.BadRequest("El apellido es obligatorio para Profesores y Alumnos.");
                    }

                    if (string.IsNullOrWhiteSpace(usuarioDto.Direccion))
                    {
                        return Results.BadRequest("La dirección es obligatoria para Profesores y Alumnos.");
                    }

                    if (!usuarioDto.FechaNacimiento.HasValue)
                    {
                        return Results.BadRequest("La fecha de nacimiento es obligatoria para Profesores y Alumnos.");
                    }

                }

                try
                {
                    var usuariosService = new Aplication.Services.UsuarioService();
                    usuariosService.Add(usuarioDto);
                    return Results.Created($"/usuarios/{usuarioDto.Id}", usuarioDto);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest($"Error al crear usuario: {ex.Message}");
                }
            });
            
            app.MapPut("/usuarios/{id:int}", (int id, DTOs.UsuarioDto usuarioDto) =>
            {
                if (id != usuarioDto.Id)
                {
                    return Results.BadRequest("ID mismatch");
                }
                
                var usuariosService = new Aplication.Services.UsuarioService();
                var existingUsuario = usuariosService.GetById(id);
                if (existingUsuario == null)
                {
                    return Results.NotFound();
                }
                
                try
                {
                    usuariosService.Update(usuarioDto);
                    return Results.NoContent();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest($"Error al actualizar usuario: {ex.Message}");
                }
            });
            
            app.MapDelete("/usuarios/{id:int}", (int id) =>
            {
                var usuariosService = new Aplication.Services.UsuarioService();
                var existingUsuario = usuariosService.GetById(id);
                if (existingUsuario == null)
                {
                    return Results.NotFound();
                }
                usuariosService.Delete(id);
                return Results.NoContent();
            });
        }
    }
}
