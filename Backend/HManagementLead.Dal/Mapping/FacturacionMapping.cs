using HManagementLead.Data.Enitites;
using HManagementLead.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Dal.Mapping
{
    public class FacturacionMapping
    {

        public static Expression<Func<Facturacion, FacturacionDetalle>> MapToFacturacion()
        {

            return f => new FacturacionDetalle
            {
                Id = f.Id,
                Datos = f.Datos
            };
        }
        public static Expression<Func<Facturacion, Codigo>> MapFacturacionToCodigo()
        {

            return f => new Codigo
            {
                Id = f.Id,
                Descripcion = f.Datos
            };
        }
    }
}
