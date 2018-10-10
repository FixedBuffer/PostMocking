using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PostMocking.Data
{
    public partial class Curso
    {
        public Curso()
        {
            Alumnos = new HashSet<Alumno>();
        }
        [Key]
        public int IdCurso { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public int IdProfesor { get; set; }

        public Profesor Profesor { get; set; }
        public ICollection<Alumno> Alumnos { get; set; }
    }
}
