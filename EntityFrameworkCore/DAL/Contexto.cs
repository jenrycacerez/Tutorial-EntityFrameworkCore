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

           
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                //Configurar clave primaria manualmente "Solo para la entidad de la Persona"
                modelBuilder.Entity<Personas>().Property(p => p.personaId).HasColumnName("Id").HasDefaultValue(0).IsRequired();


             


                modelBuilder.Entity<Estudiantes>()
                   .HasOne<DireccionEstudiante>(e => e.Direccion)
                   .WithOne(ad => ad.Estudiantes)
                   .HasForeignKey<DireccionEstudiante>(ad => ad.direccionEstudianteId);

               
                modelBuilder.Entity<Personas>().Property<String>("Ocupacion");
                modelBuilder.Entity<Personas>().Property<int>("Edad");
            }

           
        }



    
}
