using HManagementLead.Data;
using HManagementLead.Data.Enitites;
using HManagementLead.Entities;
using System.Linq.Expressions;

namespace HManagementLead.Dal.Mapping
{
    public static class LicitacionMapping
    {
        public static Expression<Func<Licitaciones, LicitacionDetalle>> MapToLicitacion()
        {

            return p => new LicitacionDetalle
            {
                Id = p.Id,
                Nombre = p.Nombre,

            };
        }

        public static Expression<Func<Licitaciones, LicitacionDetalle>> MapToCreateLicitacion()
        {

            return p => new LicitacionDetalle
            {
                Id = p.Id,
                Nombre = p.Nombre,

            };
        }

        public static Expression<Func<Licitaciones, Codigo>> MapLicitacionToCodigo()
        {

            return p => new Codigo
            {
                Id = p.Id,
                Descripcion = p.Nombre,
            };
        }
    }
}
