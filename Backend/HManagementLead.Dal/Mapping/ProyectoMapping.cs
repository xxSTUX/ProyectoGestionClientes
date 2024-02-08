using HManagementLead.Data;
using HManagementLead.Data.Enitites;
using HManagementLead.Entities;
using System.Linq.Expressions;

namespace HManagementLead.Dal.Mapping;
    public static class ProyectoMapping
    {
        public static Expression<Func<Proyecto, ProyectoDetalle>> MapToProyecto(Microsoft.EntityFrameworkCore.DbSet<Seguimientos> seguimientos)
        {

            return p => new ProyectoDetalle
            {
                Id = p.Id,
                IdCliente = p.Cliente_id,
                Nombre = p.Nombre,
                Seguimientos = (from cs in p.Seguimientos
                                join s in seguimientos
                                on cs.Seguimiento_id equals s.Id
                                select new SeguimientoDetalle
                                {
                                    Id = s.Id,
                                    Nombre = s.Nombre,
                                }).ToList(),
            };
        }

        public static Expression<Func<Proyecto, ProyectoDetalle>> MapToProyecto()
        {

            return p => new ProyectoDetalle
            {
                Id = p.Id,
                IdCliente = p.Cliente_id,
                Nombre = p.Nombre,
            };
        }

    
    public static Expression<Func<Cliente, Codigo>> MapClienteToCodigo()
        {
            
            return p => new Codigo
            {
                Id = p.Id,
                Descripcion = p.Nombre,
            };
        }


        public static Expression<Func<Proyecto, Codigo>> MapProyectoToCodigo()
        {
            return p => new Codigo
            {
                Id = p.Id,
                Descripcion = p.Nombre,
            };
        }

        public static Expression<Func<SeguimientoClientes, TablaIntermedia>> MapSeguimientoToCodigo()
        {

            return p => new TablaIntermedia
            {
                IdSuperior = p.Cliente_id,
                IdModelo = p.Seguimiento_id,
            };
        }


}

