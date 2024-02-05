using HManagementLead.Data;
using HManagementLead.Data.Enitites;
using HManagementLead.Entities;
using System.Linq.Expressions;

namespace HManagementLead.Dal.Mapping;
    public static class ProyectoMapping
    {
        public static Expression<Func<Proyecto, ProyectoDetalle>> MapToProyecto(String nombreCliente)
        {
            
            return p => new ProyectoDetalle
            {
                Id = p.Id,
                IdCliente = p.IdCliente,
                Nombre = p.Nombre,
                FechaCreacion = p.FechaCreacion.Date,
                NombreCliente = nombreCliente,


            };
        }
        public static Expression<Func<Proyecto, ProyectoDetalle>> MapToProyecto()
        {

            return p => new ProyectoDetalle
            {
                Id = p.Id,
                IdCliente = p.IdCliente,
                Nombre = p.Nombre,
                FechaCreacion = p.FechaCreacion.Date,
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
                IdSuperior = p.IdCliente,
                IdModelo = p.IdSeguimiento,
            };
        }


}

