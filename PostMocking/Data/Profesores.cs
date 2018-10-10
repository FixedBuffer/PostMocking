using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PostMocking.Data
{
    public partial class Profesor
    {
        public Profesor()
        {
            Cursos = new HashSet<Curso>();
        }
        [Key]
        public int IdProfesor { get; set; }
        public string Nombre { get; set; }

        public ICollection<Curso> Cursos { get; set; }
    }
}
