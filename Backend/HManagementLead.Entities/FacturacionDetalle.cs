using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HManagementLead.Entities
{
    public class FacturacionDetalle
    {
        
        public int Id { get; set; }
        public string Datos { get; set; } = null!;
    }
}
