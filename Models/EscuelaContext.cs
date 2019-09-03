using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ASP.Models
{
    public class EscuelaContext: DbContext
    {
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Curso> Cursos {get; set;}
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Evaluación> Evaluaciones { get; set; }
        
        public EscuelaContext(DbContextOptions<EscuelaContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var escuela = new Escuela();
            escuela.AñoDeCreación=2005;
            escuela.Id = Guid.NewGuid().ToString();
            escuela.Ciudad="Bogotá";
            escuela.Pais="Colombia";
            escuela.Dirección="Av. 232 #32";
            escuela.TipoEscuela=TiposEscuela.Secundaria;
            escuela.Nombre =  "Platzi";


            //cargar cursos de la escuela
           var cursos=  cargarCursos(escuela);

            //cargar cada curso cargar asignaturas
            var asignaturas=cargarAsignaturas(cursos);
            //cargar alumnos 

            var alumnos = CargarAlumnos(cursos);
            modelBuilder.Entity<Escuela>().HasData(escuela);
            modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
            modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
            modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray()); 
        }

        private List<Alumno> CargarAlumnos(List<Curso> cursos)
        {
            var listaAlumnos = new List<Alumno>();
            Random rnd = new Random();
            foreach(var curso in cursos)
            {
                int cantRandom = rnd.Next(5,20);
                var tmpList=GenerarAlumnosAlAzar(cantRandom, curso);
                listaAlumnos.AddRange(tmpList);

            }
            return listaAlumnos;
        }

        private List<Asignatura> cargarAsignaturas(List<Curso> cursos)
        {
            var listaCompletaAsignatura = new List<Asignatura>();
            foreach(var c in cursos) {
               
                    var tmpList=new List<Asignatura>{
                                new Asignatura{Nombre="Matemáticas",
                                Id=Guid.NewGuid().ToString(),
                                CursoId=c.Id
                                } ,
                                new Asignatura{Nombre="Educación Física",Id=Guid.NewGuid().ToString(),
                                CursoId=c.Id},
                                new Asignatura{Nombre="Castellano",
                                Id=Guid.NewGuid().ToString(),
                                CursoId=c.Id},
                                new Asignatura{Nombre="Ciencias Naturales",
                                Id=Guid.NewGuid().ToString(),
                                CursoId=c.Id},
                                new Asignatura{Nombre="Programacion",
                                Id=Guid.NewGuid().ToString(),
                                CursoId=c.Id}
                    };
                    listaCompletaAsignatura.AddRange(tmpList);
                    //c.Asignaturas=tmpList;
                

            }
            return listaCompletaAsignatura;

        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad, Curso curso)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { 
                                   Nombre = $"{n1} {n2} {a1}",
                               Id=Guid.NewGuid().ToString() ,
                               CursoId=curso.Id
                               };

            return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
        }

        private List<Curso> cargarCursos(Escuela escuela)
        {
                        var escCurso = new List<Curso>(){
                new Curso(){ Id = Guid.NewGuid().ToString(), EscuelaId=escuela.Id, Nombre="101", Jornada=TiposJornada.Mañana},
                new Curso(){ Id = Guid.NewGuid().ToString(), EscuelaId=escuela.Id, Nombre="201", Jornada=TiposJornada.Mañana},
                new Curso(){ Id = Guid.NewGuid().ToString(), EscuelaId=escuela.Id, Nombre="301", Jornada=TiposJornada.Tarde},
                new Curso(){ Id = Guid.NewGuid().ToString(), EscuelaId=escuela.Id, Nombre="401", Jornada=TiposJornada.Mañana},
                new Curso(){ Id = Guid.NewGuid().ToString(), EscuelaId=escuela.Id, Nombre="501", Jornada=TiposJornada.Tarde},
            };
            return escCurso;

        }
    }
}