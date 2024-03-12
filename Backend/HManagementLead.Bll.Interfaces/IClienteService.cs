using HManagementLead.Data.Enitites;
using HManagementLead.Entities;

namespace HManagementLead.Bll.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteDetalle> GetClienteByIdAsync(int id);

        Task<ClienteBasicCompleto> GetClienteBasicCompletoByIdAsync(int id);

        Task<List<ClienteDetalle>> GetAllClientesAsync();

        Task<int> InsertClienteAsync(ClienteDetalle cliente);

        Task<ClienteDetalle> UpdateClienteAsync(ClienteDetalle cliente);

        Task DeleteClienteAsync(int id);

        Task<ClienteDetalle> InsertProyectoInClienteAsync(int id, ProyectoDetalle proyecto);

        Task<ClienteDetalle> InsertSeguimientoInClienteAsync(int id, SeguimientoDetalle seguimiento);

        Task<ClienteDetalle> InsertLicitacionInClienteAsync(int id, LicitacionDetalle seguimiento);

        Task<List<Codigo>> GetAllClientesAsyncToCodigo();

        Task<List<ClienteBasic>> GetAllClientesBasicAsync();


    }
}
