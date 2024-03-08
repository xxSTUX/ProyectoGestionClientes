using HManagementLead.Data;
using HManagementLead.Data.Enitites;
using HManagementLead.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace HManagementLead.Dal.Mapping
{
    public static class ClienteMapping
    {
        public static Expression<Func<Cliente, ClienteDetalle>> MapToClientDetalleConProyecto(ApplicationDbContext dbContext)
        {

            return c => new ClienteDetalle
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Proyectos = c.Proyectos.AsQueryable().Select(ProyectoMapping.MapToProyecto(dbContext)).ToList(),
                Seguimientos = (from cs in c.SeguimientosClientes
                // Proyectos = c.Proyectos.AsQueryable().Select(ProyectoMapping.MapToProyecto()).ToList(),
                // Seguimientos = (from cs in c.SeguimientosClientes 
                                      join s in dbContext.Seguimientos
                                      on cs.SeguimientoId equals s.Id
                                      select new SeguimientoDetalle
                                      {
                                          Id = s.Id,
                                          Nombre = s.Nombre,
                                          Fecha = s.Fecha,
                                          Observaciones = s.Observaciones,
                                      }).ToList(),
                Licitaciones = (from cl in c.LicitacionesClientes
                                join l in dbContext.Licitaciones
                                on cl.LicitacionId equals l.Id
                                select new LicitacionDetalle
                                {
                                    Id = l.Id,
                                    Nombre = l.Nombre,
                                    Tipo = l.Tipo,
                                    Ganada = l.Ganada,
                                }).ToList(),
            };
        }
        public static Expression<Func<Cliente, ClienteDetalle>> MapToClientDetalleConProyecto()
        {

            return p => new ClienteDetalle
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Proyectos = p.Proyectos.AsQueryable().Select(ProyectoMapping.MapToProyecto()).ToList(),
            };
        }
        public static Expression<Func<Cliente, ClienteDetalle>> MapToCreateClientDetalle()
        {

            return p => new ClienteDetalle
            {
                Id = p.Id,
                Nombre = p.Nombre
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

        public static Expression<Func<Seguimiento, Codigo>> MapSeguimientoToCodigo()
        {

            return p => new Codigo
            {
                CodigoId = p.Id,
                Descripcion = p.Nombre,
            };
        }
        public static Expression<Func<SeguimientoCliente, TablaIntermedia>> MapSeguimienClientestoToTablaIntermedia()
        {

            return p => new TablaIntermedia
            {
                IdSuperior = p.ClienteId,
                IdModelo = p.SeguimientoId,
            };
        }
    }
}
