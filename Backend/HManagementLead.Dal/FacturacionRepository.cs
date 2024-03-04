using HManagementLead.Dal.Mapping;
using HManagementLead.Data;
using HManagementLead.Entities;
using HManagementLead.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HManagementLead.Dal
{
    public class FacturacionRepository: IFacturacionRepository
    {
        private readonly ApplicationDbContext _context;
        public FacturacionRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Codigo>> GetAllFacturacionAsync()
        {
            return await _context.Facturaciones.Select(FacturacionMapping.MapFacturacionToCodigo()).ToListAsync();
        }

        public Task<FacturacionDetalle> GetFacturacionByIdAsync(int id)
        {
            return _context.Facturaciones
                .Where(f => f.Id == id)
                .Select(FacturacionMapping.MapToFacturacion())
                .FirstAsync();
        }
    }
}
