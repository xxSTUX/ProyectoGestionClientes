using HManagementLead.Data;
using HManagementLead.Data.Enitites;
using HManagementLead.Entities;
using System.Linq.Expressions;

namespace HManagementLead.Dal.Mapping
{
    public static class SeguimientoMapping
    {
        public static Expression<Func<Seguimientos, SeguimientoDetalle>> MapToSeguimiento()
        {

            return p => new SeguimientoDetalle
            {
                Id = p.Id,
                Nombre = p.Nombre,

            };
        }

        public static Expression<Func<Seguimientos, SeguimientoDetalle>> MapToCreateSeguimiento()
        {

            return p => new SeguimientoDetalle
            {
                Id = p.Id,
                Nombre = p.Nombre,

            };
        }

        public static Expression<Func<Seguimientos, Codigo>> MapSeguimientoToCodigo()
        {

            return p => new Codigo
            {
                Id = p.Id,
                Descripcion = p.Nombre,
            };
        }
    }
}
