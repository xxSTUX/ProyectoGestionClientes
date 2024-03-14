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
    internal class PuestoMapping
    {
        public static Expression<Func<Puesto, PuestoDetalle>> MapToPuesto()
        {

            return p => new PuestoDetalle
            {
                Id = p.Id,
                Nombre = p.Nombre
            };
        }
        public static Expression<Func<Puesto, Codigo>> MapPuestoToCodigo()
        {

            return p => new Codigo
            {
                CodigoId = p.Id,
                Descripcion = p.Nombre
            };
        }
    }
}
