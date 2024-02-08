using HManagementLead.Entities;

namespace HManagementLead.Dal.Interfaces
{
    public  interface IProyectoRepository
    {
        Task<ProyectoDetalle> GetProyectoByIdAsync(int id);

        Task<List<ProyectoDetalle>> GetAllProyectosAsync();

        Task<int> InsertProyectoAsync(ProyectoDetalle cliente);

        Task<ProyectoDetalle> UpdateProyectoAsync(ProyectoDetalle proyecto);

        Task DeleteProyectoAsync(int id);

        Task<ProyectoDetalle> InsertSeguimientoInProyectoAsync(int id, SeguimientoDetalle seguimiento);

    }
}
