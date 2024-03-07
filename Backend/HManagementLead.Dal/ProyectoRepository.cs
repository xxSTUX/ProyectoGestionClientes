using HManagementLead.Dal.Interfaces;
using HManagementLead.Data;
using HManagementLead.Entities;
using Microsoft.EntityFrameworkCore;
using HManagementLead.Dal.Mapping;
using HManagementLead.Data.Enitites;

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
            return _context.Proyectos
                .Where(p => p.Id == id)
                .Select(ProyectoMapping.MapToProyecto(_context.Seguimientos,_context.Licitaciones)) //Borrar el _licitaciones si no va nada.
                .FirstAsync();
        }

        public async Task<List<ProyectoDetalle>> GetAllProyectosAsync()
        {
            var cliente = await _context.Proyectos.Select(ProyectoMapping.MapToProyecto(_context.Seguimientos, _context.Licitaciones)).ToListAsync(); //Borrar el _licitaciones si no va nada
            return cliente;

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
                .Select(ProyectoMapping.MapToProyecto(_context))
                .FirstAsync();
        }

        public async Task<ProyectoDetalle> InsertSeguimientoInProyectoAsync(int id, SeguimientoDetalle seguimiento)
        {
            var proyecto = _context.Proyectos.FirstOrDefault(c => c.Id.Equals(id));
            var seguimientoProyecto = new SeguimientoProyecto(id, seguimiento.Id);
            proyecto.SeguimientosProyectos.Add(seguimientoProyecto);
            _context.Proyectos.Add(proyecto);
            _context.Update(proyecto);
            _context.SeguimientoProyecto.Add(seguimientoProyecto);
            _context.Seguimientos.Add(new Seguimiento(seguimiento));
            await _context.SaveChangesAsync();
            return await _context.Proyectos
                .Where(c => c.Id == proyecto.Id)
                .Select(ProyectoMapping.MapToProyecto())
                .FirstAsync();
        }
    }
}
