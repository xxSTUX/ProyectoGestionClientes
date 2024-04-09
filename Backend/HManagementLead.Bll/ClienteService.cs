using HManagementLead.Bll.Interfaces;
using HManagementLead.Dal.Interfaces;
using HManagementLead.Data;
using HManagementLead.Entities;
using Microsoft.EntityFrameworkCore;

namespace HManagementLead.Bll
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository repository) 
        { 
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<ClienteDetalle> DeleteClienteAsync(int id)
        {
            return _repository.DeleteClienteAsync(id);
        }

        public Task<List<ClienteDetalle>> GetAllClientesAsync()
        {
            var resultado = _repository.GetAllClientesAsync();
            return resultado;
        }

        //clientes con sus objetos pero solo id y nombre para generar el arbol
        public Task<List<ClienteSimplificado>> GetAllClientesCompletoAsync()
        {
            var resultado = _repository.GetAllClientesCompletoAsync();
            return resultado;
        }

        public Task<ClienteDetalle> GetClienteByIdAsync(int id)
        {
            return _repository.GetClienteByIdAsync(id);
        }

        public  Task<bool> ClienteExistsAsync(string nombre)
        {
            var resultado = _repository.ClienteExistsAsync(nombre);
            return resultado;
        }

        public Task<int> InsertClienteAsync(ClienteDetalle cliente)
        {
            return _repository.InsertClienteAsync(cliente);
        }

        public Task<ClienteDetalle> UpdateClienteAsync(ClienteDetalle cliente)
        {
            return _repository.UpdateClienteAsync(cliente);
        }

        public Task<ClienteDetalle> InsertProyectoInClienteAsync(int id, ProyectoDetalle proyecto)
        {
            return _repository.InsertProyectoInClienteAsync(id, proyecto);
        }

        public Task<ClienteDetalle> InsertSeguimientoInClienteAsync(int id, SeguimientoDetalle seguimiento)
        {
            return _repository.InsertSeguimientoInClienteAsync(id, seguimiento);
        }

        public Task<ClienteDetalle> InsertLicitacionInClienteAsync(int id, LicitacionDetalle licitacion)
        {
            return _repository.InsertLicitacionInClienteAsync(id, licitacion);
        }

        public Task<ClienteDetalle> InsertAreaInClienteAsync(int id, AreaDetalle area)
        {
            return _repository.InsertAreaInClienteAsync(id, area);
        }

        public Task<ClienteDetalle> InsertContactoInClienteAsync(int id, ContactoDetalle contacto)
        {
            return _repository.InsertContactoInClienteAsync(id, contacto);
        }

        public Task<List<Codigo>> GetAllClientesAsyncToCodigo() {
            return _repository.GetAllClientesAsyncToCodigo();
        }
        public Task<ClienteDetalle> GetClienteByNombre(string nombre)
        {
            return _repository.GetClienteByNombre(nombre);
        }
    }
}
