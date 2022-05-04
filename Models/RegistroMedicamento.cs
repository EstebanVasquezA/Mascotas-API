using System;
using System.Collections.Generic;

namespace Mascotas_API.Models
{
    public partial class RegistroMedicamento
    {
        public DateTime Fecha { get; set; }
        public int Medicamento { get; set; }
        public int Mascota { get; set; }
        public int Veterinario { get; set; }

        public virtual Mascotum MascotaNavigation { get; set; } = null!;
        public virtual Medicamento MedicamentoNavigation { get; set; } = null!;
        public virtual Veterinario VeterinarioNavigation { get; set; } = null!;
    }
}
