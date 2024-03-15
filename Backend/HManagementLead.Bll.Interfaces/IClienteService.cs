using HManagementLead.Data;
using HManagementLead.Data.Enitites;
using HManagementLead.Entities;



namespace HManagementLead.Bll.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteDetalle> GetClienteByIdAsync(int id);

        Task<List<ClienteDetalle>> GetAllClientesAsync();
        //Arbol
        Task<List<ClienteSimplificado>> GetAllClientesCompletoAsync();
        //Cliente id + nombre
        Task<List<ClienteNombreId>> GetAllClientesNombreIdAsync();

        Task<int> InsertClienteAsync(ClienteDetalle cliente);

        Task<ClienteDetalle> UpdateClienteAsync(ClienteDetalle cliente);

        Task DeleteClienteAsync(int id);

        Task<ClienteDetalle> InsertProyectoInClienteAsync(int id, ProyectoDetalle proyecto);

        Task<ClienteDetalle> InsertSeguimientoInClienteAsync(int id, SeguimientoDetalle seguimiento);

        Task<ClienteDetalle> InsertLicitacionInClienteAsync(int id, LicitacionDetalle seguimiento);
        
    }
}
