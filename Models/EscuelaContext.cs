using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Models
{
    public class EscuelaContext : DbContext
    {
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Evaluación> Evaluaciones { get; set; }

        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var escuela = new Escuela();
            escuela.AñoDeCreación = 2005;
            escuela.Id = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi school";
            escuela.Ciudad = "Guadalajara";
            escuela.Pais = "México";
            escuela.Dirección = "calle 3 hull";
            escuela.TipoEscuela = TiposEscuela.Secundaria;

            //Agregamos los cursos de la escuela
            var Cursos = CargarCursos(escuela);

            //por cada curso cargar asignaturas
            var asignaturas = CargarAsignaturas(Cursos);

            //por cada curso cargar alumnos
            var alumnos = CargarAlumnos(Cursos);

            modelBuilder.Entity<Escuela>().HasData(escuela);
            modelBuilder.Entity<Curso>().HasData(Cursos.ToArray());
            modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
            modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray());
        }

        private List<Curso> CargarCursos(Escuela escuela)
        {
            return new List<Curso>(){
                        new Curso(){
                            Id = Guid.NewGuid().ToString(),
                            EscuelaId = escuela.Id,
                            Nombre = "101",
                            Jornada = TiposJornada.Mañana },
                        new Curso() {Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id,Nombre = "201", Jornada = TiposJornada.Mañana},
                        new Curso{Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id,Nombre = "301", Jornada = TiposJornada.Mañana},
                        new Curso(){Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "401", Jornada = TiposJornada.Tarde },
                        new Curso() {Id = Guid.NewGuid().ToString(),EscuelaId = escuela.Id,Nombre = "501", Jornada = TiposJornada.Tarde},
            };
        }

        private List<Alumno> CargarAlumnos(List<Curso> cursos)
        {
            var LstAlumnos = new List<Alumno>();
            Random rnd = new Random();
            foreach (var curso in cursos)
            {
                int cantidad = rnd.Next(5, 20);
                var LstAlumnosTemp = GenerarAlumnosAlAzar(curso, cantidad);
                LstAlumnos.AddRange(LstAlumnosTemp);
            }
            return LstAlumnos;
        }

        private List<Asignatura> CargarAsignaturas(List<Curso> Cursos)
        {
            List<Asignatura> LstCompleta = new List<Asignatura>();
            foreach (var curso in Cursos)
            {
                var listaAsignaturas = new List<Asignatura>(){
                            new Asignatura{Nombre="Matemáticas", Id = Guid.NewGuid().ToString(), CursoId = curso.Id} ,
                            new Asignatura{Nombre="Educación Física", Id = Guid.NewGuid().ToString(),CursoId = curso.Id},
                            new Asignatura{Nombre="Castellano", Id = Guid.NewGuid().ToString(),CursoId = curso.Id},
                            new Asignatura{Nombre="Ciencias Naturales", Id = Guid.NewGuid().ToString(),CursoId = curso.Id},
                            new Asignatura{Nombre="Programación", Id = Guid.NewGuid().ToString(),CursoId = curso.Id}
                };
                LstCompleta.AddRange(listaAsignaturas);
            }

            return LstCompleta;
        }

        private List<Alumno> GenerarAlumnosAlAzar(Curso curso, int cantidad = 0)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno
                               {
                                   Nombre = $"{n1} {n2} {a1}",
                                   Id = Guid.NewGuid().ToString(),
                                   CursoId = curso.Id
                               };
            if (cantidad == 0)
                return listaAlumnos.OrderBy((al) => al.Id).ToList();
            else
                return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
        }

    }
}