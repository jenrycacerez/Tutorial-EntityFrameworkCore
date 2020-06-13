using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFrameworkCore.Entidades
{
    public class DireccionEstudiante
    {
        [Key]
        public int direccionEstudianteId { get; set; }
        public string direccion { get; set; }
        public string ciudad { get; set; }
        public string provincia { get; set; }
        public string pais { get; set; }
        public int estudianteId { get; set; }
        public Estudiantes Estudiantes { get; set; }
    }
}
