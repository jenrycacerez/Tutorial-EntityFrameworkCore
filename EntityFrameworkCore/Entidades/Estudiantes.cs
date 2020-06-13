using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFrameworkCore.Entidades
{
    public class Estudiantes
    {
        [Key]
        public int EstudianteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public DireccionEstudiante Direccion { get; set; }

        public Estudiantes()
        {
            EstudianteId = 0;
            Nombre = string.Empty;
            Apellido = string.Empty;
        }

    }
}
