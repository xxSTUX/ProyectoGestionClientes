using HManagementLead.Dal.Interfaces;
using HManagementLead.Data;
using HManagementLead.Entities;
using Microsoft.EntityFrameworkCore;
using HManagementLead.Dal.Mapping;
using HManagementLead.Data.Enitites;

namespace HManagementLead.Dal
{
    public class SeguimientoRepository : ISeguimientoRepository
    {
        private readonly ApplicationDbContext _context;
        public SeguimientoRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<SeguimientoDetalle> GetSeguimientoByIdAsync(int id)
        { 
            return _context.Seguimientos
                .Where(p => p.Id == id)
                .Select(SeguimientoMapping.MapToSeguimiento())
                .FirstAsync();
        }

        public Task<SeguimientoDetalle> GetSeguimientoByCliIdAsync(int id)
        {
            var segcliente = _context.SeguimientoClientes.Where(p => p.IdCliente.Equals(id)).Select(p=> p.IdSeguimiento);
            
            return _context.Seguimientos
                .Where(p => p.Id.Equals(segcliente))
                .Select(SeguimientoMapping.MapToSeguimiento())
                .FirstAsync();
        }

        public async Task<List<Codigo>> GetAllSeguimientoAsync()
        {
            return await _context.Seguimientos.Select(SeguimientoMapping.MapSeguimientoToCodigo()).ToListAsync();

        }

        public async Task<int> InsertSeguimientoAsync(SeguimientoDetalle seguimiento)
        {
            var nuevoSeguimiento = new Seguimiento(seguimiento);
            _context.Seguimientos.Add(nuevoSeguimiento);
            await _context.SaveChangesAsync();
            return nuevoSeguimiento.Id;
        }

        public async Task DeleteSeguimientoAsync(int id)
        {
            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto != null)
            {
                _context.Proyectos.Remove(proyecto);
                await _context.SaveChangesAsync();
            }
        }

        public Task<SeguimientoDetalle> UpdateSeguimientoAsync(SeguimientoDetalle seguimiento)
        {
            var nuevoSeguimiento = new Seguimiento(seguimiento);
            _context.Seguimientos.Add(nuevoSeguimiento);
            _context.Update(nuevoSeguimiento);
            _context.SaveChangesAsync();

            return _context.Seguimientos
                .Where(c => c.Id == seguimiento.Id)
                .Select(SeguimientoMapping.MapToSeguimiento())
                .FirstAsync();
        }
    }
}
