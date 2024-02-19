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

        public async Task<List<Codigo>> GetAllSeguimientoAsync()
        {
            return await _context.Seguimientos.Select(SeguimientoMapping.MapSeguimientoToCodigo()).ToListAsync();

        }

        public async Task<int> InsertSeguimientoAsync(SeguimientoDetalle seguimiento)
        {
            var nuevoSeguimiento = new Seguimientos(seguimiento);
            _context.Seguimientos.Add(nuevoSeguimiento);
            await _context.SaveChangesAsync();
            return nuevoSeguimiento.Id;
        }

        public async Task<SeguimientoDetalle> UpdateSeguimientoAsync(int id,SeguimientoDetalle seguimiento)
        {
            var seguimientoModificado = new Seguimientos { Id = id, Nombre = seguimiento.Nombre };
            _context.Update(seguimientoModificado);
            await _context.SaveChangesAsync();
            return await _context.Seguimientos
                .Where(s => s.Id == id)
                .Select(SeguimientoMapping.MapToSeguimiento())
                .FirstAsync(); 
        }

        public async Task DeleteSeguimientoByIdAsync(int id)
        {
            var seguimiento = await _context.Seguimientos.FindAsync(id);
            if (seguimiento != null)
            {
                _context.Seguimientos.Remove(seguimiento);
                await _context.SaveChangesAsync();
            }
        }
    }
}