using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoVideoJuegos.Models
{
    public partial class Alquilere
    {
        public int IdAlquiler { get; set; }
        public string Nombre { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaAlquiler { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Precio { get; set; }

        public virtual Cliente NombreNavigation { get; set; }
        public virtual Juego TituloNavigation { get; set; }
    }
}
