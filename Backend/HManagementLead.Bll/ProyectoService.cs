using HManagementLead.Bll.Interfaces;
using HManagementLead.Dal.Interfaces;
using HManagementLead.Entities;

namespace HManagementLead.Bll
{
    public class ProyectoService : IProyectoService
    {
        private readonly IProyectoRepository _repository;
        public ProyectoService(IProyectoRepository repository) 
        { 
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task DeleteProyectoAsync(int id)
        {
            return _repository.DeleteProyectoAsync(id);
        }

        public Task<List<ProyectoDetalle>> GetAllProyectosAsync()
        {
            return _repository.GetAllProyectosAsync();
        }

        public Task<ProyectoDetalle> GetProyectoByIdAsync(int id)
        {
            return _repository.GetProyectoByIdAsync(id);
        }

        public Task<int> InsertProyectoAsync(ProyectoDetalle proyecto)
        {
            return _repository.InsertProyectoAsync(proyecto);
        }

        public Task<ProyectoDetalle> UpdateProyectoAsync(ProyectoDetalle proyecto)
        {
            return _repository.UpdateProyectoAsync(proyecto);
        }

        public Task<ProyectoDetalle> InsertSeguimientoInProyectoAsync(int id, SeguimientoDetalle seguimiento)
        {
            return _repository.InsertSeguimientoInProyectoAsync(id, seguimiento);
        }

        public Task<ProyectoDetalle> UpdateEliminadoAsync(int id)
        {
            return _repository.UpdateEliminadoAsync(id);
        }
        public Task<List<EstadoProyectoDetalle>> GetEstadoPoryectos()
        {
            return _repository.GetEstadoPoryectos();
        }
    }
}
