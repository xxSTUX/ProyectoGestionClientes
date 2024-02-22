using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Data.Enitites
{
    [PrimaryKey(nameof(ClienteId), nameof(PuestoId))]
    public partial class PuestoCliente
    {
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;
        public int PuestoId { get; set; }
        public Puesto Puesto { get; set; } = null!;
    }
}
