using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Data.Enitites
{
    public partial class LicitacionSimplificado
    {
        [Key]
        public int LicitacionId { get; set; }
        public String Nombre { get; set; } = null!;
        public int Estado { get; set; }
    }
}