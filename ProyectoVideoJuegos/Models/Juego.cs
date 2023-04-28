using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoVideoJuegos.Models
{
    public partial class Juego
    {
        public Juego()
        {
            Alquileres = new HashSet<Alquilere>();
            Precios = new HashSet<Precio>();
        }

        public int IdJuego { get; set; }
        public string Titulo { get; set; }
        public int Año { get; set; }
        public string Protagonistas { get; set; }
        public string Director { get; set; }
        public string Productor { get; set; }
        public string Plataforma { get; set; }
        public decimal PrecioAlquiler { get; set; }

        public virtual ICollection<Alquilere> Alquileres { get; set; }
        public virtual ICollection<Precio> Precios { get; set; }
    }
}
