using HManagementLead.Dal.Interfaces;
using HManagementLead.Data;
using HManagementLead.Entities;
using Microsoft.EntityFrameworkCore;
using HManagementLead.Dal.Mapping;
using HManagementLead.Data.Enitites;

namespace HManagementLead.Dal
{
    public class LicitacionRepository : ILicitacionRepository
    {
        private readonly ApplicationDbContext _context;
        public LicitacionRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Codigo>> GetAllLicitacionAsync()
        {
            return await _context.Licitaciones.Select(LicitacionMapping.MapLicitacionToCodigo()).ToListAsync();

        }

        public Task<LicitacionDetalle> GetLicitacionByIdAsync(int id)
        {
            return _context.Licitaciones
                .Where(p => p.Id == id)
                .Select(LicitacionMapping.MapToLicitacion())
                .FirstAsync();
        }

        public async Task<int> InsertLicitacionAsync(LicitacionDetalle licitacion)
        {
            var nuevaLicitacion = new Licitaciones(licitacion);
            _context.Licitaciones.Add(nuevaLicitacion);
            await _context.SaveChangesAsync();
            return nuevaLicitacion.Id;
        }

        public async Task<LicitacionDetalle> UpdateLicitacionAsync(int id, LicitacionDetalle licitacion)
        {
            var licitacionModificada = new Licitaciones { Id = id, Nombre = licitacion.Nombre };
            _context.Update(licitacionModificada);
            await _context.SaveChangesAsync();
            return await _context.Licitaciones
                .Where(l => l.Id == id)
                .Select(LicitacionMapping.MapToCreateLicitacion())
                .FirstAsync();
        }
    }
}
