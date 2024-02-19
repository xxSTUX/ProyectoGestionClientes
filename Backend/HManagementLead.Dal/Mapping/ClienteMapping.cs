﻿using HManagementLead.Data;
using HManagementLead.Data.Enitites;
using HManagementLead.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace HManagementLead.Dal.Mapping
{
    public static class ClienteMapping
    {
        public static Expression<Func<Cliente, ClienteDetalle>> MapToClientDetalleConProyecto(DbSet<Seguimientos> seguimientos, DbSet<Licitaciones> licitaciones)
        {

            return c => new ClienteDetalle
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Proyectos = c.Proyectos.AsQueryable().Select(ProyectoMapping.MapToProyecto(seguimientos)).ToList(),
                Seguimientos = (from cs in c.Seguimientos 
                                      join s in seguimientos
                                      on cs.Seguimiento_id equals s.Id
                                      select new SeguimientoDetalle
                                      {
                                          Id = s.Id,
                                          Nombre = s.Nombre,
                                      }).ToList(),
                licitaciones = (from cl in c.Licitaciones
                                join l in licitaciones
                                on cl.Licitacion_id equals l.Id
                                select new LicitacionDetalle
                                {
                                    Id = l.Id,
                                    Nombre = l.Nombre,
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

        public static Expression<Func<Seguimientos, Codigo>> MapSeguimientoToCodigo()
        {

            return p => new Codigo
            {
                Id = p.Id,
                Descripcion = p.Nombre,
            };
        }
        public static Expression<Func<SeguimientoClientes, TablaIntermedia>> MapSeguimienClientestoToTablaIntermedia()
        {

            return p => new TablaIntermedia
            {
                IdSuperior = p.Cliente_id,
                IdModelo = p.Seguimiento_id,
            };
        }
    }
}
