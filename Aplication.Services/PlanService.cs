using Data;
using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public class PlanService
    {
        private readonly PlanRepository _repository;
        private readonly EspecialidadService _especialidadService;

        // Constructor para instanciación manual 
        public PlanService()
        {
            _repository = new PlanRepository();
            _especialidadService = new EspecialidadService();
        }

        // Constructor para inyección de dependencias
        public PlanService(PlanRepository repository, EspecialidadService especialidadService)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _especialidadService = especialidadService ?? throw new ArgumentNullException(nameof(especialidadService));
        }

        public IEnumerable<PlanDto> GetAll() 
        {
            var planes = _repository.GetAll();
            var especialidades = _especialidadService.GetAll();
            
            return planes.Select(plan => {
                var dto = MapToDto(plan);
                dto.DescripcionEspecialidad = especialidades.FirstOrDefault(e => e.Id == plan.EspecialidadId)?.Descripcion ?? "N/A";
                return dto;
            });
        }

        public PlanDto GetById(int id)
        {
            var plan = _repository.GetById(id);
            if (plan == null) return null;
            
            var dto = MapToDto(plan);
            var especialidad = _especialidadService.GetById(plan.EspecialidadId);
            dto.DescripcionEspecialidad = especialidad?.Descripcion ?? "N/A";
            return dto;
        }

        public void Add(PlanDto planDto)
        {
            // Validar que la especialidad exista
            if (_especialidadService.GetById(planDto.EspecialidadId) == null)
            {
                throw new ArgumentException($"La Especialidad con ID {planDto.EspecialidadId} no existe.");
            }
            var plan = MapToEntityForCreation(planDto);
            _repository.Add(plan);
        }

        public void Update(PlanDto planDto)
        {
            // Validar que el plan exista
            if (_repository.GetById(planDto.Id) == null)
            {
                throw new KeyNotFoundException($"Plan con ID {planDto.Id} no encontrado.");
            }
            // Validar que la especialidad exista
            if (_especialidadService.GetById(planDto.EspecialidadId) == null)
            {
                throw new ArgumentException($"La Especialidad con ID {planDto.EspecialidadId} no existe.");
            }
            var plan = MapToEntityForUpdate(planDto);
            _repository.Update(plan);
        }

        public void Delete(int id)
        {
            // Validar que el plan exista antes de eliminar
            if (_repository.GetById(id) == null)
            {
                throw new KeyNotFoundException($"Plan con ID {id} no encontrado.");
            }
            _repository.Delete(id);
        }

        private PlanDto MapToDto(Plan plan) => new PlanDto
        {
            Id = plan.Id,
            Descripcion = plan.Descripcion,
            EspecialidadId = plan.EspecialidadId
            // DescripcionEspecialidad se asigna en GetAll/GetById
        };

        private Plan MapToEntityForCreation(PlanDto dto) => new Plan(
            0, // El ID será asignado por la base de datos
            dto.Descripcion,
            dto.EspecialidadId
        );

        private Plan MapToEntityForUpdate(PlanDto dto) => new Plan(
            dto.Id,
            dto.Descripcion,
            dto.EspecialidadId
        );
    }
}
