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
                Nombre = p.Nombre,
                Rol = p.Rol,
                Email = p.Email,
                Telefono = p.Telefono,
                Nivel = p.Nivel,
                Eliminado = p.Eliminado,
            };
        }

        public static Expression<Func<Contacto, Codigo>> MapContactoToCodigo()
        {
            
            return p => new Codigo
            {
                CodigoId = p.Id,
                Descripcion = p.Email,
            };
        }
    }
}
