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
        public static Expression<Func<Area, AreaDetalle>> MapToArea(ApplicationDbContext dbContext) //Igual que la funcion de arriba pero pasandole las licitaciones tambien
        {

            return p => new AreaDetalle
            {
                Id = p.Id,
                IdCliente = p.ClienteId,
                Nombre = p.Nombre,
                Responsable = p.Responsable,
                Email = p.Email,
                
                Seguimientos = (from cs in p.SeguimientosArea
                                join s in dbContext.Seguimientos
                                on cs.SeguimientoId equals s.Id
                                select new SeguimientoDetalle
                                { 
                                    Id = s.Id,
                                    Usuario = s.Usuario,
                                }).ToList(),
                Eliminado = p.Eliminado,
            };
        }
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
