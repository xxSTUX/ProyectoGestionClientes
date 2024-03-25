using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Data.Enitites
{
    public partial class Facturacion
    {
        [Key]
        public int Id { get; set; }
        public string Datos { get; set; } = null!;
        public bool Eliminado { get; set; } = false;


        public virtual ICollection<FacturacionCliente> FacturacionesClientes { get; set; } = new List<FacturacionCliente>();
        public virtual ICollection<FacturacionProyecto> FacturacionesProyectos { get; set; } = new List<FacturacionProyecto>();
    }
}
