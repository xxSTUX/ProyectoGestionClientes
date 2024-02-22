using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Data.Enitites
{
    [PrimaryKey(nameof(ProyectoId), nameof(ContactoId))]
    public partial class ProyectoContacto
    {
        public int ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; } = null!;
        public int ContactoId { get; set; }
        public Contacto Contacto { get; set; } = null!;
    }
}
