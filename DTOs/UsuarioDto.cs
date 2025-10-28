using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class UsuarioDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        [MinLength(1, ErrorMessage = "El nombre de usuario no puede estar vacío.")]
        public string UsuarioNombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El email no tiene un formato válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        public string Contrasenia { get; set; } = string.Empty;

        public bool Habilitado { get; set; }

        public int? PersonaId { get; set; }
        public PersonaDto? persona { get; set; }

        // Propiedades calculadas para obtener nombre y apellido desde Persona (si existe)
        public string Nombre => persona?.Nombre ?? string.Empty;
        public string Apellido => persona?.Apellido ?? string.Empty;

        // Tipo de Usuario (para determinar qué campos mostrar)
        public string TipoUsuario { get; set; } = "Administrador"; // Administrador, Profesor, Alumno

        // === DATOS DE PERSONA (solo para Profesor/Alumno) ===
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? Legajo { get; set; }
        public TipoPersonaDto? TipoPersona { get; set; } // Profesor o Alumno
        public int? IdPlan { get; set; } // Solo para Alumnos
        public string? NombrePlan { get; set; } // Para mostrar en la UI

        // Permisos y módulos
        public int? ModuloId { get; set; }
        public string? NombreModulo { get; set; }
        public List<ModulosUsuariosDto> Permisos { get; set; } = new List<ModulosUsuariosDto>();
        
        public string PermisosResumen => string.Join(", ", 
            Permisos.SelectMany(p => 
            {
                var permisos = new List<string>();
                if (p.Alta) permisos.Add("Alta");
                if (p.Baja) permisos.Add("Baja");
                if (p.Modificacion) permisos.Add("Modificación");
                if (p.Consulta) permisos.Add("Consulta");
                return permisos.Any() ? new[] { $"{p.NombreModulo}: {string.Join(", ", permisos)}" } : Array.Empty<string>();
            }));
    }
}
