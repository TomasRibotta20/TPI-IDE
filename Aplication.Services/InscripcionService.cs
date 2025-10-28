using DTOs;
using Domain.Model;
using Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Services
{
    public class InscripcionService
    {
        private readonly AlumnoCursoRepository _inscripcionRepository;
        private readonly PersonaRepository _personaRepository;
        private readonly CursoRepository _cursoRepository;
        private readonly ComisionRepository _comisionRepository;
        private readonly AcademiaContext _context;

        public InscripcionService()
        {
            _inscripcionRepository = new AlumnoCursoRepository();
            _personaRepository = new PersonaRepository();
            _cursoRepository = new CursoRepository();
            _comisionRepository = new ComisionRepository();
            _context = new AcademiaContext();
        }

        private async Task<string> GenerarDescripcionCursoAsync(Curso? curso)
        {
            if (curso == null)
                return "Curso no encontrado";

            var descripcion = $"Curso {curso.IdCurso}";
            
            try
            {
                var comision = await _comisionRepository.GetByIdAsync(curso.IdComision);
                
                if (comision != null && !string.IsNullOrEmpty(comision.DescComision))
                {
                    descripcion += $" - {comision.DescComision}";
                }
                else
                {
                    descripcion += $" - Comisión {curso.IdComision}";
                }
            }
            catch
            {
                descripcion += $" - Comisión {curso.IdComision}";
            }
            
            descripcion += $" ({curso.AnioCalendario})";
            
            return descripcion;
        }

        private async Task<AlumnoCursoDto> CrearDtoAsync(AlumnoCurso inscripcion)
        {
            var alumno = await _personaRepository.GetByIdAsync(inscripcion.IdAlumno);
            var curso = await _cursoRepository.GetByIdAsync(inscripcion.IdCurso);
            
            string? nombreMateria = null;
            string? descComision = null;
            
            if (curso != null)
            {
                if (curso.IdMateria.HasValue)
                {
                    var materia = await _context.Materias
                        .FirstOrDefaultAsync(m => m.Id == curso.IdMateria.Value);
                    nombreMateria = materia?.Descripcion;
                }
                
                var comision = await _comisionRepository.GetByIdAsync(curso.IdComision);
                descComision = comision?.DescComision;
            }

            return new AlumnoCursoDto
            {
                IdInscripcion = inscripcion.IdInscripcion,
                IdAlumno = inscripcion.IdAlumno,
                NombreAlumno = alumno?.Nombre,
                ApellidoAlumno = alumno?.Apellido,
                LegajoAlumno = alumno?.Legajo,
                IdCurso = inscripcion.IdCurso,
                DescripcionCurso = await GenerarDescripcionCursoAsync(curso),
                NombreMateria = nombreMateria,
                DescComision = descComision,
                AnioCalendario = curso?.AnioCalendario,
                Condicion = (CondicionAlumnoDto)inscripcion.Condicion,
                Nota = inscripcion.Nota,
                FechaInscripcion = DateTime.Now
            };
        }

        public async Task<IEnumerable<AlumnoCursoDto>> GetAllAsync()
        {
            var inscripciones = await _inscripcionRepository.GetAllAsync();
            var result = new List<AlumnoCursoDto>();

            foreach (var inscripcion in inscripciones)
            {
                result.Add(await CrearDtoAsync(inscripcion));
            }

            return result;
        }

        public async Task<AlumnoCursoDto?> GetByIdAsync(int id)
        {
            var inscripcion = await _inscripcionRepository.GetByIdAsync(id);
            if (inscripcion == null) return null;

            return await CrearDtoAsync(inscripcion);
        }

        public async Task<AlumnoCursoDto> InscribirAlumnoAsync(int idAlumno, int idCurso, CondicionAlumnoDto condicion = CondicionAlumnoDto.Regular)
        {
            await ValidarInscripcionAsync(idAlumno, idCurso);

            var inscripcion = new AlumnoCurso(
                idAlumno,
                idCurso,
                (CondicionAlumno)condicion
            );

            var inscripcionCreada = await _inscripcionRepository.CreateAsync(inscripcion);
            return await GetByIdAsync(inscripcionCreada.IdInscripcion) ?? throw new Exception("Error al crear la inscripción");
        }

        public async Task ActualizarCondicionYNotaAsync(int idInscripcion, CondicionAlumnoDto condicion, int? nota = null)
        {
            var inscripcion = await _inscripcionRepository.GetByIdAsync(idInscripcion);
            if (inscripcion == null)
                throw new Exception("Inscripción no encontrada");

            inscripcion.SetCondicion((CondicionAlumno)condicion);
            if (nota.HasValue)
                inscripcion.SetNota(nota.Value);

            await _inscripcionRepository.UpdateAsync(inscripcion);
        }

        public async Task DesinscribirAlumnoAsync(int idInscripcion)
        {
            await _inscripcionRepository.DeleteAsync(idInscripcion);
        }

        public async Task<IEnumerable<AlumnoCursoDto>> GetInscripcionesByAlumnoAsync(int idAlumno)
        {
            var inscripciones = await _inscripcionRepository.GetByAlumnoAsync(idAlumno);
            var result = new List<AlumnoCursoDto>();

            foreach (var inscripcion in inscripciones)
            {
                result.Add(await CrearDtoAsync(inscripcion));
            }

            return result;
        }

        public async Task<IEnumerable<AlumnoCursoDto>> GetInscripcionesByCursoAsync(int idCurso)
        {
            var inscripciones = await _inscripcionRepository.GetByCursoAsync(idCurso);
            var result = new List<AlumnoCursoDto>();

            foreach (var inscripcion in inscripciones)
            {
                result.Add(await CrearDtoAsync(inscripcion));
            }

            return result;
        }

        private async Task ValidarInscripcionAsync(int idAlumno, int idCurso)
        {
            var alumno = await _personaRepository.GetByIdAsync(idAlumno);
            if (alumno == null)
                throw new Exception("El alumno especificado no existe en el sistema");

            if (alumno.TipoPersona != TipoPersona.Alumno)
                throw new Exception("La persona especificada no es un alumno válido");

            var curso = await _cursoRepository.GetByIdAsync(idCurso);
            if (curso == null)
                throw new Exception("El curso especificado no existe en el sistema");

            if (!alumno.IdPlan.HasValue)
                throw new Exception("El alumno no tiene un plan asignado");
                
            var comision = await _comisionRepository.GetByIdAsync(curso.IdComision);
            if (comision == null)
                throw new Exception("La comisión del curso no existe");
                
            if (alumno.IdPlan.Value != comision.IdPlan)
                throw new Exception($"El alumno pertenece al plan {alumno.IdPlan.Value} pero el curso pertenece al plan {comision.IdPlan}. No puede inscribirse.");

            var yaInscripto = await _inscripcionRepository.ExistsInscripcionAsync(idAlumno, idCurso);
            if (yaInscripto)
                throw new Exception($"El alumno {alumno.Nombre} {alumno.Apellido} ya está inscripto en este curso. No se permite inscripción duplicada.");

            var inscriptosActuales = await _cursoRepository.GetInscriptosCountAsync(idCurso);
            if (inscriptosActuales >= curso.Cupo)
                throw new Exception($"No hay cupo disponible en este curso. Está completo ({inscriptosActuales}/{curso.Cupo} inscriptos). Seleccione otro curso.");

            int anioActual = DateTime.Now.Year;
            if (curso.AnioCalendario < anioActual)
                throw new Exception($"No se puede inscribir a cursos de años anteriores. El curso es del año {curso.AnioCalendario} y el año actual es {anioActual}.");
        }

        public async Task<Dictionary<string, int>> GetEstadisticasGeneralesAsync()
        {
            var todasInscripciones = await _inscripcionRepository.GetAllAsync();
            
            return new Dictionary<string, int>
            {
                ["TotalInscripciones"] = todasInscripciones.Count(),
                ["AlumnosLibres"] = todasInscripciones.Count(i => i.Condicion == CondicionAlumno.Libre),
                ["AlumnosRegulares"] = todasInscripciones.Count(i => i.Condicion == CondicionAlumno.Regular),
                ["AlumnosPromocionales"] = todasInscripciones.Count(i => i.Condicion == CondicionAlumno.Promocional)
            };
        }
    }
}
