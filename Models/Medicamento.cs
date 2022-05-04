using System;
using System.Collections.Generic;

namespace Mascotas_API.Models
{
    public partial class Medicamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
    }
}
