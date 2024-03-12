using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Data.Enitites
{
    public partial class ProyectoBasic
    {
        [Key]
        public int ProyectoId { get; set; }
        public String Nombre { get; set; } = null!;
        public List<SeguimientoBasic> Seguimientos { get; set; } = new List<SeguimientoBasic>();
        public List<LicitacionBasic> Licitaciones { get; set; } = new List<LicitacionBasic>();
    }
}
