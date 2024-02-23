using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Data.Enitites
{
    [PrimaryKey(nameof(ProyectoId), nameof(FacturacionId))]
    public partial class FacturacionProyecto
    {
        public int ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; } = null!;
        public int FacturacionId { get; set; }
        public Facturacion Facturacion { get; set; } = null!;
    }
}
