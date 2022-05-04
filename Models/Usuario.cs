using System;
using System.Collections.Generic;

namespace Mascotas_API.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Contrasenna { get; set; } = null!;
    }
}
