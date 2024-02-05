using HManagementLead.Bll.Interfaces;
using HManagementLead.Dal.Interfaces;
using HManagementLead.Entities;

namespace HManagementLead.Bll
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository repository) 
        { 
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task DeleteClienteAsync(int id)
        {
            return _repository.DeleteClienteAsync(id);
        }

        public Task<List<ClienteDetalle>> GetAllClientesAsync()
        {
            var resultado = _repository.GetAllClientesAsync();
            return resultado;
        }

        public Task<ClienteDetalle> GetClienteByIdAsync(int id)
        {
            return _repository.GetClienteByIdAsync(id);
        }

        public Task<int> InsertClienteAsync(ClienteDetalle cliente)
        {
            return _repository.InsertClienteAsync(cliente);
        }

        public Task<ClienteDetalle> UpdateClienteAsync(ClienteDetalle cliente)
        {
            return _repository.UpdateClienteAsync(cliente);
        }
    }
}
