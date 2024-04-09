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
                Usuario = p.Usuario,

            };
        }

        public static Expression<Func<Seguimiento, SeguimientoDetalle>> MapToCreateSeguimiento()
        {

            return p => new SeguimientoDetalle
            {
                Id = p.Id,
                Usuario = p.Usuario,

            };
        }

        public static Expression<Func<Seguimiento, Codigo>> MapSeguimientoToCodigo()
        {

            return p => new Codigo
            {
                CodigoId = p.Id,
                Descripcion = p.Usuario,
            };
        }
        //Map para simplificar los dats que van al arbol
        public static Expression<Func<Seguimiento, SeguimientoSimplificado>> MapSeguimientoSimplificado()
        {

            return p => new SeguimientoSimplificado
            {
                SeguimientoId = p.Id,
                Nombre = p.Usuario,
            };
        }
    }
}
