using HManagementLead.Data;
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
    internal class AreaMapping
    {
        public static Expression<Func<Puesto, AreaDetalle>> MapToArea()
        {

            return p => new AreaDetalle
            {
                Id = p.Id,
                Nombre = p.Nombre
            };
        }
        public static Expression<Func<Area, Codigo>> MapAreaToCodigo()
        {

            return p => new Codigo
            {
                CodigoId = p.Id,
                Descripcion = p.Nombre
            };
        }
    }
}
