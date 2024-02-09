using HManagementLead.Bll.Interfaces;
using HManagementLead.Dal.Interfaces;
using HManagementLead.Entities;

namespace HManagementLead.Bll
{
    public class SeguimientoService : ISeguimientoService
    {
        private readonly ISeguimientoRepository _repository;
        public SeguimientoService(ISeguimientoRepository repository) 
        { 
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<List<Codigo>> GetAllSeguimientoAsync()
        {
            return _repository.GetAllSeguimientoAsync();
        }

        public Task<SeguimientoDetalle> GetSeguimientoByIdAsync(int id)
        {
            return _repository.GetSeguimientoByIdAsync(id);
        }
    }
}
