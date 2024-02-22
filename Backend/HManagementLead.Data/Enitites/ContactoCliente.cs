using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Data.Enitites
{
    [PrimaryKey(nameof(ContactoId), nameof(ClienteId))]
    public partial class ContactoCliente
    {
        public int ContactoId { get; set; }
        public Contacto Contacto { get; set; } = null!;
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;
    }
}
