using HManagementLead.Dal.Interfaces;
using HManagementLead.Data;
using HManagementLead.Entities;
using Microsoft.EntityFrameworkCore;
using HManagementLead.Dal.Mapping;

namespace HManagementLead.Dal
{
    public class ProyectoRepository : IProyectoRepository
    {
        private readonly ApplicationDbContext _context;
        public ProyectoRepository (ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<ProyectoDetalle> GetProyectoByIdAsync(int id)
        {
            var cliente = _context.Clientes
                .Where(c => c.Id == (_context.Proyectos.Where(p=> p.Id == id).First()).IdCliente).First();
            return _context.Proyectos
                .Where(p => p.Id == id)
                .Select(ProyectoMapping.MapToProyecto(cliente.Nombre))
                .FirstAsync();
        }

        public async Task<List<ProyectoDetalle>> GetAllProyectosAsync()
        {
            return await _context.Proyectos.Select(ProyectoMapping.MapToProyecto()).ToListAsync();

        }

        public async Task<int> InsertProyectoAsync(ProyectoDetalle proyecto)
        {
            var nuevoProyecto= new Proyecto(proyecto);
            _context.Proyectos.Add(nuevoProyecto);
            await _context.SaveChangesAsync();
            return nuevoProyecto.Id;
        }

        public async Task DeleteProyectoAsync(int id)
        {
            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto != null)
            {
                _context.Proyectos.Remove(proyecto);
                await _context.SaveChangesAsync();
            }
        }

        public Task<ProyectoDetalle> UpdateProyectoAsync(ProyectoDetalle proyecto)
        {
            var nuevoProyecto = new Proyecto(proyecto);
            _context.Proyectos.Add(nuevoProyecto);
            _context.Update(nuevoProyecto);
            _context.SaveChangesAsync();

            return _context.Proyectos
                .Where(c => c.Id == proyecto.Id)
                .Select(ProyectoMapping.MapToProyecto(proyecto.NombreCliente))
                .FirstAsync();
        }
    }
}
