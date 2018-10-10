using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PostMocking.Data
{
    public partial class Profesores
    {
        public Profesores()
        {
            Cursos = new HashSet<Cursos>();
        }
        [Key]
        public int IdProfesor { get; set; }
        public string Nombre { get; set; }

        public ICollection<Cursos> Cursos { get; set; }
    }
}
