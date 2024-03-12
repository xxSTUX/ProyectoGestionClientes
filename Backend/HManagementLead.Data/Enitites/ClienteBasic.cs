using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Data.Enitites
{
    public partial class ClienteBasic
    {
        [Key]
        public int ClienteId { get; set; }
        public String Nombre { get; set; } = null!;
    }
}
