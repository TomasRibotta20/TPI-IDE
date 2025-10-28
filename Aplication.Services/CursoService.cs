using DTOs;
using Domain.Model;
using Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Services
{
    public class CursoService
    {
        private readonly CursoRepository _cursoRepository;
        private readonly ComisionRepository _comisionRepository;
        private readonly MateriaRepository _materiaRepository;

        public CursoService()
        {
            _cursoRepository = new CursoRepository();
            _comisionRepository = new ComisionRepository();
            
            using var context = new AcademiaContext();
            var connectionString = context.Database.GetConnectionString() ?? "Server=localhost,1433;Database=Universidad;User Id=sa;Password=TuContraseñaFuerte123;TrustServerCertificate=True";
            _materiaRepository = new MateriaRepository(connectionString);
        }

        public async Task<IEnumerable<CursoDto>> GetAllAsync()
        {
            var cursos = await _cursoRepository.GetAllAsync();
            var result = new List<CursoDto>();

            foreach (var curso in cursos)
            {
                var comision = await _comisionRepository.GetByIdAsync(curso.IdComision);
                var inscriptos = await _cursoRepository.GetInscriptosCountAsync(curso.IdCurso);
                
                string nombreMateria = "Sin Materia";
                if (curso.IdMateria.HasValue)
                {
                    var materia = _materiaRepository.GetById(curso.IdMateria.Value);
                    nombreMateria = materia?.Descripcion ?? "Materia no encontrada";
                }

                result.Add(new CursoDto
                {
                    IdCurso = curso.IdCurso,
                    IdMateria = curso.IdMateria,
                    NombreMateria = nombreMateria,
                    IdComision = curso.IdComision,
                    DescComision = comision?.DescComision ?? "Comisión no encontrada",
                    AnioCalendario = curso.AnioCalendario,
                    Cupo = curso.Cupo,
                    InscriptosActuales = inscriptos
                });
            }

            return result;
        }

        public async Task<CursoDto?> GetByIdAsync(int id)
        {
            var curso = await _cursoRepository.GetByIdAsync(id);
            if (curso == null) return null;

            var comision = await _comisionRepository.GetByIdAsync(curso.IdComision);
            var inscriptos = await _cursoRepository.GetInscriptosCountAsync(curso.IdCurso);

            string nombreMateria = "Sin Materia";
            if (curso.IdMateria.HasValue)
            {
                var materia = _materiaRepository.GetById(curso.IdMateria.Value);
                nombreMateria = materia?.Descripcion ?? "Materia no encontrada";
            }

            return new CursoDto
            {
                IdCurso = curso.IdCurso,
                IdMateria = curso.IdMateria,
                NombreMateria = nombreMateria,
                IdComision = curso.IdComision,
                DescComision = comision?.DescComision ?? "Comisión no encontrada",
                AnioCalendario = curso.AnioCalendario,
                Cupo = curso.Cupo,
                InscriptosActuales = inscriptos
            };
        }

        public async Task<CursoDto> CreateAsync(CursoDto cursoDto)
        {
            await ValidateComisionExistsAsync(cursoDto.IdComision);
            
            if (!cursoDto.IdMateria.HasValue || cursoDto.IdMateria.Value <= 0)
                throw new Exception("Debe seleccionar una materia válida");
                
            ValidateMateriaExists(cursoDto.IdMateria.Value);
            await ValidatePlanCoincideAsync(cursoDto.IdMateria.Value, cursoDto.IdComision);
            
            ValidateAnioCalendario(cursoDto.AnioCalendario);
            ValidateCupo(cursoDto.Cupo);

            var curso = new Curso(
                cursoDto.IdMateria,
                cursoDto.IdComision,
                cursoDto.AnioCalendario,
                cursoDto.Cupo
            );

            var createdCurso = await _cursoRepository.CreateAsync(curso);
            return await GetByIdAsync(createdCurso.IdCurso) ?? throw new Exception("Error al crear el curso");
        }

        public async Task UpdateAsync(CursoDto cursoDto)
        {
            var curso = await _cursoRepository.GetByIdAsync(cursoDto.IdCurso);
            if (curso == null)
                throw new Exception("Curso no encontrado");

            await ValidateComisionExistsAsync(cursoDto.IdComision);
            
            if (!cursoDto.IdMateria.HasValue || cursoDto.IdMateria.Value <= 0)
                throw new Exception("Debe seleccionar una materia válida");
                
            ValidateMateriaExists(cursoDto.IdMateria.Value);
            await ValidatePlanCoincideAsync(cursoDto.IdMateria.Value, cursoDto.IdComision);
            
            ValidateAnioCalendario(cursoDto.AnioCalendario);
            ValidateCupo(cursoDto.Cupo);

            var inscriptosActuales = await _cursoRepository.GetInscriptosCountAsync(cursoDto.IdCurso);
            if (cursoDto.Cupo < inscriptosActuales)
                throw new Exception($"No se puede reducir el cupo a {cursoDto.Cupo} porque ya hay {inscriptosActuales} estudiantes inscriptos");

            curso.SetIdMateria(cursoDto.IdMateria);
            curso.SetIdComision(cursoDto.IdComision);
            curso.SetAnioCalendario(cursoDto.AnioCalendario);
            curso.SetCupo(cursoDto.Cupo);

            await _cursoRepository.UpdateAsync(curso);
        }

        public async Task DeleteAsync(int id)
        {
            var inscriptos = await _cursoRepository.GetInscriptosCountAsync(id);
            if (inscriptos > 0)
                throw new Exception($"No se puede eliminar el curso porque tiene {inscriptos} estudiantes inscriptos");

            await _cursoRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CursoDto>> GetByComisionAsync(int idComision)
        {
            var cursos = await _cursoRepository.GetByComisionAsync(idComision);
            var result = new List<CursoDto>();

            foreach (var curso in cursos)
            {
                var comision = await _comisionRepository.GetByIdAsync(curso.IdComision);
                var inscriptos = await _cursoRepository.GetInscriptosCountAsync(curso.IdCurso);

                string nombreMateria = "Sin Materia";
                if (curso.IdMateria.HasValue)
                {
                    var materia = _materiaRepository.GetById(curso.IdMateria.Value);
                    nombreMateria = materia?.Descripcion ?? "Materia no encontrada";
                }

                result.Add(new CursoDto
                {
                    IdCurso = curso.IdCurso,
                    IdMateria = curso.IdMateria,
                    NombreMateria = nombreMateria,
                    IdComision = curso.IdComision,
                    DescComision = comision?.DescComision ?? "Comisión no encontrada",
                    AnioCalendario = curso.AnioCalendario,
                    Cupo = curso.Cupo,
                    InscriptosActuales = inscriptos
                });
            }

            return result;
        }

        public async Task<IEnumerable<CursoDto>> GetByAnioCalendarioAsync(int anioCalendario)
        {
            var cursos = await _cursoRepository.GetByAnioCalendarioAsync(anioCalendario);
            var result = new List<CursoDto>();

            foreach (var curso in cursos)
            {
                var comision = await _comisionRepository.GetByIdAsync(curso.IdComision);
                var inscriptos = await _cursoRepository.GetInscriptosCountAsync(curso.IdCurso);

                string nombreMateria = "Sin Materia";
                if (curso.IdMateria.HasValue)
                {
                    var materia = _materiaRepository.GetById(curso.IdMateria.Value);
                    nombreMateria = materia?.Descripcion ?? "Materia no encontrada";
                }

                result.Add(new CursoDto
                {
                    IdCurso = curso.IdCurso,
                    IdMateria = curso.IdMateria,
                    NombreMateria = nombreMateria,
                    IdComision = curso.IdComision,
                    DescComision = comision?.DescComision ?? "Comisión no encontrada",
                    AnioCalendario = curso.AnioCalendario,
                    Cupo = curso.Cupo,
                    InscriptosActuales = inscriptos
                });
            }

            return result;
        }

        private async Task ValidateComisionExistsAsync(int idComision)
        {
            var comision = await _comisionRepository.GetByIdAsync(idComision);
            if (comision == null)
                throw new Exception("La comisión especificada no existe");
        }

        private void ValidateMateriaExists(int idMateria)
        {
            var materia = _materiaRepository.GetById(idMateria);
            if (materia == null)
                throw new Exception("La materia especificada no existe");
        }

        private async Task ValidatePlanCoincideAsync(int idMateria, int idComision)
        {
            var materia = _materiaRepository.GetById(idMateria);
            if (materia == null)
                throw new Exception("La materia especificada no existe");
                
            var comision = await _comisionRepository.GetByIdAsync(idComision);
            if (comision == null)
                throw new Exception("La comisión especificada no existe");
            
            if (materia.IdPlan != comision.IdPlan)
                throw new Exception($"La materia pertenece al plan {materia.IdPlan} pero la comisión pertenece al plan {comision.IdPlan}. Deben coincidir.");
        }

        private void ValidateAnioCalendario(int anioCalendario)
        {
            if (anioCalendario <= 0)
                throw new Exception("El año calendario debe ser un valor válido");
        }

        private void ValidateCupo(int cupo)
        {
            if (cupo <= 0)
                throw new Exception("El cupo debe ser mayor que cero");
            if (cupo > 100)
                throw new Exception("El cupo no puede ser mayor a 100 estudiantes");
        }
    }
}
