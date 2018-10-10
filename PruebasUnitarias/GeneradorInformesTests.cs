using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PostMocking.Data;
using PostMocking.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PruebasUnitarias
{
    [TestClass]
    public class GeneradorInformesTests
    {
        Mock<IEmailSender> emailSender;
        Mock<PostMockingDbContext> DbContext;
        public GeneradorInformesTests()
        {
            // Creamos el mock sobre nuestra interfazde envio de mensajes
            emailSender = new Mock<IEmailSender>();
            // Ante la llamada a su metodo enviar, retornamos un true, pero ademas serializamos al output del test el informe
            emailSender.Setup(m => m.Enviar(It.IsAny<string>(), It.IsAny<string>()))
                       .Returns((string destinatario, string mensaje) =>
                       {
                           Console.WriteLine(mensaje);
                           return true;
                       });


            var profesor = new Profesor { Nombre = "Jorge Turrado", IdProfesor = 1 };
            var curso = new Curso { IdProfesor = profesor.IdProfesor, Ciudad = "Vitoria", Nombre = "Mocking", Profesor = profesor };
            var alumno = new Alumno { IdCurso = curso.IdCurso, Curso = curso, Nombre = "Andres Garcia" };
            curso.Alumnos.Add(alumno);
            profesor.Cursos.Add(curso);
            var Profesores = new List<Profesor>()
            {
                 profesor
            }.AsQueryable();

            // Creamos el mock para la base de datos
            var mockSet = new Mock<DbSet<Profesor>>();
            mockSet.As<IQueryable<Profesor>>().Setup(m => m.Provider).Returns(Profesores.Provider);
            mockSet.As<IQueryable<Profesor>>().Setup(m => m.Expression).Returns(Profesores.Expression);
            mockSet.As<IQueryable<Profesor>>().Setup(m => m.ElementType).Returns(Profesores.ElementType);
            mockSet.As<IQueryable<Profesor>>().Setup(m => m.GetEnumerator()).Returns(Profesores.GetEnumerator());

            // Asignamos el mock de la base de datos al contexto
            DbContext = new Mock<PostMockingDbContext>();
            DbContext.Setup(c => c.Profesores).Returns(mockSet.Object);
        }

        [TestMethod]
        public void GenerarInformeValido()
        {
            // Creamos nuestra clase a testear y le pasamos los objetos mock
            GeneradorInformes generador = new GeneradorInformes(DbContext.Object, emailSender.Object);
            var result = generador.GenerarInforme("Jorge Turrado","");

            //Comprobamos el resultado
            Assert.AreEqual(true, result,"No se ha podido generar el informe");
        }

        [TestMethod]
        public void GenerarInformeInvalido()
        {
            // Creamos nuestra clase a testear y le pasamos los objetos mock
            GeneradorInformes generador = new GeneradorInformes(DbContext.Object, emailSender.Object);
            var result = generador.GenerarInforme("Pedro Mayo", "");

            //Comprobamos el resultado
            Assert.AreEqual(false, result, "Se ha podido generar el informe");
        }
    }
}
