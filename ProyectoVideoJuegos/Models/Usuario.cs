using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoVideoJuegos.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Username { get; set; }
        public string Contraseña { get; set; }
    }
}
