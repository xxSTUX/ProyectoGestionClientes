using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Data.Enitites
{
    public partial class Contacto
    {
        public int Id { get; set; }

        public string Cargo { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public bool Eliminado { get; set; } = false;


        public virtual ICollection<ContactoCliente> ContactosClientes { get; set; } = new List<ContactoCliente>();
        public virtual ICollection<ProyectoContacto> ProyectosContactos { get; set; } = new List<ProyectoContacto>();
    }
}
