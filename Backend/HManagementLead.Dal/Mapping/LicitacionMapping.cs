using HManagementLead.Data;
using HManagementLead.Data.Enitites;
using HManagementLead.Entities;
using System.Linq.Expressions;

namespace HManagementLead.Dal.Mapping
{
    public static class LicitacionMapping
    {
        public static Expression<Func<Licitacion, LicitacionDetalle>> MapToLicitacion()
        {

            return p => new LicitacionDetalle
            {
                Id = p.Id,
                Nombre = p.Nombre,

            };
        }

        public static Expression<Func<Licitacion, LicitacionDetalle>> MapToCreateLicitacion()
        {

            return p => new LicitacionDetalle
            {
                Id = p.Id,
                Nombre = p.Nombre,

            };
        }

        public static Expression<Func<Licitacion, Codigo>> MapLicitacionToCodigo()
        {

            return p => new Codigo
            {
                CodigoId = p.Id,
                Descripcion = p.Nombre,
            };
        }
    }
}
