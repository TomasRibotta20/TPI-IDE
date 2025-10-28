using System;

namespace Domain.Model
{
    public class Curso
    {
        public int IdCurso { get; set; }
        public int? IdMateria { get; set; } // Nullable temporalmente hasta que implementemos Materia
        public int IdComision { get; set; }
        public int AnioCalendario { get; set; }
        public int Cupo { get; set; }

        private Curso() { }

        public Curso(int? idMateria, int idComision, int anioCalendario, int cupo)
        {
            SetIdMateria(idMateria);
            SetIdComision(idComision);
            SetAnioCalendario(anioCalendario);
            SetCupo(cupo);
            IdCurso = 0; // El ID es asignado por la base de datos
        }

        public Curso(int idCurso, int? idMateria, int idComision, int anioCalendario, int cupo)
        {
            SetIdCurso(idCurso);
            SetIdMateria(idMateria);
            SetIdComision(idComision);
            SetAnioCalendario(anioCalendario);
            SetCupo(cupo);
        }

        public void SetIdCurso(int idCurso)
        {
            if (idCurso <= 0)
                throw new ArgumentException("El ID del curso debe ser mayor que cero.", nameof(idCurso));
            IdCurso = idCurso;
        }

        public void SetIdMateria(int? idMateria)
        {
            if (idMateria.HasValue && idMateria.Value <= 0)
                throw new ArgumentException("El ID de la materia debe ser mayor que cero.", nameof(idMateria));
            IdMateria = idMateria;
        }

        public void SetIdComision(int idComision)
        {
            if (idComision <= 0)
                throw new ArgumentException("El ID de la comisin debe ser mayor que cero.", nameof(idComision));
            IdComision = idComision;
        }

        public void SetAnioCalendario(int anioCalendario)
        {
            if (anioCalendario <= 0)
                throw new ArgumentException("El ao calendario debe ser un valor vlido.", nameof(anioCalendario));
            AnioCalendario = anioCalendario;
        }

        public void SetCupo(int cupo)
        {
            if (cupo <= 0)
                throw new ArgumentException("El cupo debe ser mayor que cero.", nameof(cupo));
            if (cupo > 100)
                throw new ArgumentException("El cupo no puede ser mayor a 100 estudiantes.", nameof(cupo));
            Cupo = cupo;
        }
    }
}