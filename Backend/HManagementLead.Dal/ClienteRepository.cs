using HManagementLead.Dal.Interfaces;
using HManagementLead.Data;
using HManagementLead.Entities;
using Microsoft.EntityFrameworkCore;
using HManagementLead.Dal.Mapping;
using Microsoft.IdentityModel.Tokens;
using HManagementLead.Data.Enitites;

namespace HManagementLead.Dal
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;
        public ClienteRepository (ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            
        }

        public async Task<ClienteDetalle> GetClienteByIdAsync(int id)
        {
            return await _context.Clientes
                .Where(c => c.Id == id)
                .Select(ClienteMapping.MapToClientDetalleConProyecto(_context))
                .FirstAsync();
        }

        public async Task<List<ClienteDetalle>> GetAllClientesAsync()
        {
            if (_context.Clientes.IsNullOrEmpty()) { _context.Clientes.Add(new Cliente { Nombre = "Hiberus" , Descripcion = "Lorem Ipsum"}); }
            if(_context.EstadoProyecto.IsNullOrEmpty()) { _context.EstadoProyecto.Add(new EstadoProyecto { Estado = "Oportunidad" });
                                                          _context.EstadoProyecto.Add(new EstadoProyecto { Estado = "Aceptado" });
                                                          _context.EstadoProyecto.Add(new EstadoProyecto { Estado = "Finalizado" });
                                                          _context.EstadoProyecto.Add(new EstadoProyecto { Estado = "Rechazado" });
            }
            await _context.SaveChangesAsync();
            var cliente = await _context.Clientes.Select(ClienteMapping.MapToClientDetalleConProyecto(_context)).ToListAsync();
            return cliente;
        }

        public async Task<List<Codigo>> GetAllClientesAsyncToCodigo()
        {
            //if (_context.Clientes.IsNullOrEmpty()) { _context.Clientes.Add(new Cliente { Nombre = "Hiberus" }); }
            //await _context.SaveChangesAsync();
            var codigo = await _context.Clientes.Select(ClienteMapping.MapClienteToCodigo()).ToListAsync();
            return codigo;
        }

        public async Task<int> InsertClienteAsync(ClienteDetalle cliente) //Si esta mal, dejar esta
        {
            var nuevoCliente = new Cliente(cliente);
            _context.Clientes.Add(nuevoCliente);
            await _context.SaveChangesAsync();
            //foreach (ProyectoDetalle proyecto in cliente.Proyectos)
            //{
            //    var nuevoProyecto = new Proyecto
            //    {
            //        ClienteId = cliente.Id,
            //        Nombre = proyecto.Nombre,
            //        Estado = proyecto.Estado,
            //        Tipo = proyecto.Tipo
            //    };
            //    _context.Proyectos.Add(nuevoProyecto);
            //}
            //await _context.SaveChangesAsync();
            return nuevoCliente.Id;
        }

        public async Task<ClienteDetalle> UpdateClienteAsync(ClienteDetalle cliente)
        {
            
            var nuevoCliente = new Cliente(cliente);
            _context.Clientes.Add(nuevoCliente);
            _context.Update(nuevoCliente);
            await _context.SaveChangesAsync();

            return await _context.Clientes
                .Where(c => c.Id == cliente.Id)
                .Select(ClienteMapping.MapToClientDetalleConProyecto(_context))
                .FirstAsync();

        }

        public async Task DeleteClienteAsync(int id) 
        {
            var cliente = await _context.Clientes.Where(c => c.Id == id).Select(ClienteMapping.MapToClientDetalleConProyecto(_context)).FirstAsync();
            var proyectos = _context.Proyectos.Where(p => p.ClienteId.Equals(cliente.Id)).ToList();
            foreach (var cp in proyectos)
            {
                cp.ClienteId = 1;
                _context.Proyectos.Add(cp);
                _context.Update(cp);
                await _context.SaveChangesAsync();
            }            
        }

        public async Task<ClienteDetalle> InsertProyectoInClienteAsync(int id, ProyectoDetalle proyecto)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Id.Equals(id));
            var nuevoProyecto = new Proyecto(proyecto);
            
            cliente.Proyectos.Add(nuevoProyecto);
            _context.Clientes.Add(cliente);
            _context.Update(cliente);
            _context.Proyectos.Add(nuevoProyecto);
            await _context.SaveChangesAsync();
            return await _context.Clientes
                .Where(c => c.Id == cliente.Id)
                .Select(ClienteMapping.MapToClientDetalleConProyecto(_context))
                .FirstAsync();
        }
        public async Task DeleteProyectoInClienteAsync(int id)
        {
            var cliente = await _context.Clientes.Where(c => c.Id == id).Select(ClienteMapping.MapToClientDetalleConProyecto(_context)).FirstAsync();
            var proyectos = _context.Proyectos.Where(p => p.ClienteId.Equals(cliente.Id)).ToList();
            foreach (var cp in proyectos)
            {
                cp.ClienteId = 1;
                _context.Proyectos.Add(cp);
                _context.Update(cp);
                await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();

        }

        public async Task<ClienteDetalle> InsertSeguimientoInClienteAsync(int id, SeguimientoDetalle seguimiento)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Id.Equals(id));
            

            _context.Seguimientos.Add(new Seguimiento(seguimiento));
            await _context.SaveChangesAsync();
            var a = _context.Seguimientos.ToList();
            seguimiento.Id =  a.LastOrDefault().Id;
            var seguimientoCliente = new SeguimientoCliente(id, seguimiento.Id);
            cliente.SeguimientosClientes.Add(seguimientoCliente);
            _context.SeguimientoCliente.Add(seguimientoCliente);
            
            _context.Clientes.Add(cliente);
            _context.Update(cliente);
            await _context.SaveChangesAsync();
            return await _context.Clientes
                .Where(c => c.Id == cliente.Id)
                .Select(ClienteMapping.MapToClientDetalleConProyecto(_context))
                .FirstAsync();
        }

        public async Task<ClienteDetalle> InsertLicitacionInClienteAsync(int id, LicitacionDetalle licitacion)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Id.Equals(id));


            _context.Licitaciones.Add(new Licitacion(licitacion));
            await _context.SaveChangesAsync();
            var a = _context.Licitaciones.ToList();
            licitacion.Id = a.LastOrDefault().Id;
            var licitacionClientes = new LicitacionCliente(id, licitacion.Id);
            cliente.LicitacionesClientes.Add(licitacionClientes);
            _context.LicitacionCliente.Add(licitacionClientes);

            _context.Clientes.Add(cliente);
            _context.Update(cliente);
            await _context.SaveChangesAsync();
            return await _context.Clientes
                .Where(c => c.Id == cliente.Id)
                .Select(ClienteMapping.MapToClientDetalleConProyecto(_context))
                .FirstAsync();
        }
        private async void DeleteSeguimientosDeProyecto(ClienteDetalle cliente)
        {
            var seguimientoCliente = _context.SeguimientoCliente.Where(sc => sc.ClienteId.Equals(cliente.Id)).Select(ClienteMapping.MapSeguimienClientestoToTablaIntermedia()).ToList();
            var seguimientos = _context.Seguimientos.ToList();
            foreach (var sc in seguimientoCliente)
            {

                _context.SeguimientoCliente.Remove(new SeguimientoCliente(sc.IdSuperior, sc.IdModelo));
                foreach (var s in seguimientos)
                {
                    if (s.Id.Equals(sc.IdModelo))
                    {
                        _context.Seguimientos.Remove(s);
                        await _context.SaveChangesAsync();
                    }
                }
                await _context.SaveChangesAsync();

            }
            _context.Clientes.Remove(new Cliente(cliente));
            await _context.SaveChangesAsync();
        }
    }
}
