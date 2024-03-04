using HManagementLead.Dal.Interfaces;
using HManagementLead.Dal.Mapping;
using HManagementLead.Data;
using HManagementLead.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HManagementLead.Dal
{
    public class PuestoRepository: IPuestoRepository
    {
        private readonly ApplicationDbContext _context;
        public PuestoRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Codigo>> GetAllPuestoAsync()
        {
            return await _context.Puestos.Select(PuestoMapping.MapPuestoToCodigo()).ToListAsync();
        }

        public Task<PuestoDetalle> GetPuestoByIdAsync(int id)
        {
            return _context.Puestos
                .Where(p => p.Id == id)
                .Select(PuestoMapping.MapToPuesto())
                .FirstAsync();
        }
    }
}
