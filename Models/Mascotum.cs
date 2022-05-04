using System;
using System.Collections.Generic;

namespace Mascotas_API.Models
{
    public partial class Mascotum
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Color { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public double? Peso { get; set; }
        public int TipoMascota { get; set; }
        public int Raza { get; set; }

        public virtual Raza RazaNavigation { get; set; }
        public virtual TipoMascotum TipoMascotaNavigation { get; set; } 
    }
}
