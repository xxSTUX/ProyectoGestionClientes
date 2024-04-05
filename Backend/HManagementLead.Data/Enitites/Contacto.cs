using HManagementLead.Entities;
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
        public string Nombre { get; set; }
        public string Rol { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public int Nivel { get; set; }
        public bool Eliminado { get; set; } = false;

        public virtual ICollection<ContactoCliente> ContactosClientes { get; set; } = new List<ContactoCliente>();
        public virtual ICollection<ProyectoContacto> ProyectosContactos { get; set; } = new List<ProyectoContacto>();
        public Contacto() { }
        public Contacto(ContactoDetalle cotnacto)
        {
            Id = cotnacto.Id;
            Nombre = cotnacto.Nombre;
            Rol = cotnacto.Rol;
            Email = cotnacto.Email;
            Telefono = cotnacto.Telefono;
            Nivel = cotnacto.Nivel;
            Eliminado = cotnacto.Eliminado;
        }
    }
}
