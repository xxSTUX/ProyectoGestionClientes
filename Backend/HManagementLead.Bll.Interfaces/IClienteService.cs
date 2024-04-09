using HManagementLead.Data;
using HManagementLead.Entities;

namespace HManagementLead.Bll.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteDetalle> GetClienteByIdAsync(int id);
        Task<bool> ClienteExistsAsync(string nombre);

        Task<List<ClienteDetalle>> GetAllClientesAsync();
        //Arbol
        Task<List<ClienteSimplificado>> GetAllClientesCompletoAsync();

        Task<int> InsertClienteAsync(ClienteDetalle cliente);

        Task<ClienteDetalle> UpdateClienteAsync(ClienteDetalle cliente);

        Task <ClienteDetalle> DeleteClienteAsync(int id);

        Task<ClienteDetalle> InsertProyectoInClienteAsync(int id, ProyectoDetalle proyecto);

        Task<ClienteDetalle> InsertSeguimientoInClienteAsync(int id, SeguimientoDetalle seguimiento);

        Task<ClienteDetalle> InsertLicitacionInClienteAsync(int id, LicitacionDetalle seguimiento);

        Task<ClienteDetalle> InsertAreaInClienteAsync(int id, AreaDetalle area);

        Task<ClienteDetalle> InsertContactoInClienteAsync(int id, ContactoDetalle contacto);

        Task<List<Codigo>> GetAllClientesAsyncToCodigo();

        Task<ClienteDetalle> GetClienteByNombre(string nombre);


    }
}
