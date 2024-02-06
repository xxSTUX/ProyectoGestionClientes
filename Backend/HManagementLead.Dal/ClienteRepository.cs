using HManagementLead.Dal.Interfaces;
using HManagementLead.Data;
using HManagementLead.Entities;
using Microsoft.EntityFrameworkCore;
using HManagementLead.Dal.Mapping;

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
                .Select(ClienteMapping.MapToClientDetalleConProyecto(_context.Seguimientos))
                .FirstAsync();
        }

        public async Task<List<ClienteDetalle>> GetAllClientesAsync()
        {
            return await _context.Clientes.Select(ClienteMapping.MapToClientDetalleConProyecto(_context.Seguimientos)).ToListAsync();

        }

        public async Task<int> InsertClienteAsync(ClienteDetalle cliente)
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
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
