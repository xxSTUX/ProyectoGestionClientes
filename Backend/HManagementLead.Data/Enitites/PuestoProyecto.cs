using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Data.Enitites
{
    [PrimaryKey(nameof(ProyectoId), nameof(PuestoId))]
    public partial class PuestoProyecto
    {
        public int ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; } = null!;
        public int PuestoId { get; set; }
        public Puesto Puesto { get; set; } = null!;
    }
}
