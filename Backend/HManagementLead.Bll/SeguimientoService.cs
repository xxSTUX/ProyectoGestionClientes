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

        public Task<int> InsertSeguimientoAsync(SeguimientoDetalle seguimiento)
        {
            return _repository.InsertSeguimientoAsync(seguimiento);
        }

        public Task<SeguimientoDetalle> UpdateSeguimientoAsync(int id, SeguimientoDetalle seguimiento)
        {
            return _repository.UpdateSeguimientoAsync(id,seguimiento);
        }

        public Task DeleteSeguimientoByIdAsync(int id)
        {
            return _repository.DeleteSeguimientoByIdAsync(id);
        }
    }
}
