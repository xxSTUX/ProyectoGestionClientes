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
                .Select(ClienteMapping.MapToClientDetalleConProyecto(_context.Seguimientos, _context.Licitaciones))
                .FirstAsync();
        }

        public async Task<List<ClienteDetalle>> GetAllClientesAsync()
        {
             
            var cliente = await _context.Clientes.Select(ClienteMapping.MapToClientDetalleConProyecto(_context.Seguimientos, _context.Licitaciones)).ToListAsync();
            return cliente;
        }

        public async Task<int> InsertClienteAsync(ClienteDetalle cliente) //Si esta mal, dejar esta
        {
            var nuevoCliente = new Cliente(cliente);
            _context.Clientes.Add(nuevoCliente);
            await _context.SaveChangesAsync();
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
                .Select(ClienteMapping.MapToClientDetalleConProyecto())
                .FirstAsync();

        }

        public async Task DeleteClienteAsync(int id) 
        {
            var cliente = await _context.Clientes.Where(c => c.Id == id).Select(ClienteMapping.MapToCreateClientDetalle()).FirstAsync();
            var proyectos = _context.Proyectos.Where(p => p.Cliente_id.Equals(cliente.Id)).ToList();
            foreach (var cp in proyectos)
            {
                cp.Cliente_id = 1;
                _context.Proyectos.Add(cp);
                _context.Update(cp);
                await _context.SaveChangesAsync();
            }
            var seguimientoCliente = _context.SeguimientoCliente.Where(sc=>sc.Cliente_id.Equals(cliente.Id)).Select(ClienteMapping.MapSeguimienClientestoToTablaIntermedia()).ToList();
            var seguimientos = _context.Seguimientos.ToList();
            foreach (var sc in seguimientoCliente)
            {

                _context.SeguimientoCliente.Remove(new Data.Enitites.SeguimientoClientes(sc.IdSuperior,sc.IdModelo));
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
                .Select(ClienteMapping.MapToClientDetalleConProyecto())
                .FirstAsync();
        }

        public async Task<ClienteDetalle> InsertSeguimientoInClienteAsync(int id, SeguimientoDetalle seguimiento)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Id.Equals(id));
            

            _context.Seguimientos.Add(new Seguimientos(seguimiento));
            await _context.SaveChangesAsync();
            var a = _context.Seguimientos.ToList();
            seguimiento.Id =  a.LastOrDefault().Id;
            var seguimientoCliente = new SeguimientoClientes(id, seguimiento.Id);
            cliente.Seguimientos.Add(seguimientoCliente);
            _context.SeguimientoCliente.Add(seguimientoCliente);
            
            _context.Clientes.Add(cliente);
            _context.Update(cliente);
            await _context.SaveChangesAsync();
            return await _context.Clientes
                .Where(c => c.Id == cliente.Id)
                .Select(ClienteMapping.MapToClientDetalleConProyecto())
                .FirstAsync();
        }

        public async Task<ClienteDetalle> InsertLicitacionInClienteAsync(int id, LicitacionDetalle licitacion)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Id.Equals(id));


            _context.Licitaciones.Add(new Licitaciones(licitacion));
            await _context.SaveChangesAsync();
            var a = _context.Licitaciones.ToList();
            licitacion.Id = a.LastOrDefault().Id;
            var licitacionClientes = new LicitacionClientes(id, licitacion.Id);
            cliente.Licitaciones.Add(licitacionClientes);
            _context.LicitacionCliente.Add(licitacionClientes);

            _context.Clientes.Add(cliente);
            _context.Update(cliente);
            await _context.SaveChangesAsync();
            return await _context.Clientes
                .Where(c => c.Id == cliente.Id)
                .Select(ClienteMapping.MapToClientDetalleConProyecto())
                .FirstAsync();
        }
    }
}
