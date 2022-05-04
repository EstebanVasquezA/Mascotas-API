using System;
using System.Collections.Generic;

namespace Mascotas_API.Models
{
    public partial class Raza
    {
        public Raza()
        {
            Mascota = new HashSet<Mascotum>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Mascotum> Mascota { get; set; }
    }
}
