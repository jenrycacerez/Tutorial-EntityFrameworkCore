using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFrameworkCore.Entidades
{
    //Creando Clase Curso
    public class Curso
    {
        [Key]
        public int CursoId { get; set; }
        public string NombreCurso { get; set; }

        public string Descripcion { get; set; }

        public int EstudianteId { get; set; }
        [ForeignKey("EstudianteId")]
        public virtual Estudiantes Estudiantes { get; set; }

        public Curso()
        {
            CursoId = 0;
            NombreCurso = string.Empty;
            EstudianteId = 0;
            Descripcion = string.Empty;

        }
    }
}
