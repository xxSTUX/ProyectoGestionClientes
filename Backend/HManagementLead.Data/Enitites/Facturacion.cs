using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Data.Enitites
{
    public partial class Facturacion
    {
        public int Id { get; set; }
        public string Datos { get; set; } = null!;

        public virtual ICollection<FacturacionCliente> FacturacionesClientes { get; set; } = new List<FacturacionCliente>();
        public virtual ICollection<FacturacionProyecto> FacturacionesProyectos { get; set; } = new List<FacturacionProyecto>();
    }
}
