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
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public int Nivel {  get; set; }
        public bool Eliminado { get; set; } = false;
    }
}
