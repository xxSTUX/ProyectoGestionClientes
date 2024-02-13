using HManagementLead.Data;
using HManagementLead.Data.Enitites;
using HManagementLead.Entities;
using System.Linq.Expressions;

namespace HManagementLead.Dal.Mapping
{
    public static class ContactoMapping
    {
        public static Expression<Func<Contactos, ContactoDetalle>> MapToContacto()
        {
            
            return p => new ContactoDetalle
            {
                Id = p.Id,
                Cargo = p.cargo,
                Email = p.email,
                Telefono = p.telefono,
                
            };
        }

        public static Expression<Func<Contactos, Codigo>> MapContactoToCodigo()
        {
            
            return p => new Codigo
            {
                Id = p.Id,
                Descripcion = p.email,
            };
        }
    }
}
