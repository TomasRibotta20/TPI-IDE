using Data;
using Domain.Model;
using DTOs;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Services
{
    public class UsuarioService
    {
        private readonly AcademiaContext _context;
        private readonly UsuarioRepository _repository;

        public UsuarioService()
        {
            _context = new AcademiaContext();
            _repository = new UsuarioRepository(_context);
        }

        public async Task InicializarModulosAsync()
        {
            if (await _context.Modulos.AnyAsync())
            {
                return;
            }

            var modulos = new List<Modulo>
            {
                new Modulo("Usuarios", "Gestión de usuarios del sistema"),
                new Modulo("Alumnos", "Gestión de alumnos"),
                new Modulo("Profesores", "Gestión de profesores"),
                new Modulo("Cursos", "Gestión de cursos"),
                new Modulo("Inscripciones", "Gestión de inscripciones a cursos"),
                new Modulo("Planes", "Gestión de planes de estudio"),
                new Modulo("Especialidades", "Gestión de especialidades"),
                new Modulo("Comisiones", "Gestión de comisiones"),
                new Modulo("Reportes", "Visualización de reportes")
            };

            _context.Modulos.AddRange(modulos);
            await _context.SaveChangesAsync();
        }

        public async Task CrearUsuarioAdminAsync()
        {
            var adminExiste = await _context.Usuarios.AnyAsync(u => u.UsuarioNombre == "admin");
            if (adminExiste)
            {
                return;
            }

            await InicializarModulosAsync();

            var adminUsuario = new Usuario(
                "admin",
                "admin@academia.com",
                "admin123",
                true
            );

            _context.Usuarios.Add(adminUsuario);
            await _context.SaveChangesAsync();

            await AsignarPermisosPorTipoUsuarioAsync(adminUsuario.Id, null);
            await _context.SaveChangesAsync();

            Console.WriteLine(">>> Usuario admin creado exitosamente (usuario: admin, contraseña: admin123)");
        }

        public async Task<IEnumerable<UsuarioDto>> GetAllAsync()
        {
            var usuarios = await _repository.GetAllAsync();
            return usuarios.Select(MapToDto);
        }

        public async Task<UsuarioDto?> GetByIdAsync(int id)
        {
            var usuario = await _repository.GetByIdAsync(id);
            return usuario == null ? null : MapToDto(usuario);
        }

        public async Task AddAsync(UsuarioDto usuarioDto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await InicializarModulosAsync();

                Persona? nuevaPersona = null;

                // Si NO es Administrador, creamos la Persona primero
                if (usuarioDto.TipoUsuario != "Administrador")
                {
                    // Obtener nombre y apellido desde persona DTO o desde las propiedades calculadas
                    string nombre = usuarioDto.persona?.Nombre ?? usuarioDto.Nombre;
                    string apellido = usuarioDto.persona?.Apellido ?? usuarioDto.Apellido;

                    // Validaciones de campos requeridos para Persona
                    if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
                        throw new ArgumentException("Nombre y apellido son obligatorios para Profesores y Alumnos");

                    if (string.IsNullOrWhiteSpace(usuarioDto.Direccion))
                        throw new ArgumentException("La dirección es obligatoria para Profesores y Alumnos");
                    
                    if (!usuarioDto.FechaNacimiento.HasValue)
                        throw new ArgumentException("La fecha de nacimiento es obligatoria");

                    // Determinar TipoPersona
                    var tipoPersona = usuarioDto.TipoUsuario == "Profesor" 
                        ? TipoPersona.Profesor 
                        : TipoPersona.Alumno;

                    // Plan es OPCIONAL para alumnos 
                    
                    // Generar legajo automático
                    int legajo = await GenerarLegajoAsync(tipoPersona);

                    // Crear Persona
                    nuevaPersona = new Persona(
                        nombre,
                        apellido,
                        usuarioDto.Direccion,
                        usuarioDto.Email,
                        usuarioDto.Telefono,
                        usuarioDto.FechaNacimiento.Value,
                        legajo,
                        tipoPersona,
                        usuarioDto.IdPlan  // Puede ser null
                    );

                    _context.Personas.Add(nuevaPersona);
                    await _context.SaveChangesAsync();
                }

                // Crear Usuario
                var usuario = new Usuario(
                    usuarioDto.UsuarioNombre,
                    usuarioDto.Email,
                    usuarioDto.Contrasenia,
                    usuarioDto.Habilitado
                );

                // Asociar Persona si fue creada
                if (nuevaPersona != null)
                {
                    usuario.PersonaId = nuevaPersona.Id;
                }

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                // Asignar permisos según el tipo
                await AsignarPermisosPorTipoUsuarioAsync(usuario.Id, usuario.PersonaId);
                
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception($"Error al crear usuario: {ex.Message}", ex);
            }
        }

        public async Task UpdateAsync(UsuarioDto usuarioDto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var usuarioExistente = await _repository.GetByIdAsync(usuarioDto.Id);
                
                if (usuarioExistente == null)
                    throw new InvalidOperationException($"Usuario con Id {usuarioDto.Id} no encontrado");

                // Si tiene PersonaId, actualizar datos de Persona también
                if (usuarioExistente.PersonaId.HasValue)
                {
                    var persona = await _context.Personas.FindAsync(usuarioExistente.PersonaId.Value);
                    if (persona != null && usuarioDto.persona != null)
                    {
                        // Actualizar datos de persona desde el DTO de persona
                        persona.Nombre = usuarioDto.persona.Nombre;
                        persona.Apellido = usuarioDto.persona.Apellido;
                        persona.Email = usuarioDto.Email;
                        persona.Direccion = usuarioDto.Direccion;
                        persona.Telefono = usuarioDto.Telefono;
                        
                        if (usuarioDto.FechaNacimiento.HasValue)
                            persona.FechaNacimiento = usuarioDto.FechaNacimiento.Value;
                        
                        if (usuarioDto.IdPlan.HasValue)
                            persona.IdPlan = usuarioDto.IdPlan;

                        _context.Personas.Update(persona);
                    }
                }

                // Actualizar datos de usuario
                usuarioExistente.SetUsername(usuarioDto.UsuarioNombre);
                usuarioExistente.SetEmail(usuarioDto.Email);
                usuarioExistente.SetHabilitado(usuarioDto.Habilitado);
                
                // Solo actualizar contraseña si se proporcionó una nueva
                if (!string.IsNullOrWhiteSpace(usuarioDto.Contrasenia))
                {
                    usuarioExistente.SetPassword(usuarioDto.Contrasenia);
                }

                _context.Usuarios.Update(usuarioExistente);
                await _context.SaveChangesAsync();
                
                // Actualizar permisos si cambiaron
                if (usuarioDto.Permisos != null && usuarioDto.Permisos.Any())
                {
                    var permisosExistentes = await _context.ModulosUsuarios
                        .Where(mu => mu.UsuarioId == usuarioDto.Id)
                        .ToListAsync();
                    
                    _context.ModulosUsuarios.RemoveRange(permisosExistentes);
                    await _context.SaveChangesAsync();
                    
                    foreach (var permisoDto in usuarioDto.Permisos)
                    {
                        var moduloUsuario = new ModulosUsuarios
                        {
                            UsuarioId = usuarioDto.Id,
                            ModuloId = permisoDto.ModuloId,
                            alta = permisoDto.Alta,
                            baja = permisoDto.Baja,
                            modificacion = permisoDto.Modificacion,
                            consulta = permisoDto.Consulta
                        };

                        _context.ModulosUsuarios.Add(moduloUsuario);
                    }
                    
                    await _context.SaveChangesAsync();
                }
                
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception($"Error al actualizar usuario: {ex.Message}", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ModuloDto>> GetModulosAsync()
        {
            await InicializarModulosAsync();
            var modulos = await _context.Modulos.ToListAsync();
            return modulos.Select(m => new ModuloDto
            {
                Id_Modulo = m.Id_Modulo,
                Desc_Modulo = m.Desc_Modulo,
                Ejecuta = m.Ejecuta
            });
        }

        public List<string> GetTiposUsuario()
        {
            return new List<string> { "Administrador", "Profesor", "Alumno" };
        }

        private async Task<string> DeterminarTipoUsuarioAsync(int? personaId)
        {
            if (personaId == null)
                return "Administrador";

            var persona = await _context.Personas.FindAsync(personaId.Value);
            if (persona == null)
                return "Administrador";

            return persona.TipoPersona switch
            {
                TipoPersona.Profesor => "Profesor",
                TipoPersona.Alumno => "Alumno",
                _ => "Administrador"
            };
        }

        private async Task ValidarPersonaSegunTipoAsync(int? personaId)
        {
            if (personaId == null)
                return;

            var persona = await _context.Personas.FindAsync(personaId.Value);
            if (persona == null)
                throw new InvalidOperationException("La persona especificada no existe");

            if (persona.TipoPersona != TipoPersona.Profesor && persona.TipoPersona != TipoPersona.Alumno)
                throw new InvalidOperationException("El tipo de persona debe ser Profesor o Alumno");
        }

        private async Task AsignarPermisosPorTipoUsuarioAsync(int usuarioId, int? personaId)
        {
            var tipoUsuario = await DeterminarTipoUsuarioAsync(personaId);
            var modulos = await _context.Modulos.ToListAsync();

            var permisosExistentes = await _context.ModulosUsuarios
                .Where(mu => mu.UsuarioId == usuarioId)
                .ToListAsync();
            _context.ModulosUsuarios.RemoveRange(permisosExistentes);

            List<ModulosUsuarios> nuevosPermisos = new();

            foreach (var modulo in modulos)
            {
                var permiso = CrearPermisoSegunTipo(usuarioId, modulo.Id_Modulo, modulo.Desc_Modulo, tipoUsuario);
                if (permiso != null)
                    nuevosPermisos.Add(permiso);
            }

            _context.ModulosUsuarios.AddRange(nuevosPermisos);
        }

        private ModulosUsuarios? CrearPermisoSegunTipo(int usuarioId, int moduloId, string nombreModulo, string tipoUsuario)
        {
            bool alta = false, baja = false, modificacion = false, consulta = false;

            switch (tipoUsuario)
            {
                case "Administrador":
                    alta = baja = modificacion = consulta = true;
                    break;

                case "Profesor":
                    switch (nombreModulo)
                    {
                        case "Inscripciones":
                            modificacion = consulta = true;
                            break;
                        case "Cursos":
                        case "Alumnos":
                        case "Reportes":
                            consulta = true;
                            break;
                        case "Profesores":
                            modificacion = consulta = true;
                            break;
                        default:
                            return null;
                    }
                    break;

                case "Alumno":
                    switch (nombreModulo)
                    {
                        case "Inscripciones":
                            alta = consulta = true;
                            break;
                        case "Cursos":
                            consulta = true;
                            break;
                        case "Alumnos":
                            consulta = true;
                            break;
                        default:
                            return null;
                    }
                    break;

                default:
                    return null;
            }

            return new ModulosUsuarios
            {
                UsuarioId = usuarioId,
                ModuloId = moduloId,
                alta = alta,
                baja = baja,
                modificacion = modificacion,
                consulta = consulta
            };
        }

        private UsuarioDto MapToDto(Usuario usuario)
        {
            var tipoUsuario = "Administrador";
            PersonaDto? personaDto = null;

            if (usuario.Persona != null)
            {
                tipoUsuario = usuario.Persona.TipoPersona == Domain.Model.TipoPersona.Profesor 
                    ? "Profesor" 
                    : "Alumno";

                personaDto = new PersonaDto
                {
                    Id = usuario.Persona.Id,
                    Nombre = usuario.Persona.Nombre,
                    Apellido = usuario.Persona.Apellido,
                    Email = usuario.Persona.Email,
                    Direccion = usuario.Persona.Direccion,
                    Telefono = usuario.Persona.Telefono,
                    FechaNacimiento = usuario.Persona.FechaNacimiento,
                    Legajo = usuario.Persona.Legajo,
                    TipoPersona = usuario.Persona.TipoPersona == Domain.Model.TipoPersona.Alumno 
                        ? TipoPersonaDto.Alumno 
                        : TipoPersonaDto.Profesor,
                    IdPlan = usuario.Persona.IdPlan
                };
            }

            return new UsuarioDto
            {
                Id = usuario.Id,
                UsuarioNombre = usuario.UsuarioNombre,
                Contrasenia = string.Empty,
                Email = usuario.Email,
                Habilitado = usuario.Habilitado,
                PersonaId = usuario.PersonaId,
                TipoUsuario = tipoUsuario,
                
                // Datos de Persona (si existe)
                Direccion = usuario.Persona?.Direccion,
                Telefono = usuario.Persona?.Telefono,
                FechaNacimiento = usuario.Persona?.FechaNacimiento,
                Legajo = usuario.Persona?.Legajo,
                TipoPersona = usuario.Persona?.TipoPersona == Domain.Model.TipoPersona.Alumno 
                    ? TipoPersonaDto.Alumno 
                    : (usuario.Persona?.TipoPersona == Domain.Model.TipoPersona.Profesor ? TipoPersonaDto.Profesor : null),
                IdPlan = usuario.Persona?.IdPlan,
                
                persona = personaDto,
                Permisos = usuario.ModulosUsuarios?.Select(mu => new ModulosUsuariosDto
                {
                    Id_ModuloUsuario = mu.Id_ModuloUsuario,
                    UsuarioId = mu.UsuarioId,
                    ModuloId = mu.ModuloId,
                    Alta = mu.alta,
                    Baja = mu.baja,
                    Modificacion = mu.modificacion,
                    Consulta = mu.consulta,
                    NombreModulo = mu.Modulo?.Desc_Modulo,
                    DescripcionModulo = mu.Modulo?.Ejecuta
                }).ToList() ?? new List<ModulosUsuariosDto>()
            };
        }

        public IEnumerable<UsuarioDto> GetAll()
        {
            return GetAllAsync().GetAwaiter().GetResult();
        }

        public UsuarioDto? GetById(int id)
        {
            return GetByIdAsync(id).GetAwaiter().GetResult();
        }

        public void Add(UsuarioDto usuarioDto)
        {
            AddAsync(usuarioDto).GetAwaiter().GetResult();
        }

        public void Update(UsuarioDto usuarioDto)
        {
            UpdateAsync(usuarioDto).GetAwaiter().GetResult();
        }

        public void Delete(int id)
        {
            DeleteAsync(id).GetAwaiter().GetResult();
        }

        // Método auxiliar para generar legajo automático
        private async Task<int> GenerarLegajoAsync(TipoPersona tipoPersona)
        {
            var personas = await _context.Personas
                .Where(p => p.TipoPersona == tipoPersona)
                .ToListAsync();

            if (!personas.Any())
                return tipoPersona == TipoPersona.Alumno ? 1000 : 5000;

            var maxLegajo = personas.Max(p => p.Legajo);
            return maxLegajo + 1;
        }
    }
}