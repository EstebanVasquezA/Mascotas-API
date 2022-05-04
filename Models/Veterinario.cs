using System;
using System.Collections.Generic;

namespace Mascotas_API.Models
{
    public partial class Veterinario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int Telefono { get; set; }
    }
}
