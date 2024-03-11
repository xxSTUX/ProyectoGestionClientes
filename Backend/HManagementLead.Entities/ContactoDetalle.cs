using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HManagementLead.Entities
{
    public class ContactoDetalle
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Cargo { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public bool Deleted { get; set; } = false;
    }
}
