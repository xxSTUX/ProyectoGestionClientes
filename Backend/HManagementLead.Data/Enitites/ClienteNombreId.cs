using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Data.Enitites
{
    public partial class ClienteNombreId
    {
        [Key]
        public int id { get; set; }
        public String Nombre { get; set; } = null!;
       
    }
}
