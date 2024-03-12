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
                Nombre = p.Nombre,

            };
        }

        public static Expression<Func<Seguimiento, SeguimientoDetalle>> MapToCreateSeguimiento()
        {

            return p => new SeguimientoDetalle
            {
                Id = p.Id,
                Nombre = p.Nombre,

            };
        }

        public static Expression<Func<Seguimiento, Codigo>> MapSeguimientoToCodigo()
        {

            return p => new Codigo
            {
                CodigoId = p.Id,
                Descripcion = p.Nombre,
            };
        }
        public static Expression<Func<Cliente, SeguimientoBasic>> MapSeguimientoToSeguimientoBasic()
        {

            return p => new SeguimientoBasic
            {
                SeguimientoId = p.Id,
                Nombre = p.Nombre,
            };
        }
    }
}
