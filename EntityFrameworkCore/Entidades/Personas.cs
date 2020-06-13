using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFrameworkCore.Entidades
{
    public class Personas
    {
        [Key]
        public int personaId { get; set; }
        public string nombre { get; set; }
        public string Apellido { get; set; }

        public Personas()
        {
            personaId = 0;
            nombre = string.Empty;
            Apellido = string.Empty;
        }
    }
}
