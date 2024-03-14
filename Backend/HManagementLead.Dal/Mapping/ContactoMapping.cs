using HManagementLead.Data;
using HManagementLead.Data.Enitites;
using HManagementLead.Entities;
using System.Linq.Expressions;

namespace HManagementLead.Dal.Mapping
{
    public static class ContactoMapping
    {
        public static Expression<Func<Contacto, ContactoDetalle>> MapToContacto()
        {
            
            return p => new ContactoDetalle
            {
                Id = p.Id,
                Cargo = p.Cargo,
                Email = p.Email,
                Telefono = p.Telefono,
                eliminado = p.eliminado,
                
            };
        }

        public static Expression<Func<Contacto, Codigo>> MapContactoToCodigo()
        {
            
            return p => new Codigo
            {
                Id = p.Id,
                Descripcion = p.Email,
            };
        }
    }
}
