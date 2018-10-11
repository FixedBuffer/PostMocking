using PostMocking.Data;
using PostMocking.Model;
using System;

namespace PostMocking
{
    class Program
    {
        static void Main(string[] args)
        {
            using (PostMockingDbContext context = new PostMockingDbContext())
            {
                EmailSender emailSender = new EmailSender();
                GeneradorInformes generador = new GeneradorInformes(context, emailSender);
                if (generador.GenerarInforme("FixedBuffer", "jorge_turrado@hotmail.es"))
                    Console.WriteLine("Informe enviado con exito");
                else
                    Console.WriteLine("Problema al enviar el informe");
            }
        }
    }
}