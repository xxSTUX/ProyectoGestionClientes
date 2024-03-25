using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Data.Enitites
{
    public partial class SeguimientoSimplificado
    {
        [Key]
        public int SeguimientoId { get; set; }
        public String Nombre { get; set; } = null!;
    }
}