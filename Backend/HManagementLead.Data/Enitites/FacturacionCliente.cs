using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Data.Enitites
{
    [PrimaryKey(nameof(ClienteId), nameof(FacturacionId))]
    public partial class FacturacionCliente
    {
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;
        public int FacturacionId { get; set; }
        public Facturacion Facturacion { get; set; } = null!; 

    }
}
