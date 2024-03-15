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

        public async Task<List<ContactoDetalle>> GetAllContactoAsync()
        {
            return await _context.Contactos.Select(ContactoMapping.MapToContacto()).ToListAsync();

        }

        public Task<ContactoDetalle> GetContactoByIdAsync(int id)
        {
            return _context.Contactos
                .Where(p => p.Id == id)
                .Select(ContactoMapping.MapToContacto())
                .FirstAsync();
        }
        public async Task<ContactoDetalle> UpdateEliminadoAsync(int id)
        {
            var contacto = _context.Contactos.Where(p => p.Id.Equals(id)).Select(ContactoMapping.MapToContacto()).FirstOrDefault();
            contacto.Eliminado = true;
            var nuevoContacto = new Contacto(contacto);
            _context.Contactos.Add(nuevoContacto);
            _context.Update(nuevoContacto);
            await _context.SaveChangesAsync();
            return contacto;
        }
    }
}
