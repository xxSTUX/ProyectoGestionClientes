using HManagementLead.Data;
using HManagementLead.Data.Enitites;
using HManagementLead.Entities;
using System.Linq.Expressions;

namespace HManagementLead.Dal.Mapping
{
    public static class ClienteMapping
    {
        public static Expression<Func<Cliente, ClienteDetalle>> MapToClientDetalleConProyecto(Microsoft.EntityFrameworkCore.DbSet<Seguimiento> seguimientos)
        {

            return c => new ClienteDetalle
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Proyectos = c.Proyectos.AsQueryable().Select(MapProyectoToCodigo()).ToList(),
                SeguimientoClientes = (from cs in c.Seguimientos 
                                      join s in seguimientos
                                      on cs.IdSeguimiento equals s.Id
                                      select new SeguimientoDetalle
                                      {
                                          Id = s.Id,
                                          Fecha = s.Fecha,
                                      }).ToList(),
            };
        }
        public static Expression<Func<Cliente, ClienteDetalle>> MapToClientDetalleConProyecto()
        {

            return p => new ClienteDetalle
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Proyectos = p.Proyectos.AsQueryable().Select(MapProyectoToCodigo()).ToList(),
                Seguimientos = p.Seguimientos.AsQueryable().Select(MapSeguimienClientestoToTablaIntermedia()).ToList(),
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

        public static Expression<Func<Seguimiento, Codigo>> MapSeguimientoToCodigo()
        {

            return p => new Codigo
            {
                Id = p.Id,
                Descripcion = p.Fecha.ToLongDateString(),
            };
        }
        public static Expression<Func<SeguimientoClientes, TablaIntermedia>> MapSeguimienClientestoToTablaIntermedia()
        {

            return p => new TablaIntermedia
            {
                IdSuperior = p.IdCliente,
                IdModelo = p.IdSeguimiento,
            };
        }
    }
}
