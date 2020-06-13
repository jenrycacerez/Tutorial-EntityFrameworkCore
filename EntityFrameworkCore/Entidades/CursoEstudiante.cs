using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFrameworkCore.Entidades
{
    public class CursoEstudiante
    {
        [Key]
        public int EstcursoId { get; set; }

        public int EstudianteId { get; set; }
        public Estudiantes Estudentes { get; set; }

        public int CursoId { get; set; }
        public Curso Curso { get; set; }

    }
}
