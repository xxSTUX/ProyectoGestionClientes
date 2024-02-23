using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Data.Enitites
{
    public partial class Puesto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<PuestoCliente> PuestosClientes { get; set; } = new List<PuestoCliente>();
        public virtual ICollection<PuestoProyecto> PuestosProyectos { get; set; } = new List<PuestoProyecto>();
    }
}
