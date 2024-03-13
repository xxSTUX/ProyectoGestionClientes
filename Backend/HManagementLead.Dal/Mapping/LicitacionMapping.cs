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
                Id = p.Id,
                Descripcion = p.Nombre,
            };
        }
        //Map para simplificar los dats que van al arbol
        public static Expression<Func<Cliente, LicitacionSimplificado>> MapLicitacionToLicitacionSimplificado()
        {

            return p => new LicitacionSimplificado
            {
                LicitacionId = p.Id,
                Nombre = p.Nombre,
            };
        }
    }
}
