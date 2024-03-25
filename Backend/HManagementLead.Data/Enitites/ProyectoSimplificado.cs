using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Data.Enitites
{
    public partial class ProyectoSimplificado
    {
        [Key]
        public int ProyectoId { get; set; }
        public String Nombre { get; set; } = null!;
        public List<SeguimientoSimplificado> Seguimientos { get; set; } = new List<SeguimientoSimplificado>();
        public List<LicitacionSimplificado> Licitaciones { get; set; } = new List<LicitacionSimplificado>();
    }
}