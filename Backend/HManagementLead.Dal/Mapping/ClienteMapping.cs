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
                Descripcion = c.Descripcion,
                Proyectos = c.Proyectos.AsQueryable().Select(ProyectoMapping.MapToProyecto(dbContext)).ToList(),
                Seguimientos = (from cs in c.SeguimientosClientes
                // Proyectos = c.Proyectos.AsQueryable().Select(ProyectoMapping.MapToProyecto()).ToList(),
                // Seguimientos = (from cs in c.SeguimientosClientes 
                                      join s in dbContext.Seguimientos
                                      on cs.SeguimientoId equals s.Id
                                      select new SeguimientoDetalle
                                      {
                                          Id = s.Id,
                                          Usuario = s.Usuario,
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
                                    Estado = l.Estado,
                                }).ToList(),
                Eliminado = c.Eliminado,
            };
        }
        //Arbol
        public static Expression<Func<Cliente, ClienteSimplificado>> MapToClientBasicDetalleConProyecto(ApplicationDbContext dbContext)
        {
            return c => new ClienteSimplificado
            {
                ClienteId = c.Id,
                Nombre = c.Nombre,
                Proyectos = c.Proyectos.AsQueryable().OrderBy(p => p.Nombre).Select(ProyectoMapping.MapTProyectoSimplificado(dbContext)).ToList(),
                Seguimientos = (from cs in c.SeguimientosClientes
                                join s in dbContext.Seguimientos
                                on cs.SeguimientoId equals s.Id
                                select new SeguimientoSimplificado
                                {
                                    SeguimientoId = s.Id,
                                    Nombre = s.Usuario,
                                }).OrderBy(s => s.Nombre).ToList(),
                Licitaciones = (from cl in c.LicitacionesClientes
                                join l in dbContext.Licitaciones
                                on cl.LicitacionId equals l.Id
                                select new LicitacionSimplificado
                                {
                                    LicitacionId = l.Id,
                                    Nombre = l.Nombre,
                                    Estado = l.Estado,
                                }).OrderBy(l => l.Nombre).ToList(),
                Eliminado = c.Eliminado,
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
