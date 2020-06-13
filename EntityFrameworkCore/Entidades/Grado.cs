using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFrameworkCore.Entidades
{
    public class Grado
    {
        [Key]
        public int GradoId { get; set; }
        public string NombreGrado { get; set; }
        public string seleccion { get; set; }
        public IList<Estudiantes> Estudiantes { get; set; }
    }
}
