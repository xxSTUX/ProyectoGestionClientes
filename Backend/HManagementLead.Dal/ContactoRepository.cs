using HManagementLead.Dal.Interfaces;
using HManagementLead.Data;
using HManagementLead.Entities;
using Microsoft.EntityFrameworkCore;
using HManagementLead.Dal.Mapping;
using HManagementLead.Data.Enitites;

namespace HManagementLead.Dal
{
    public class ContactoRepository : IContactoRepository
    {
        private readonly ApplicationDbContext _context;
        public ContactoRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Codigo>> GetAllContactoAsync()
        {
            return await _context.Contactos.Select(ContactoMapping.MapContactoToCodigo()).ToListAsync();

        }

        public Task<ContactoDetalle> GetContactoByIdAsync(int id)
        {
            return _context.Contactos
                .Where(p => p.Id == id)
                .Select(ContactoMapping.MapToContacto())
                .FirstAsync();
        }
    }
}
