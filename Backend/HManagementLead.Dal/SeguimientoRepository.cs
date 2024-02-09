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
    }
}
