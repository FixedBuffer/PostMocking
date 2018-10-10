using System;
using System.Collections.Generic;

namespace PostMocking.Data
{
    public partial class Profesores
    {
        public Profesores()
        {
            Cursos = new HashSet<Cursos>();
        }

        public int IdProfesor { get; set; }
        public string Nombre { get; set; }

        public ICollection<Cursos> Cursos { get; set; }
    }
}
