using HManagementLead.Data;
using HManagementLead.Data.Enitites;
using HManagementLead.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HManagementLead.Dal.Mapping;
    public static class ProyectoMapping
    {
        public static Expression<Func<Proyecto, ProyectoDetalle>> MapToProyecto(ApplicationDbContext dbContext)
        {

            return p => new ProyectoDetalle
            {
                Id = p.Id,
                IdCliente = p.ClienteId,
                Nombre = p.Nombre,
                Seguimientos = (from cs in p.SeguimientosProyectos
                                join s in dbContext.Seguimientos
                                on cs.SeguimientoId equals s.Id
                                select new SeguimientoDetalle
                                {
                                    Id = s.Id,
                                    Nombre = s.Nombre,
                                }).ToList()
            };   
        }

    public static Expression<Func<Proyecto, ProyectoDetalle>> MapToProyecto(DbSet<Seguimiento> seguimientos, DbSet<Licitacion> licitaciones) //Igual que la funcion de arriba pero pasandole las licitaciones tambien
    {

        return p => new ProyectoDetalle
        {
            Id = p.Id,
            IdCliente = p.ClienteId,
            Nombre = p.Nombre,
            Seguimientos = (from cs in p.SeguimientosProyectos
                            join s in seguimientos
                            on cs.SeguimientoId equals s.Id
                            select new SeguimientoDetalle
                            {
                                Id = s.Id,
                                Nombre = s.Nombre,
                            }).ToList(),
            Licitaciones = (from cl in p.LicitacionesProyectos
                            join l in licitaciones
                            on cl.LicitacionId equals l.Id
                            select new LicitacionDetalle
                            {
                                Id = l.Id,
                                Nombre = l.Nombre,
                            }).ToList()
        };
    }

    public static Expression<Func<Proyecto, ProyectoDetalle>> MapToProyecto()
        {

            return p => new ProyectoDetalle
            {
                Id = p.Id,
                IdCliente = p.ClienteId,
                Nombre = p.Nombre,
            };
        }

    
    public static Expression<Func<Cliente, Codigo>> MapClienteToCodigo()
        {
            
            return p => new Codigo
            {
                CodigoId = p.Id,
                Descripcion = p.Nombre,
            };
        }


        public static Expression<Func<Proyecto, Codigo>> MapProyectoToCodigo()
        {
            return p => new Codigo
            {
                CodigoId = p.Id,
                Descripcion = p.Nombre,
            };
        }

        public static Expression<Func<SeguimientoCliente, TablaIntermedia>> MapSeguimientoToCodigo()
        {

            return p => new TablaIntermedia
            {
                IdSuperior = p.ClienteId,
                IdModelo = p.SeguimientoId,
            };
        }


}

