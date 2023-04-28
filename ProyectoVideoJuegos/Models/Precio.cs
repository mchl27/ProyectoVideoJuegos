using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoVideoJuegos.Models
{
    public partial class Precio
    {
        public int IdPrecio { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal Precio1 { get; set; }

        public virtual Juego TituloNavigation { get; set; }
    }
}
