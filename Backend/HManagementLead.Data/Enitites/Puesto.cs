using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Data.Enitites
{
    public partial class Puesto
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public bool Eliminado { get; set; } = false;


        public virtual ICollection<PuestoCliente> PuestosClientes { get; set; } = new List<PuestoCliente>();
        public virtual ICollection<PuestoProyecto> PuestosProyectos { get; set; } = new List<PuestoProyecto>();
    }
}
