using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using EntityFrameworkCore.DAL;
using EntityFrameworkCore.Entidades;
using System;
using System.Collections.Generic;


using System.Text;
using System.Linq;

namespace EntityFrameworkCore.Ejercicio
{
    public class Tutorial
    {

        public static void GuardarStudent()
        {
            
            Contexto Context = new Contexto();
            try
            {
                var auxStudent = new Estudiantes()
                {
                    EstudianteId = 0,
                    Nombre = "Jenry",
                    Apellido = "Cacerez"

                };
                Context.Estudiantes.Add(auxStudent);
                bool save = Context.SaveChanges() > 0;

                if (save)
                    Console.WriteLine("Estudiante Guardado !!");
                else
                    Console.WriteLine("no guardado");
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Context.Dispose();
            }

        }

        public static void GuardarCourse()
        {
           
            Contexto context = new Contexto();
            try
            {
                var auxCourse = new Curso()
                {
                    CursoId = 0,
                    EstudianteId = 1,
                    NombreCurso = "naturales"

                };

                var address = new DireccionEstudiante()
                {
                    ciudad = "Cotui",
                    provincia = "Sanches ramires",
                    pais = "Rep Dom."
                };

                context.Curso.Add(auxCourse);
                context.DireccionEstudiantes.Add(address);
                bool save = context.SaveChanges() > 0;

                if (save)
                    Console.WriteLine("El curso se guardo !");
                else
                    Console.WriteLine("no se pudo guardar");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                context.Dispose();
            }
        }

        public static void SimpleQuery()
        {
            
            const string Nombree = "Jenry";
            Contexto context = new Contexto();
            try
            {
                var list = context.Estudiantes.Where(s => s.Nombre == Nombree).ToList();
                if (list != null)
                    Console.WriteLine(list.Find(s => s.Nombre == Nombree).Nombre);
                else
                    Console.WriteLine("no se pudo encontrar al estudiante");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                context.Dispose();
            }
        }

        public static void DoubleQuery()
        {
            
            const string Nombres = "juan";
            Contexto context = new Contexto();
            try
            {
                var resultado = context.Curso.Where(c => c.NombreCurso == "Matematica")
                .Include(c => c.Estudiantes.Nombre == Nombres).FirstOrDefault();

                if (resultado != null)
                    Console.WriteLine(resultado.NombreCurso.ToString());
                else
                    Console.WriteLine("Estudiante No Encontrado!");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                context.Dispose();
            }

        }

        public static void QuerryUsingSql()
        {
            
            Contexto context = new Contexto();
            List<Estudiantes> studentList = new List<Estudiantes>();
            try
            {

                studentList = context.Estudiantes.FromSqlRaw("Select *from dbo.Students").ToList();
                if (studentList != null)
                    Console.WriteLine(studentList.Find(s => s.Nombre == "Bill").Nombre);
                else
                    Console.WriteLine("Estudiante No Encontrado");
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }

        }

        public static void UpdatingData()
        {
            
            Contexto context = new Contexto();

            try
            {
                var std = context.Estudiantes.First<Estudiantes>();
                std.Nombre = "Ana";
                bool modified = context.SaveChanges() > 0;

                if (modified)
                    Console.WriteLine(" modificado");
                else
                    Console.WriteLine("No se modifico");

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
        }

        public static void DeletingData()
        {
            Contexto context = new Contexto();
            
            try
            {
                var std = context.Estudiantes.First<Estudiantes>();
                context.Estudiantes.Remove(std);
                bool deleted = context.SaveChanges() > 0;

                if (deleted)
                    Console.WriteLine(" eliminado");
                else
                    Console.WriteLine("No se pudo eliminar");

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
        }

        public static void ConsultaStudents()
        {
           

            var context = new Contexto();

            try
            {
                var studentsWithSameName = context.Estudiantes.ToList();

                if (studentsWithSameName != null)
                    foreach (var auxiliar in studentsWithSameName)
                    {
                        Console.WriteLine(auxiliar.Nombre);
                    }
                else
                    Console.WriteLine("No se encontro ningun estudiante");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                context.Dispose();
            }
        }

       
        public static void UpdatingOnDisconnectedScenario()
        {
            Contexto context = new Contexto();
            try
            {
                var modifiedStudent1 = new Estudiantes()
                {
                    EstudianteId = 1,
                    Nombre = "Bill",
                    Apellido = "Madison"
                };

                var modifiedStudent2 = new Estudiantes()
                {
                    EstudianteId = 2,
                    Nombre = "Steve",
                    Apellido = "Perez"
                };

                List<Estudiantes> modifiedStudents = new List<Estudiantes>()
                {
                    modifiedStudent1,
                    modifiedStudent2,
                };

                context.UpdateRange(modifiedStudents);
                bool modified = context.SaveChanges() > 0;
                if (modified)
                    Console.WriteLine("Modificado");

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }

        }

        public static void DeletingOnDisconnectedScenario()
        {
            Contexto context = new Contexto();

            try
            {
                List<Estudiantes> StudentList = new List<Estudiantes>()
                {
                   new Estudiantes()
                   {
                       EstudianteId = 1
                   },
                   new Estudiantes()
                   {
                       EstudianteId  = 2
                   }
                };

                context.RemoveRange(StudentList);
                bool removed = context.SaveChanges() > 0;

                if (removed)
                    Console.WriteLine("Lista eliminada");
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
        }

        public static void ChangeTracker()
        {
            
            Contexto contexto = new Contexto();
            try
            {
                var student = contexto.Estudiantes.First();
                student.Apellido = "Cambiando Apellido";
                MostrarEstado(contexto.ChangeTracker.Entries());

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

        }

        private static void MostrarEstado(IEnumerable<EntityEntry> entries)
        {
            foreach (var entry in entries)
            {
                Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: { entry.State.ToString()}");
            }
        }

        public static void DetachedContext()
        {
         
            Contexto contexto = new Contexto();
            try
            {
                var disconnectedEntity = new Estudiantes() { EstudianteId = 1, Nombre = "Bill" };
                Console.Write(contexto.Entry(disconnectedEntity).State);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
        }

        public static void EntityGraphDisconnected()
        {
            
            Contexto contexto = new Contexto();
            try
            {
                var course = new Curso()
                {
                    CursoId = 1,
                    NombreCurso = "Math",
                    Estudiantes = new Estudiantes()
                    {
                        EstudianteId = 1,
                        Nombre = "Bill",
                        Apellido = "Ben"
                    }
                };

                contexto.Update(course);
                MostrarEstado(contexto.ChangeTracker.Entries());

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
        }



        public static void QuerryParametrizado()
        {
           
            Contexto context = new Contexto();
            List<Estudiantes> studentList = new List<Estudiantes>();
            string name = "Michael";
            try
            {

                studentList = context.Estudiantes.FromSqlRaw($"Select * from dbo.Students where FirstName = '{name}'").ToList();


                if (studentList != null)
                    Console.WriteLine(studentList.Find(s => s.Nombre == name).Nombre);
                else
                    Console.WriteLine("no se pudo encontrar al estudiante");
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }

        }

    }
}


