using EntityFrameworkCore.Entidades;
using Microsoft.EntityFrameworkCore;
using System;

using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.DAL
{
    public class Contexto : DbContext
    {
        
            public DbSet<Estudiantes> Estudiantes { get; set; }
            public DbSet<Curso> Curso { get; set; }
            public DbSet<Personas> Personas { get; set; }

            public DbSet<CursoEstudiante> CursoEstudiantes { get; set; }
            public DbSet<DireccionEstudiante> DireccionEstudiantes { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server = .\SqlExpress; Database = SchoolDB; Trusted_Connection = True; ");
            }

            //Ejemplo del modelBuilder
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                //Con estas configuraciones, fuerzo a colocar la clave primaria manualmente "Solo para la entidad de la Persona"
                modelBuilder.Entity<Personas>().Property(p => p.personaId).HasColumnName("Id").HasDefaultValue(0).IsRequired();


                //Relacion de uno a Varios
                /*modelBuilder.Entity<Estudiante>()
                    .HasOne<Grado>(e => e.Grade)
                    .WithMany(g => g.Estudiantes) //WithOne si se quiere relacion de 1 a 1
                    .HasForeignKey(e => e.GradoId);
                //Para eliminar en Cascada
                modelBuilder.Entity<Grade>()
                    .HasMany<Estudiante>(g => g.Student)
                    .WithOne(e => e.Grade)
                    .HasForeignKey(e => e.GradeId)
                    .OnDelete(DeleteBehavior.Cascade);//ClientNull si lo que se quiere es que en la otra tabla se ponga valor nulo*/

                //Para Relacion varios a varios
                //modelBuilder.Entity<Studentcourse>().HasKey(ec => new { ec.Studentid, ec.Courseid });


                modelBuilder.Entity<Estudiantes>()
                   .HasOne<DireccionEstudiante>(e => e.Direccion)
                   .WithOne(ad => ad.Estudiantes)
                   .HasForeignKey<DireccionEstudiante>(ad => ad.direccionEstudianteId);

                //Propiedad sombra
                modelBuilder.Entity<Personas>().Property<String>("Ocupacion");
                modelBuilder.Entity<Personas>().Property<int>("Edad");
            }

           
        }



    
}
