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
        [JsonIgnore]
        public int Id { get; set; }
        public string Datos { get; set; } = null!;
        public bool Eliminado { get; set; } = false;

    }
}
