using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PostMocking.Data
{
    public partial class Alumnos
    {
        [Key]
        public int IdAlumno { get; set; }
        public string Nombre { get; set; }
        public DateTime Nacimiento { get; set; }
        public int IdCurso { get; set; }

        public Cursos Curso { get; set; }
    }
}
