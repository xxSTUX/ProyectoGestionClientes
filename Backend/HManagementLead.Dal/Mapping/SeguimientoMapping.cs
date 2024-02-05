using HManagementLead.Data;
using HManagementLead.Data.Enitites;
using HManagementLead.Entities;
using System.Linq.Expressions;

namespace HManagementLead.Dal.Mapping
{
    public static class SeguimientoMapping
    {
        public static Expression<Func<Seguimiento, SeguimientoDetalle>> MapToSeguimiento()
        {
            
            return p => new SeguimientoDetalle
            {
                Id = p.Id,
                Fecha = p.Fecha,
                
            };
        }

        public static Expression<Func<Seguimiento, Codigo>> MapSeguimientoToCodigo()
        {
            
            return p => new Codigo
            {
                Id = p.Id,
                Descripcion = p.Fecha.ToLongDateString(),
            };
        }
    }
}
