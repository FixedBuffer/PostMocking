using Microsoft.EntityFrameworkCore;
using PostMocking.Data;
using System.Linq;
using System.Text;

namespace PostMocking.Model
{
    public class GeneradorInformes
    {
        //Propiedad con la dependencia
        private IEmailSender emailSender { get; set; }
        private PostMockingDbContext context { get; set; }

        public GeneradorInformes(PostMockingDbContext context, IEmailSender emailSender)
        {
            this.context = context;
            this.emailSender = emailSender;
        }

        public bool GenerarInforme(string NombreProfesor, string Email)
        {
            //Obtenemos mediante LinQ los datos del profesor
            var Profesor = context.Profesores.Where(x => string.Compare(x.Nombre, NombreProfesor, true) == 0)
                                                .Include(x => x.Cursos)
                                                .ThenInclude(x => x.Alumnos)
                                                .FirstOrDefault();
            //En casode no encontrar nada, salimos
            if (Profesor is null)
                return false;

            //Generamos el informe de alumnos y cursos
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"El profesor {Profesor.Nombre} imparte los siguientes cursos:");
            foreach (var curso in Profesor.Cursos)
            {
                sb.AppendLine($"\t*{curso.Nombre} con los alumnos:");
                foreach (var alumno in curso.Alumnos)
                {
                    sb.AppendLine($"\t\t*{alumno.Nombre}");
                }
            }

            emailSender.Enviar(Email, sb.ToString());
            return true;
        }
    }
}