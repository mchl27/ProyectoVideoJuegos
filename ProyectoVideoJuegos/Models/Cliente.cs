using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoVideoJuegos.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Alquileres = new HashSet<Alquilere>();
        }

        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public virtual ICollection<Alquilere> Alquileres { get; set; }
    }
}
